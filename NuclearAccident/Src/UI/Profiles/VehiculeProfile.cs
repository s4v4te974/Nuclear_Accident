using AutoMapper;
using NuclearIncident.Src.Common.DbSet;
using NuclearIncident.Src.Common.Dtos;

namespace NuclearIncident.Src.UI.Profiles
{
    public class VehiculeProfile : Profile
    {
        public VehiculeProfile()
        {
            CreateMap<Vehicule, VehiculeResponse>()
                 .ForMember(dest => dest.Accidents, opt => opt.MapFrom(src => src.Accidents));

            CreateMap<Accident, AccidentShortResponse>();
        }
    }
}
