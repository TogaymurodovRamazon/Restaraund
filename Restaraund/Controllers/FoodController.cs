using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaran.Service.DTOs;
using Restaran.Service.IServices;

namespace Restaraund.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFoodService service;
        public FoodController(IFoodService service)
        {
            this.service = service;
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync(FoodDTO dTO)
            => Ok(await service.CreateAsync(dTO));

        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
            => Ok(service.GetAll(p => p.Id != 0));

        [HttpPut("{id}")]
        public async ValueTask<IActionResult> UpdateAsync([FromRoute] int id, FoodDTO dTO)
            => Ok(service.Update(id, dTO));

        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetAsync([FromForm] int id)
            => Ok(await service.GetAsync(p => p.Id == id));

        [HttpDelete("{id}")]
        public async ValueTask<IActionResult> DeleteAsync([FromForm] int id)
            => Ok(await service.DeleteAsync(p=>p.Id == id));
    }
}
