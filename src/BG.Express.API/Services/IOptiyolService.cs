using BG.Express.API.Model.Request;
using BG.Express.API.Model.Response;
using System.Threading.Tasks;

namespace BG.Express.API.Services
{
    public interface IOptiyolService
    {
        Task<GetGeocodesResponse> GetGeocodes(GetGeocodesRequest request);

    }
}
