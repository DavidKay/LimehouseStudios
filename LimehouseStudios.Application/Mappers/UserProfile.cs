using AutoMapper;

namespace LimehouseStudios.Application.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            this.CreateMap<Domain.User, Application.Dtos.UserDto>();
        }
    }
}
