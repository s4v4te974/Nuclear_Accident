using AutoMapper;
using BrokenArrowApp.Models.Dtos;
using BrokenArrowApp.Models.Entities;

namespace BrokenArrowApp.Profiles
{
    public class VehiculeProfile : Profile
    {
        public VehiculeProfile()
        {
            CreateMap<Vehicule, VehiculeResponse>()
                 .ForMember(dest => dest.BrokenArrows, opt => opt.MapFrom(src => src.BrokenArrows));

            CreateMap<BrokenArrow, BrokenArrowShortResponse>();
        }

    }
}
