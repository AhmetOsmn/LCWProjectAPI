using EntityLayer.Concrete.Entities;
using LCWProjectAPI.Application.Repositories;
using LCWProjectAPI.Application.ViewModels.Category;
using LCWProjectAPI.Domain.Entities.Common;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LCWProjectAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;

        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = _productReadRepository.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _productReadRepository.GetByIdAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateProductVM model)
        {
            var result = await _productWriteRepository.AddAsync(new()
            {
                Name = model.Name,
                ImageURL = model.ImageURL,
                Status = (EnumStatus)model.Status,
                ColorId = model.ColorId,
                CategoryId = model.CategoryId,
            });
            if (result.Success)
            {
                await _productWriteRepository.SaveAsync();
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductVM model)
        {
            // IResult duzenlemesi yapilacak

            Product product = (Product)await _productReadRepository.GetByIdAsync(model.Id);
            
            product.Name = model.Name;
            product.ImageURL = model.ImageURL;
            product.Status = (EnumStatus)model.Status;
            product.ColorId = model.ColorId;
            product.CategoryId = model.CategoryId;
            await _productWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _productWriteRepository.RemoveAsync(id);
            if (result.Success)
            {
                await _productWriteRepository.SaveAsync();
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
