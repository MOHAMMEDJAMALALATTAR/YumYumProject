using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yumyum.Core.DTOs;
using Yumyum.Core.ViewModels;
using Yumyum.Data;
using Yumyum.Data.Models;

namespace Yumyum.Infrastructure.Services.MealRatings
{
    public class MealRatingService : IMealRatingService
    {
        private readonly YumyumDbContext _context;
        private readonly IMapper _mapper;

        public MealRatingService(YumyumDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateMealRatingDto> Create(CreateMealRatingDto dto)
        {
            var mealRating = _mapper.Map<MealRating>(dto);
            await _context.MealRatings.AddAsync(mealRating);
            await _context.SaveChangesAsync();
            return dto;
        }

        public async Task<int> GetMealRating (int mealId)
        {
            var mealRatings = await _context.MealRatings.Include(x => x.Meal)
                .Where(x => x.MealId == mealId).ToListAsync();
            var mealRatingVM = _mapper.Map<List<MealRatingViewModel>>(mealRatings);
            var ratingSum = mealRatingVM.Sum(x => x.Stars);
            var ratingCount = mealRatingVM.Count();
            var rating = ratingSum / ratingCount;
            return rating;
        }
    }
}
