using AutoMapper;

namespace LimehouseStudios.Application.Mappers
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            this.CreateMap<Domain.Post, Application.Dtos.PostDto>();
        }
    }
}
