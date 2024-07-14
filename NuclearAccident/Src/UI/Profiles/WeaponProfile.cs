using AutoMapper;
using NuclearIncident.Src.Common.DbSet;
using NuclearIncident.Src.Common.Dtos;

namespace NuclearIncident.Src.UI.Profiles
{
    public class WeaponProfile : Profile
    {
        public WeaponProfile()
        {
            CreateMap<Weapon, WeaponResponse>()
                .ForMember(dest => dest.Accidents, opt => opt.MapFrom(src => src.Accidents));

            CreateMap<Accident, AccidentShortResponse>();

        }
    }
}
