using AutoMapper;
using NuclearIncident.Src.Common.DbSet;
using NuclearIncident.Src.Common.Dtos;
using NuclearIncident.Src.Common.Dtos.BrokenArrow;

namespace NuclearIncident.Src.UI.Profiles
{
    public class VehiculeProfile : Profile
    {
        public VehiculeProfile()
        {
            CreateMap<Vehicule, VehiculeResponse>()
                 .ForMember(dest => dest.BrokenArrowss, opt => opt.MapFrom(src => src.BrokenArrows));

            CreateMap<BrokenArrow, BrokenArrowShortResponse>();
        }
    }
}
