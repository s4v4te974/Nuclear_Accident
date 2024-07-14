using AutoMapper;
using NuclearIncident.Src.Common.DbSet;
using NuclearIncident.Src.Common.Dtos;
using NuclearIncident.Src.Common.Dtos.BrokenArrow;

namespace NuclearIncident.Src.UI.Profiles
{
    public class WeaponProfile : Profile
    {
        public WeaponProfile()
        {
            CreateMap<Weapon, WeaponResponse>()
                .ForMember(dest => dest.BrokenArrowss, opt => opt.MapFrom(src => src.BrokenArrows));

            CreateMap<BrokenArrow, BrokenArrowShortResponse>();

        }
    }
}
