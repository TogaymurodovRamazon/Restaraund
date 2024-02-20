using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Restaran.Domain.Entitys.Foods;
using Restaran.Domain.Entitys.Users;
using Restaran.Service.DTOs;

namespace Restaraund.Configurations
{
    public class MapConfiguration : Profile
    {
        public MapConfiguration()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Food, FoodDTO>().ReverseMap();
        }
    }
}
