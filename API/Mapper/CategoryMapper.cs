using AutoMapper;
using DomainLayer.Model;
using DomainLayer.ViewModel;
using DomainLayer.ViewModel.Category;

namespace API.Mapper
{
    public class CategoryMapper:Profile
    {
        public CategoryMapper()
        {
            CreateMap<CategoryRequestDTO, Category>()
                .ForMember(
                res => res.CategoryID,
                opt => opt.MapFrom(src => $"{src.CategoryID }"))
                .ForMember(
                res => res.CategoryName,
                opt => opt.MapFrom(src => $"{src.CategoryName}"));
            CreateMap<Category,CategoryResponseDTO > ()
                .ForMember(
                res => res.CategoryID,
                opt => opt.MapFrom(src => $"{src.CategoryID }"))
                .ForMember(
                res => res.CategoryName,
                opt => opt.MapFrom(src => $"{src.CategoryName}"));
        }
    }
}
