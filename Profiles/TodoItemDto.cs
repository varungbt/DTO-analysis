using AutoMapper;
using TodoApi.Models;

namespace TodoApi.Profiles
{
    public class TodoItemProfile : Profile
    {
        public TodoItemProfile() {

            CreateMap<TodoItemDto, TodoItem>()
            .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.TodoItemName))
            .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => System.Guid.NewGuid())
            );

            CreateMap<TodoItemDto, string>().ConvertUsing(src => src.TodoItemName + " = new ToDoItem() cmd to backend");
        }
    }
}
