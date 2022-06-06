using EntityLayer.Concrete.Entities;
using LCWProjectAPI.Application.Repositories;
using LCWProjectAPI.Application.ViewModels.Category;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LCWProjectAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private readonly IColorWriteRepository _colorWriteRepository;
        private readonly IColorReadRepository _colorReadRepository;

        public ColorsController(IColorWriteRepository colorWriteRepository, IColorReadRepository colorReadRepository)
        {
            _colorWriteRepository = colorWriteRepository;
            _colorReadRepository = colorReadRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = _colorReadRepository.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _colorReadRepository.GetByIdAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateColorVM model)
        {
            var result = await _colorWriteRepository.AddAsync(new()
            {
                Name = model.Name
            });
            if (result.Success)
            {
                await _colorWriteRepository.SaveAsync();
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateColorVM model)
        {
            // IResult duzenlemesi yapilacak

            Color color = (Color)await _colorReadRepository.GetByIdAsync(model.Id);
            color.Name = model.Name;
            await _colorWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _colorWriteRepository.RemoveAsync(id);
            if (result.Success)
            {
                await _colorWriteRepository.SaveAsync();
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
