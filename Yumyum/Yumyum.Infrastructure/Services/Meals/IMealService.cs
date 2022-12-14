using Yumyum.Core.DTOs;
using Yumyum.Core.ViewModels;

namespace Yumyum.Infrastructure.Services.Meals
{
    public interface IMealService
    {
        Task<List<MealViewModel>> GetAll();
        Task<CreateMealDto> Create(CreateMealDto dto);
        Task<int> Update(UpdateMealDto dto);
        Task<int> Delete(int id);
    }
}
