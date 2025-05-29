using BG.Express.API.Model.Request;
using BG.Express.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace BG.Express.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAddressRequest request)
        {
            var response = await _addressService.GetListAsync(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _addressService.GetAsync(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddressCreateRequest request)
        {
            var response = await _addressService.CreateAsync(request);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AddressUpdateRequest request)
        {
            var response = await _addressService.UpdateAsync(id, request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _addressService.DeleteAsync(id);
            return NoContent();
        }
    }
}