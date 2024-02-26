using AutoMapper;
using ToDoList.Application.Models.DTOs;
using ToDoList.Infra.Data.Identity;

namespace ToDoList.Infra.Data.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<ApplicationUser, ApplicationUserDto>().ReverseMap();
        }
    }
}