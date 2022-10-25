using AutoMapper;
using GapUp.Domain.Entites;
using GapUp.Services.DTO_s;

namespace GapUp.Services.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductViewModel>().ReverseMap();
        }
    }
}
