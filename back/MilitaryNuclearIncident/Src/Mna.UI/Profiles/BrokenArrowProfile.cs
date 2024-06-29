using AutoMapper;
using MilitaryNuclearAccident.Src.Mna.Common.DbSet;
using MilitaryNuclearAccident.Src.Mna.Common.Dtos;

namespace MilitaryNuclearAccident.Src.Mna.UI.Controllers.Profiles
{
    public class BrokenArrowProfile : Profile
    {
        public BrokenArrowProfile()
        {

            CreateMap<BrokenArrow, BrokenArrowResponse>()
                .ForMember(dest => dest.LocationId, opt => opt.MapFrom(src => src.LocationId))
                .ForMember(dest => dest.FullDescriptionId, opt => opt.MapFrom(src => src.FullDescriptionId))
                .ForMember(dest => dest.VehiculeId, opt => opt.MapFrom(src => src.VehiculeId))
                .ForMember(dest => dest.WeaponId, opt => opt.MapFrom(src => src.WeaponId));
        }
    }
}