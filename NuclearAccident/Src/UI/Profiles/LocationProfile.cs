using AutoMapper;
using NuclearIncident.Src.Common.DbSet;
using NuclearIncident.Src.Common.Dtos;

namespace NuclearIncident.Src.UI.Profiles
{
    public class LocationProfile : Profile
    {
        public LocationProfile()
        {
            CreateMap<Location, LocationResponse>()
                .ForMember(dest => dest.BrokenArrows, opt => opt.MapFrom(src => src.Accidents));

            CreateMap<Accident, AccidentShortResponse>();
        }
    }
}
