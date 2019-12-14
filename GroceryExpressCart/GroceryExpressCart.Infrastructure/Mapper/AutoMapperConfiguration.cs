using AutoMapper;
using GroceryExpressCart.Core.Domain;
using GroceryExpressCart.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;

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
            }).CreateMapper();
    }
}
