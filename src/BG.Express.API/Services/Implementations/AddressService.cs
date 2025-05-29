using AutoMapper;
using Beymen.IT.Package.EntityFrameworkCore;
using Beymen.IT.Package.ExceptionHandling.Exceptions;
using BG.Express.API.Data.Entity;
using BG.Express.API.Exceptions;
using BG.Express.API.Data.Extensions;
using BG.Express.API.Model.Request;
using BG.Express.API.Model.Response;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace BG.Express.API.Services.Implementations
{
    public class AddressService : IAddressService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IOptiyolService _optiyolService;

        public AddressService(IUnitOfWork unitOfWork, IMapper mapper, IOptiyolService optiyolService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _optiyolService = optiyolService;
        }

        public async Task<BaseResponse<List<AddressResponse>>> GetListAsync(GetAddressRequest request)
        {
            var query = _unitOfWork.Repository<Address, int>().GetAll().AsNoTracking()
                .Where(x => x.IsError) // Sadece IsError == true olanları getirmeli
                .WhereIf(x => EF.Functions.ILike(x.CustomerCode, $"%{request.CustomerCode!}%"),
                        !string.IsNullOrEmpty(request.CustomerCode))
                .WhereIf(x => EF.Functions.ILike(x.City, $"%{request.City!}%"),
                        !string.IsNullOrEmpty(request.City))
                .WhereIf(x => x.CityCode == request.CityCode,
                        request.CityCode.HasValue);

            var result = await query
                .OrderBy($"{request.SortBy} {request.SortOrder}")
                .PaginateWith(request)
                .ToListAsync();

            return new BaseResponse<List<AddressResponse>>
            {
                Data = _mapper.Map<List<AddressResponse>>(result),
                Total = await query.CountAsync()
            };
        }
        public async Task<BaseResponse<AddressResponse>> GetAsync(int id)
        {
            var address = await _unitOfWork.Repository<Address, int>().GetAsync(id)
                ?? throw ExpressExceptions.AddressNotFoundException;

            return new BaseResponse<AddressResponse>
            {
                Data = _mapper.Map<AddressResponse>(address)
            };
        }

        public async Task<BaseResponse<int>> CreateAsync(AddressCreateRequest request)
        {
            var existingAddress = await _unitOfWork.Repository<Address, int>().GetAll()
                .AnyAsync(x => x.CustomerCode == request.CustomerCode);

            if (existingAddress)

                 throw new BusinessException(ExpressExceptions.Messages.AddressAlreadyExist(request.CustomerCode));
  
            var address = new Address
            {
                CustomerCode = request.CustomerCode,
                FullName = request.FullName,
                Email = request.Email,
                Phone = request.Phone,
                City = request.City,
                District = request.District,
                Neighborhood = request.Neighborhood,
                StreetAddress = request.StreetAddress,
                CityCode = request.CityCode,
                Latitude = request.Latitude,
                Longitude = request.Longitude,
                IsError = false
            };

            await PerformGeocodingAsync(address);

            await _unitOfWork.Repository<Address, int>().InsertAsync(address);
            await _unitOfWork.SaveChangesAsync();

            return new BaseResponse<int> { Data = address.Id };
        }

        public async Task<BaseResponse<int>> UpdateAsync(int id, AddressUpdateRequest request)
        {
            var address = await _unitOfWork.Repository<Address, int>().GetAsync(id)
                ?? throw ExpressExceptions.AddressNotFoundException;

            address.City = request.City;
            address.District = request.District;
            address.Neighborhood = request.Neighborhood;
            address.StreetAddress = request.StreetAddress;
            address.Latitude = request.Latitude;
            address.Longitude = request.Longitude;

            // Geocode işlemi yapılmayacak
            await _unitOfWork.SaveChangesAsync();
            return new BaseResponse<int> { Data = address.Id };
        }

        public async Task DeleteAsync(int id)
        {
            var address = await _unitOfWork.Repository<Address, int>().GetAll()
                .FirstOrDefaultAsync(x => x.Id == id)
                ?? throw ExpressExceptions.AddressNotFoundException;

            await _unitOfWork.Repository<Address, int>().GetAll()
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();
        }

        private async Task PerformGeocodingAsync(Address address)
        {
            var warningMessage = string.Empty;

            var location = new Location
            {
                LocationId = address.Id.ToString(),
                LocationName = address.FullName,
                Latitude = address.Latitude != 0 ? address.Latitude.ToString().Replace(',', '.') : "",
                Longitude = address.Longitude != 0 ? address.Longitude.ToString().Replace(',', '.') : "",
                City = address.City,
                County = address.District,
                LocationAddress = address.StreetAddress
            };

            try
            {
                var geocodeResponse = await _optiyolService.GetGeocodes(new GetGeocodesRequest
                {
                    Locations = new List<Location> { location }
                });

                var geocodedLocation = geocodeResponse.GeocodedLocations?.FirstOrDefault();
                var geocodeWarning = geocodeResponse.GeocodeWarnings?.FirstOrDefault();

                if (geocodedLocation != null)
                {
                    address.Latitude = geocodedLocation.Latitude;
                    address.Longitude = geocodedLocation.Longitude;
                    address.IsError = false;
                    address.GeocodeScore = 1;
                }

                if (geocodeWarning != null)
                {
                    address.GeocodeScore = geocodeWarning.GeocodeScore;
                    address.Latitude = geocodeWarning.Latitude;
                    address.Longitude = geocodeWarning.Longitude;
                    warningMessage += $"Geocode uyarısı: {geocodeWarning.GeocoderAddress}";
                    address.IsError = true;
                }

                if (geocodeResponse.InputErrors != null)
                {
                    warningMessage += $"Input hataları: {string.Join(", ", geocodeResponse.InputErrors)}";
                    address.IsError = true;
                }

                address.WarningMessage = warningMessage;
            }
            catch (Exception ex)
            {
                address.IsError = true;
                address.WarningMessage = $"Geocoding hatası: {ex.Message}";
            }
        }
    }
}
