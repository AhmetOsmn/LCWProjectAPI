using EntityLayer.Concrete.Entities;
using LCWProjectAPI.Application.Repositories;
using LCWProjectAPI.Application.ViewModels.Category;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LCWProjectAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryWriteRepository _categoryWriteRepository;
        private readonly ICategoryReadRepository _categoryReadRepository;

        public CategoriesController(ICategoryWriteRepository categoryWriteRepository, ICategoryReadRepository categoryReadRepository)
        {
            _categoryWriteRepository = categoryWriteRepository;
            _categoryReadRepository = categoryReadRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = _categoryReadRepository.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _categoryReadRepository.GetByIdAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateCategoryVM model)
        {
            var result = await _categoryWriteRepository.AddAsync(new()
            {
                Name = model.Name
            });
            if (result.Success)
            {
                await _categoryWriteRepository.SaveAsync();
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryVM model)
        {
            // IResult duzenlemesi yapilacak

            Category Category = (Category)await _categoryReadRepository.GetByIdAsync(model.Id);
            Category.Name = model.Name;
            await _categoryWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _categoryWriteRepository.RemoveAsync(id);
            if (result.Success)
            {
                await _categoryWriteRepository.SaveAsync();
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
