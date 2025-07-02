using IotApiDemo1.Domain.Models;
using IotApiDemo1.Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IotApiDemo1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FactoryController : ControllerBase
    {
        private readonly IFactoryRepository _repo;

        public FactoryController(IFactoryRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repo.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var factory = await _repo.GetByIdAsync(id);
            return factory is null ? NotFound() : Ok(factory);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Factory factory)
        {
            await _repo.AddAsync(factory);
            return Ok(factory);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Factory factory)
        {
            await _repo.UpdateAsync(id, factory);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _repo.DeleteAsync(id);
            return NoContent();
        }
    }
}
