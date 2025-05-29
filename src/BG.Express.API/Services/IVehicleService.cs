using BG.Express.API.Model.Request;
using BG.Express.API.Model.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BG.Express.API.Services
{
    public interface IVehicleService
    {
        Task<BaseResponse<List<VehicleResponse>>> GetAllAsync();
        Task<BaseResponse<VehicleResponse>> GetByIdAsync(int id);
        Task<BaseResponse<int>> CreateAsync(VehicleCreateRequest request);
        Task<BaseResponse<int>> UpdateAsync(int id, VehicleUpdateRequest request);
        Task DeleteAsync(int id);
    }
}
