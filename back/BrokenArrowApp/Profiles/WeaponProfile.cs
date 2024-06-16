using AutoMapper;
using BrokenArrowApp.Models.Dtos.Responses;
using BrokenArrowApp.Models.Entities;

namespace BrokenArrowApp.Profiles
{
    public class WeaponProfile : Profile
    {
        public WeaponProfile()
        {
            CreateMap<Weapon, WeaponResponse>()
                .ForMember(dest => dest.BrokenArrows, opt => opt.MapFrom(src => src.BrokenArrows));

            CreateMap<BrokenArrow, BrokenArrowShortResponse>();

        }
    }
}
