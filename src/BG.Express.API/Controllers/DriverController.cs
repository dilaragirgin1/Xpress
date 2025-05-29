using BG.Express.API.Model.Request;
using BG.Express.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BG.Express.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IDriverService _driverService;

        public DriverController(IDriverService driverService)
        {
            _driverService = driverService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] DriverGetAllRequest request)
        {
            var response = await _driverService.GetListAsync(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(DriverPostRequest request)
        {
            var response = await _driverService.CreateAsync(request);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, DriverPutRequest request)
        {
            var response = await _driverService.UpdateAsync(id, request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _driverService.DeleteAsync(id);
            return NoContent();
        }
    }
}
