using AutoMapper;
using BrokenArrowApp.Models.Dtos.Responses;
using BrokenArrowApp.Models.Entities;

namespace BrokenArrowApp.MappingProfile
{
    public class BrokenArrowProfile : Profile
    {
        public BrokenArrowProfile()
        {

            CreateMap<BrokenArrow, BrokenArrowResponse>()
                .ForMember(dest => dest.CoordonateId, opt => opt.MapFrom(src => src.CoordonateId))
                .ForMember(dest => dest.FullDescriptionId, opt => opt.MapFrom(src => src.FullDescriptionId))
                .ForMember(dest => dest.VehiculeId, opt => opt.MapFrom(src => src.VehiculeId))
                .ForMember(dest => dest.WeaponId, opt => opt.MapFrom(src => src.WeaponId));
        }
    }
}