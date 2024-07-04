using AutoMapper;
using NuclearAccident.Src.Common.DbSet;
using NuclearAccident.Src.Common.Dtos;

namespace NuclearAccident.Src.UI.Controllers.Profiles
{
    public class LocationProfile : Profile
    {
        public LocationProfile()
        {
            CreateMap<Location, LocationResponse>()
                .ForMember(dest => dest.Accident, opt => opt.MapFrom(src => src.Accident));

            CreateMap<Accident, AccidentShortResponse>();
        }
    }
}
