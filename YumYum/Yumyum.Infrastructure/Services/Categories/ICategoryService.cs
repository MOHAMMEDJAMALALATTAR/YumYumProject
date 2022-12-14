using Yumyum.Core.DTOs;
using Yumyum.Core.ViewModels;

namespace Yumyum.Infrastructure.Services.Categories
{
    public interface ICategoryService
    {
        Task<List<CategoryViewModel>> GetAll(string serachKey);
        Task<CreateCategoryDto> Create(CreateCategoryDto dto);
        Task<int> Update( UpdateCategoryDto dto);
        Task<int> Delete(int id);
    }
}
