using AutoMapper;
using core;
using TaskAPI.Dto;

namespace TaskAPI.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
