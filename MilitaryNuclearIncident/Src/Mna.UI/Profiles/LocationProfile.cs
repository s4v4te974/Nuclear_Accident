using AutoMapper;
using MilitaryNuclearAccident.Src.Mna.Common.DbSet;
using MilitaryNuclearAccident.Src.Mna.Common.Dtos;

namespace MilitaryNuclearAccident.Src.Mna.UI.Controllers.Profiles
{
    public class LocationProfile : Profile
    {
        public LocationProfile()
        {
            CreateMap<Location, LocationResponse>()
                .ForMember(dest => dest.BrokenArrow, opt => opt.MapFrom(src => src.BrokenArrow));

            CreateMap<BrokenArrow, BrokenArrowShortResponse>();
        }
    }
}
