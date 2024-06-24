using AutoMapper;
using BrokenArrowApp.Src.BrokenArrowApp.Common.DbSet;
using BrokenArrowApp.Src.BrokenArrowApp.Common.Dtos;

namespace BrokenArrowApp.Src.BrokenArrowApp.UI.Profiles
{
    public class BrokenArrowProfile : Profile
    {
        public BrokenArrowProfile()
        {

            CreateMap<BrokenArrow, BrokenArrowResponse>()
                .ForMember(dest => dest.CoordonateId, opt => opt.MapFrom(src => src.LocationId))
                .ForMember(dest => dest.FullDescriptionId, opt => opt.MapFrom(src => src.FullDescriptionId))
                .ForMember(dest => dest.VehiculeId, opt => opt.MapFrom(src => src.VehiculeId))
                .ForMember(dest => dest.WeaponId, opt => opt.MapFrom(src => src.WeaponId));
        }
    }
}