using AutoMapper;
using Data.Models;
using Yumyum.Core.DTOs;
using Yumyum.Core.ViewModels;
using Yumyum.Data.Models;

namespace YumyumInfrastructure.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
           {

            CreateMap<MealRating, MealRatingViewModel>();
            CreateMap<CreateMealRatingDto, MealRating>();
          
            CreateMap<Category, CategoryViewModel>();
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();
            CreateMap<Category, UpdateCategoryDto>();

            CreateMap<Meal, MealViewModel>();
            CreateMap<CreateMealDto, Meal>().ForMember(x => x.ImageUrl, x => x.Ignore()); 
            CreateMap<UpdateMealDto, Meal>();
            CreateMap<Meal, UpdateMealDto>();

            CreateMap<Order, OrderViewModel>();
            CreateMap<CreateOrderDto, Order>();
            CreateMap<UpdateOrderDto, Order>();
            CreateMap<Order, UpdateOrderDto>();


            CreateMap<RegisterRequestDto, ApplicationUser>()
                .ForMember(x => x.ImageUrl, x => x.Ignore())
                .ForMember(x => x.SecurityStamp, x => x.Ignore());
            CreateMap<ApplicationUser, ApplicationUserViewModel>()
                .ForMember(x => x.UserType, x => x.MapFrom(x => x.UserType.ToString()));






        }


    }
}
