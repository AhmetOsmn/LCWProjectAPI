using EntityLayer.Concrete.Entities;
using LCWProjectAPI.Application.Repositories;
using LCWProjectAPI.Application.ViewModels.Category;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LCWProjectAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserWriteRepository _userWriteRepository;
        private readonly IUserReadRepository _userReadRepository;

        public UsersController(IUserWriteRepository userWriteRepository, IUserReadRepository userReadRepository)
        {
            _userWriteRepository = userWriteRepository;
            _userReadRepository = userReadRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = _userReadRepository.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _userReadRepository.GetByIdAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateUserVM model)
        {
            var result = await _userWriteRepository.AddAsync(new()
            {
                Name = model.Name,
                Surname = model.Surname,
                EMail = model.Email
            });
            if (result.Success)
            {
                await _userWriteRepository.SaveAsync();
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateUserVM model)
        {
            // Update isleminde degisiklik yapilmayan alanların eski degerleri kalacak sekilde guncelleme yapilacak.

            User user = (User)await _userReadRepository.GetByIdAsync(model.Id);
            user.Name = model.Name;
            user.Surname = model.Surname;
            user.EMail = model.Email;
            await _userWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _userWriteRepository.RemoveAsync(id);

            if (result.Success)
            {
                await _userWriteRepository.SaveAsync();
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
