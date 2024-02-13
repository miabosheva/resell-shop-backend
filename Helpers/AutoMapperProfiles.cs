using AutoMapper;
using backend_resell_app.Data.Dto;
using backend_resell_app.Models;

namespace backend_resell_app.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Product, ProductListDto>()
                .ForMember(d => d.ProductType, opt => opt.MapFrom(src => src.ProductType.Name))
                .ForMember(d => d.ConditionType, opt => opt.MapFrom(src => src.ConditionType.Name));
        }
    }
}
