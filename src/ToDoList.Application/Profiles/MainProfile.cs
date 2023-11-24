using AutoMapper;
using ToDoList.Application.Models.DTOs;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.Profiles
{
    public class MainProfile : Profile
    {
        public MainProfile()
        {
            CreateMap<Card, CardDto>().ReverseMap();
            CreateMap<CheckList, CheckListDto>().ReverseMap();
            CreateMap<Item, ItemDto>().ReverseMap();
        }
    }
}