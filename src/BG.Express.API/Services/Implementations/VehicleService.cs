using BG.Express.API.Data;
using BG.Express.API.Data.Entities;
using BG.Express.API.Model.Request;
using BG.Express.API.Model.Response;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BG.Express.API.Services.Implementations
{
    public class VehicleService : IVehicleService
    {
        private readonly ExpressContext _context;

        public VehicleService(ExpressContext context)
        {
            _context = context;
        }

        public async Task<BaseResponse<List<VehicleResponse>>> GetAllAsync()
        {
            var vehicles = await _context.Set<Vehicle>().ToListAsync();
            var response = vehicles.Select(v => new VehicleResponse
            {
                Id = v.Id,
                PlateNumber = v.PlateNumber,
                StartLocationCode = v.StartLocationCode,
                EndLocationCode = v.EndLocationCode,
                VolumeCapacity = v.VolumeCapacity,
                CrossDockCode = v.CrossDockCode,
                IsActive = v.IsActive,
            }).ToList();

            return new BaseResponse<List<VehicleResponse>> { Data = response, Total = response.Count };
        }

        public async Task<BaseResponse<VehicleResponse>> GetByIdAsync(int id)
        {
            var vehicle = await _context.Set<Vehicle>().FindAsync(id);
            if (vehicle == null)
                return new BaseResponse<VehicleResponse> { Errors = new List<string> { "Vehicle not found." } };

            var response = new VehicleResponse
            {
                Id = vehicle.Id,
                PlateNumber = vehicle.PlateNumber,
                StartLocationCode = vehicle.StartLocationCode,
                EndLocationCode = vehicle.EndLocationCode,
                VolumeCapacity = vehicle.VolumeCapacity,
                CreateUserCode = vehicle.CreateUserCode,
                CrossDockCode = vehicle.CrossDockCode,
                IsActive = vehicle.IsActive,
            };

            return new BaseResponse<VehicleResponse> { Data = response };
        }

        public async Task<BaseResponse<int>> CreateAsync(VehicleCreateRequest request)
        {
            var vehicle = new Vehicle
            {
                PlateNumber = request.PlateNumber,
                StartLocationCode = request.StartLocationCode,
                EndLocationCode = request.EndLocationCode,
                VolumeCapacity = request.VolumeCapacity,
                CrossDockCode = request.CrossDockCode,
                CreateUserCode = request.CreateUserCode,
                IsActive = request.IsActive
            };

            _context.Set<Vehicle>().Add(vehicle);
            await _context.SaveChangesAsync();

            return new BaseResponse<int> { Data = vehicle.Id };
        }

        public async Task<BaseResponse<int>> UpdateAsync(int id, VehicleUpdateRequest request)
        {
            var vehicle = await _context.Set<Vehicle>().FindAsync(id);
            if (vehicle == null)
                return new BaseResponse<int> { Errors = new List<string> { "Vehicle not found." } };

            vehicle.PlateNumber = request.PlateNumber;
            vehicle.StartLocationCode = request.StartLocationCode;
            vehicle.EndLocationCode = request.EndLocationCode;
            vehicle.VolumeCapacity = request.VolumeCapacity;
            vehicle.UpdateUserCode = request.UpdateUserCode;
            vehicle.IsActive = request.IsActive;

            await _context.SaveChangesAsync();

            return new BaseResponse<int> { Data = vehicle.Id };
        }

        public async Task DeleteAsync(int id)
        {
            var vehicle = await _context.Set<Vehicle>().FindAsync(id);
            if (vehicle != null)
            {
                _context.Set<Vehicle>().Remove(vehicle);
                await _context.SaveChangesAsync();
            }
        }
    }
}
