using AutoMapper;
using DomainLayer.Model;
using DomainLayer.ViewModel.Product;

namespace API.Mapper
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<ProductRequestDTO, Product>()
                .ForMember(
                    res => res.Name,
                    opt => opt.MapFrom(src => $"{src.Name }"))
                .ForMember(
                    res => res.Provider,
                    opt => opt.MapFrom(src => $"{src.Provider }"))
                .ForMember(
                    res => res.CategoryID,
                    opt => opt.MapFrom(src => $"{src.CategoryID }"))
                .ForMember(
                    res => res.Image,
                    opt => opt.MapFrom(src => $"{src.Image }"));
            CreateMap<Product,ProductResponseDTO>()
                .ForMember(
                    res => res.Name,
                    opt => opt.MapFrom(src => $"{src.Name }"))
                .ForMember(
                    res => res.Provider,
                    opt => opt.MapFrom(src => $"{src.Provider }"))
                .ForMember(
                    res => res.CategoryName,
                    opt => opt.MapFrom(src => $"{src.Category.CategoryName }"))
                .ForMember(
                    res => res.Image,
                    opt => opt.MapFrom(src => $"{src.Image }"));
        }
    }
}
