using IotApiDemo1.Domain.Models;
using IotApiDemo1.Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IotApiDemo1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceRepository _deviceRepo;

        public DeviceController(IDeviceRepository deviceRepo)
        {
            _deviceRepo = deviceRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _deviceRepo.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var device = await _deviceRepo.GetByIdAsync(id);
            if (device == null) return NotFound();
            return Ok(device);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Device device) =>
            Ok(await _deviceRepo.AddAsync(device));

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Device device) =>
            Ok(await _deviceRepo.UpdateAsync(id, device));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id) =>
            Ok(await _deviceRepo.DeleteAsync(id));
    }
}
