using BG.Express.API.Model.Request;
using BG.Express.API.Model.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BG.Express.API.Services
{
    public interface IAddressService
    {
        Task<BaseResponse<List<AddressResponse>>> GetListAsync(GetAddressRequest request);
        Task<BaseResponse<AddressResponse>> GetAsync(int id);
        Task<BaseResponse<int>> CreateAsync(AddressCreateRequest request);
        Task<BaseResponse<int>> UpdateAsync(int id, AddressUpdateRequest request);
        Task DeleteAsync(int id);
    }
}
