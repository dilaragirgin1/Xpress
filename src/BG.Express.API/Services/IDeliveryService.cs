using System.Threading.Tasks;
using BG.Express.API.Model.Request;

namespace BG.Express.API.Services
{
    public interface IDeliveryService
    {
        Task<int> CreateDeliveryAsync(DeliveryCreateRequest request); // Parametreyi güncelledik
    }
}
