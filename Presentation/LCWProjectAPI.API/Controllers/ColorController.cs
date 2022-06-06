using EntityLayer.Concrete.Entities;
using LCWProjectAPI.Application.Repositories;
using LCWProjectAPI.Application.ViewModels.Category;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LCWProjectAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private readonly IColorWriteRepository _colorWriteRepository;
        private readonly IColorReadRepository _colorReadRepository;

        public ColorController(IColorWriteRepository colorWriteRepository, IColorReadRepository colorReadRepository)
        {
            _colorWriteRepository = colorWriteRepository;
            _colorReadRepository = colorReadRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var colors = _colorReadRepository.GetAll();
            return Ok(colors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await _colorReadRepository.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateColorVM model)
        {
            await _colorWriteRepository.AddAsync(new()
            {
                Name = model.Name
            });
            await _colorWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateColorVM model)
        {
            Color color = await _colorReadRepository.GetByIdAsync(model.Id);
            color.Name = model.Name;
            await _colorWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _colorWriteRepository.RemoveAsync(id);
            await _colorWriteRepository.SaveAsync();
            return Ok();
        }

    }
}
