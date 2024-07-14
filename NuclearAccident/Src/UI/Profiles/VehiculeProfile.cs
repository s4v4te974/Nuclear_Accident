using AutoMapper;
using NuclearAccident.Src.Common.DbSet;
using NuclearAccident.Src.Common.Dtos;

namespace NuclearAccident.Src.UI.Profiles
{
    public class VehiculeProfile : Profile
    {
        public VehiculeProfile()
        {
            CreateMap<Vehicule, VehiculeResponse>()
                 .ForMember(dest => dest.Accidents, opt => opt.MapFrom(src => src.Accidents));

            CreateMap<Accident, BrokenArrowsShortResponse>();
        }
    }
}
