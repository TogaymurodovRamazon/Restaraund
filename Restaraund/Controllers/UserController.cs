using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaran.Service.DTOs;
using Restaran.Service.IServices;

namespace Restaraund.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService service;
        public UserController(IUserService service)
        {
            this.service = service;
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync(UserDTO dTO)
        => Ok(await service.CreateAsync(dTO));

        [HttpGet]
        public async ValueTask<IActionResult> GetAll()
            => Ok(service.GetAll(p => p.Id != 0));

        [HttpPut("{id}")]
        public async ValueTask<IActionResult> UpdateAsync([FromRoute] int id, UserDTO dTO)
            => Ok(service.Update(id, dTO));

        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetAsync([FromRoute] int id)
            => Ok(await service.GetAsync(p=>p.Id == id));

        [HttpDelete("{id}")]
        public async ValueTask<IActionResult> DeleteAsync([FromRoute] int id)
            => Ok(await service.DeleteAsync(p=>p.Id == id));
    }
}
