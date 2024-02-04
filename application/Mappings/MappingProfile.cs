using application.Features.Product.Commands;
using AutoMapper;

namespace application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<CreateProductCommand, Domain.Entities.Product>();
        }
    }
}
