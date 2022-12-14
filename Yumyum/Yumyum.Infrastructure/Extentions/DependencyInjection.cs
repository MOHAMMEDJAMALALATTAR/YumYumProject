using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Yumyum.Data;
using Yumyum.Infrastructure.Logger;
using Yumyum.Infrastructure.Services.Auth;
using Yumyum.Infrastructure.Services.Categories;
using Yumyum.Infrastructure.Services.MealRatings;
using Yumyum.Infrastructure.Services.Meals;
using Yumyum.Infrastructure.Services.Orders;
using Yumyum.Infrastructure.Services.Users;
using YumyumInfrastructure.AutoMapper;

namespace Infrastructure.Extentions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataLayer(this IServiceCollection services, ConfigurationManager configurationManager)
        {
            services.AddDbContext<YumyumDbContext>(options =>
            {
                options.UseSqlServer(configurationManager.GetConnectionString("DefaultConnection"));
            });
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<ILoggerManager, LoggerManager>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IMealService, MealService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IMealRatingService, MealRatingService>();



            services.AddIdentityCore<ApplicationUser>(options =>
            {
                options.Password.RequiredUniqueChars = 1;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 1;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;

            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<YumyumDbContext>()
                .AddDefaultTokenProviders();
            return services;
        }
    }
}
