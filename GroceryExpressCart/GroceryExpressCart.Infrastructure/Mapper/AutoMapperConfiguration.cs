using AutoMapper;
using GroceryExpressCart.Core.Domain;
using GroceryExpressCart.Infrastructure.DTO;

namespace GroceryExpressCart.Infrastructure.Mapper
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MemberShip, LoginUserFoundDTO>().
                ForMember(id => id.MemberShipId, dest => dest.MapFrom(map => map.Id)).
                ForMember(login => login.Login, dest => dest.MapFrom(map => map.Login.LoginValue)).
                ForMember(email => email.Email, dest => dest.MapFrom(map => map.Email.EmailValue));
                cfg.CreateMap<Meal, MealDTO>().ForMember(meal => meal.Meal, dest => dest.MapFrom(map => map.MealName)).
                ForMember(price => price.Price, dest => dest.MapFrom(map => map.Price.Money)).
                ForMember(img => img.Url, dest => dest.MapFrom(map => map.ImageDish.ImageDishValue));
                cfg.CreateMap<Meal, MealsDTO>().ForMember(meal => meal.Meal, dest => dest.MapFrom(map => map.MealName)).
               ForMember(price => price.Price, dest => dest.MapFrom(map => map.Price.Money)).
               ForMember(img => img.Url, dest => dest.MapFrom(map => map.ImageDish.ImageDishValue)).ForMember(id => id.Id, dest => dest.MapFrom(map => map.Id));
                cfg.CreateMap<Order, OrderMealDTO>().ForMember(meal => meal.Meal, dest => dest.MapFrom(map => map.Meal.MealName)).
                ForMember(prize => prize.Price, dest => dest.MapFrom(map => map.Meal.Price.Money));
            }).CreateMapper();

    }
}
