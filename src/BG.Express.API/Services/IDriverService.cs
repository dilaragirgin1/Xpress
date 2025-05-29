using BG.Express.API.Model.Request;
using BG.Express.API.Model.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BG.Express.API.Services
{
    public interface IDriverService
    {
        Task<BaseResponse<List<DriverGetAllResponse>>> GetListAsync(DriverGetAllRequest request);
        Task<BaseResponse<string>> CreateAsync(DriverPostRequest request);
        Task<BaseResponse<string>> UpdateAsync(string id, DriverPutRequest request);
        Task DeleteAsync(string id);
    }
}
