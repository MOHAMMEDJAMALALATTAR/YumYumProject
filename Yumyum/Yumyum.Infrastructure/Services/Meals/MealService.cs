using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Yumyum.Core.DTOs;
using Yumyum.Core.Exceptions;
using Yumyum.Core.ViewModels;
using Yumyum.Data;
using Yumyum.Data.Models;

namespace Yumyum.Infrastructure.Services.Meals
{
    public class MealService : IMealService
    {
        private readonly YumyumDbContext _context;
        private readonly IMapper _mapper;

        public MealService(YumyumDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        public async Task<List<MealViewModel>> GetAll()
        {
            var meals = await _context.Meals.Include(x => x.Category).ToListAsync();
            var mealss =  _mapper.Map<List<MealViewModel>>(meals);

            return mealss;
        }

        public async Task<CreateMealDto> Create(CreateMealDto dto)
        {
            var meal = _mapper.Map<Meal>(dto);
            await _context.Meals.AddAsync(meal);
            await _context.SaveChangesAsync();
            return dto;
        }

        public async Task<int> Update(UpdateMealDto dto)
        {
            var meal = await _context.Meals.SingleOrDefaultAsync(x => x.Id == dto.Id);
            if (meal == null)
            {
                throw new NotFoundException();
            }
            var updatedMeal = _mapper.Map(dto, meal);
            _context.Meals.Update(updatedMeal);
            await _context.SaveChangesAsync();
            return meal.Id;
        }

        public async Task<int> Delete(int id)
        {
            var meal = await _context.Meals.FindAsync(id);
            if (meal == null)
            {
                throw new NotFoundException();
            }
            _context.Meals.Remove(meal);
            _context.SaveChanges();
            return meal.Id;
        }

    }
}
