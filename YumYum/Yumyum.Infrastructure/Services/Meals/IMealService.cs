using Microsoft.AspNetCore.Mvc;
using Yumyum.Core.DTOs;
using Yumyum.Core.RequestFeatures;
using Yumyum.Core.ViewModels;

namespace Yumyum.Infrastructure.Services.Meals
{
    public interface IMealService
    {
        Task<List<MealViewModel>> GetAll();
        Task<CreateMealDto> Create(CreateMealDto dto);
        Task<int> Update(UpdateMealDto dto);
        Task<int> Delete(int id);
        Task<List<MealViewModel>> GetAllPage([FromQuery]
         MealParameters mealParameters);
    }
}
