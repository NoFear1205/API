using AutoMapper;
using DomainLayer.Model;
using DomainLayer.ViewModel;

namespace API.Mapper
{
    public class RoleMapper : Profile
    {
        public RoleMapper()
        {
            CreateMap<Role, RoleDTO>()
                .ForMember(
                    res => res.RoleName,
                    opt => opt.MapFrom(src => $"{src.RoleName }"))
                .ForMember(
                    res => res.Description,
                    opt => opt.MapFrom(src => $"{src.Description }"));
            CreateMap<RoleDTO, Role>()
                .ForMember(
                    res => res.RoleName,
                    opt => opt.MapFrom(src => $"{src.RoleName }"))
                .ForMember(
                    res => res.Description,
                    opt => opt.MapFrom(src => $"{src.Description }"));
        }
    }
}
