using AutoMapper;
using Ecommerce.Model.Entities;

namespace Ecommerce.Api.ViewModels.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CategoryViewModel, Category>();
            CreateMap<ProductViewModel, Product>();
        }
    }
}
