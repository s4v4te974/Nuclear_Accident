using AutoMapper;
using NuclearAccident.Src.Common.DbSet;
using NuclearAccident.Src.Common.Dtos;

namespace NuclearAccident.Src.UI.Profiles
{
    public class LocationProfile : Profile
    {
        public LocationProfile()
        {
            CreateMap<Location, LocationResponse>()
                .ForMember(dest => dest.BrokenArrows, opt => opt.MapFrom(src => src.BrokenArrows));

            CreateMap<Accident, BrokenArrowsShortResponse>();
        }
    }
}
