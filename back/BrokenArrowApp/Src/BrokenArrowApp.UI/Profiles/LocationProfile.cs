using AutoMapper;
using BrokenArrowApp.Src.BrokenArrowApp.Common.DbSet;
using BrokenArrowApp.Src.BrokenArrowApp.Common.Dtos;

namespace BrokenArrowApp.Src.BrokenArrowApp.UI.Profiles
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
