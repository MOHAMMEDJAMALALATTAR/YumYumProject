using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Yumyum.Core.DTOs;
using Yumyum.Core.Exceptions;
using Yumyum.Core.ViewModels;
using Yumyum.Data;
using Yumyum.Data.Models;

namespace Yumyum.Infrastructure.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly YumyumDbContext _contex;
        private readonly IMapper _mapper;

        public CategoryService(YumyumDbContext contex, IMapper mapper)
        {
            _contex = contex;
            _mapper = mapper;
        }


       
        public async Task<List<CategoryViewModel>> GetAll(string? serachKey)
        {
            var categories = await _contex.Categories.Where(x => x.Name.Contains(serachKey)
            || string.IsNullOrEmpty(serachKey)).Select(x => new CategoryViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
            }).ToListAsync();
               return categories;
        }
        
        public async Task<CreateCategoryDto> Create(CreateCategoryDto dto)
        {
            var category =  _mapper.Map<Category>(dto);
            await _contex.Categories.AddAsync(category);
            await _contex.SaveChangesAsync();
            return dto;
        }

        public async Task<int> Update ( UpdateCategoryDto dto)
        {
            var category = await _contex.Categories.SingleOrDefaultAsync(x => x.Id == dto.Id);
            if (category == null)
            {
                throw new NotFoundException();
            }
            var updatedCategory = _mapper.Map(dto, category);
            _contex.Categories.Update(updatedCategory);
            await _contex.SaveChangesAsync();
            return category.Id;
        }

        public  async Task<int> Delete(int id)
        {
            var category = await _contex.Categories.FindAsync(id);
            if (category == null)
            {
                throw new NotFoundException();
            }
            _contex.Categories.Remove(category);
            _contex.SaveChanges();
            return category.Id;
        }


    }
}
