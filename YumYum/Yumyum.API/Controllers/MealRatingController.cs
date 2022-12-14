using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Yumyum.Core.DTOs;
using Yumyum.Data.Models;
using Yumyum.Infrastructure.Services.MealRatings;

namespace Yumyum.API.Controllers
{
    [Route("api/MealRatings")]
    [ApiController]
    public class MealRatingController : ControllerBase
    {
        private readonly IMealRatingService _mealRatingService;

        public MealRatingController(IMealRatingService mealRatingService)
        {
            _mealRatingService = mealRatingService;
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateMealRatingDto input)
        {
            var mealRating = await _mealRatingService.Create(input);
            return Ok(mealRating);

        }

        [HttpGet]
        public async Task<IActionResult> GetReating(int mealId)
        {
            var mealRatings = await _mealRatingService.GetMealRating(mealId);
            return Ok(mealRatings);

        }



    }
}
