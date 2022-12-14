using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yumyum.Core.DTOs;
using Yumyum.Core.ViewModels;

namespace Yumyum.Infrastructure.Services.MealRatings
{
    public interface IMealRatingService
    {
        Task<CreateMealRatingDto> Create(CreateMealRatingDto dto);
        Task<int> GetMealRating(int mealId);
    }
}
