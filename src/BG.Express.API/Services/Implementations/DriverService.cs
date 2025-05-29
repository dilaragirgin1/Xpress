using BG.Express.API.Data;
using BG.Express.API.Data.Entities;
using BG.Express.API.Data.Entity;
using BG.Express.API.Model.Request;
using BG.Express.API.Exceptions;
using BG.Express.API.Model.Response;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BG.Express.API.Services.Implementations
{
    public class DriverService : IDriverService
    {
        private readonly ExpressContext _context;

        public DriverService(ExpressContext context)
        {
            _context = context;
        }

        public async Task<BaseResponse<List<DriverGetAllResponse>>> GetListAsync(DriverGetAllRequest request)
        {
            var response = new BaseResponse<List<DriverGetAllResponse>>();

            var query = _context.Set<Driver>().AsQueryable();

            if (!string.IsNullOrEmpty(request.Id))
            {
                query = query.Where(x => x.Id == request.Id);
            }

            if (request.Ids != null && request.Ids.Any())
            {
                query = query.Where(x => request.Ids.Contains(x.Id));
            }

            if (request.IsActive.HasValue)
            {
                query = query.Where(x => x.IsActive == request.IsActive.Value);
            }

            var drivers = await query.ToListAsync();

            response.Data = drivers.Select(driver => new DriverGetAllResponse
            {
                Id = driver.Id,
                DriverName = driver.DriverName,
                DriverPhone = driver.DriverPhone,
                DriverImage = driver.DriverImage,
                IsActive = driver.IsActive
            }).ToList();

            response.Total = response.Data.Count;
            return response;
        }

        public async Task<BaseResponse<string>> CreateAsync(DriverPostRequest request)
        {
            var driver = new Driver
            {
                CreateTime = DateTime.UtcNow,
                DriverName = request.DriverName,
                DriverPhone = request.DriverPhone,
                DriverImage = request.DriverImage,
                IsActive = request.IsActive
            };

            _context.Set<Driver>().Add(driver);
            await _context.SaveChangesAsync();

            return new BaseResponse<string> { Data = driver.Id };
        }

        public async Task<BaseResponse<string>> UpdateAsync(string id, DriverPutRequest request)
        {
            var driver = await _context.Set<Driver>().FirstOrDefaultAsync(x => x.Id == id);
            if (driver == null)
            {
                throw ExpressExceptions.DriverNotFoundException;

            }

            driver.UpdateTime = DateTime.UtcNow;
            driver.DriverName = request.DriverName;
            driver.DriverPhone = request.DriverPhone;
            driver.DriverImage = request.DriverImage;
            driver.IsActive = request.IsActive;

            await _context.SaveChangesAsync();

            return new BaseResponse<string> { Data = driver.Id };
        }

        public async Task DeleteAsync(string id)
        {
            var driver = await _context.Set<Driver>().FirstOrDefaultAsync(x => x.Id == id);
            
            // Eğer driver bulunamazsa hata fırlat
            if (driver == null)
            {
                throw ExpressExceptions.DriverNotFoundException;
            }

            // Eğer driver bulunduysa silme işlemi yap
            _context.Set<Driver>().Remove(driver);
            await _context.SaveChangesAsync();
        }

    }
}
