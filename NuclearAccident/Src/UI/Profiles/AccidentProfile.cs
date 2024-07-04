using AutoMapper;
using NuclearAccident.Src.Common.DbSet;
using NuclearAccident.Src.Common.Dtos;

namespace NuclearAccident.Src.UI.Controllers.Profiles
{
    public class AccidentProfile : Profile
    {
        public AccidentProfile()
        {

            CreateMap<Accident, AccidentResponse>()
                .ForMember(dest => dest.LocationId, opt => opt.MapFrom(src => src.LocationId))
                .ForMember(dest => dest.VehiculeId, opt => opt.MapFrom(src => src.VehiculeId))
                .ForMember(dest => dest.WeaponId, opt => opt.MapFrom(src => src.WeaponId));
        }
    }
}