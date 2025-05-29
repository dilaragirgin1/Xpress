using BG.Express.API.Model.Request;
using BG.Express.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BG.Express.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeliveryController : ControllerBase
    {
        private readonly IDeliveryService _deliveryService;

        public DeliveryController(IDeliveryService deliveryService)
        {
            _deliveryService = deliveryService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDelivery([FromBody] DeliveryCreateRequest request)
        {
            var deliveryId = await _deliveryService.CreateDeliveryAsync(request);
            return Ok(new { DeliveryId = deliveryId });
        }
    }
}
