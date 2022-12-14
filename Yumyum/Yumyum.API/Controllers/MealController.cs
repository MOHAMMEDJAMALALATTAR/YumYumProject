using Microsoft.AspNetCore.Mvc;
using Yumyum.Core.DTOs;
using Yumyum.Infrastructure.Services.Meals;

namespace Yumyum.API.Controllers
{
    [Route("api/meals")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private readonly IMealService _mealService;
        public MealController(IMealService mealService)
        {
            _mealService = mealService;

        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateMealDto input)
        {
            var meal = await _mealService.Create(input);
            return Ok(meal);

        }
        [HttpPut]
        public async Task<IActionResult> Update( UpdateMealDto input)
        {
            var meal = await _mealService.Update(input);
            return Ok(meal);

        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var meals = await _mealService.GetAll();
            return Ok(meals);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           await _mealService.Delete(id);
            return Ok();
        }

    }
}
