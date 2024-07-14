using AutoMapper;
using NuclearAccident.Src.Common.DbSet;
using NuclearAccident.Src.Common.Dtos;

namespace NuclearAccident.Src.UI.Profiles
{
    public class AccidentProfile : Profile
    {

        private readonly float _defautltCoordonate = 0.0f;
        public AccidentProfile()
        {
            CreateMap<Accident, AccidentResponse>()
                .ForPath(dest => dest.Vehicule.VehiculeId, opt => opt.MapFrom(src => src.Vehicule == null ? Guid.Empty : src.Vehicule.VehiculeId))
                .ForPath(dest => dest.Vehicule.Type, opt => opt.MapFrom(src => src.Vehicule == null ? string.Empty : src.Vehicule.Type))
                .ForPath(dest => dest.Vehicule.Builder, opt => opt.MapFrom(src => src.Vehicule == null ? string.Empty : src.Vehicule.Builder))
                .ForPath(dest => dest.Vehicule.Name, opt => opt.MapFrom(src => src.Vehicule == null ? string.Empty : src.Vehicule.Name))
                .ForPath(dest => dest.Vehicule.Description, opt => opt.MapFrom(src => src.Vehicule == null ? string.Empty : src.Vehicule.Description))
                .ForPath(dest => dest.Location.LocationId, opt => opt.MapFrom(src => src.Location == null ? Guid.Empty : src.Location.LocationId))
                .ForPath(dest => dest.Location.Country, opt => opt.MapFrom(src => src.Location == null ? string.Empty : src.Location.Country))
                .ForPath(dest => dest.Location.PositionLost, opt => opt.MapFrom(src => src.Location == null ? string.Empty : src.Location.PositionLost))
                .ForPath(dest => dest.Location.XCoordonate, opt => opt.MapFrom(src => src.Location == null ? _defautltCoordonate : src.Location.XCoordonate))
                .ForPath(dest => dest.Location.YCoordonate, opt => opt.MapFrom(src => src.Location == null ? _defautltCoordonate : src.Location.YCoordonate))
                .ForPath(dest => dest.Weapon.WeaponId, opt => opt.MapFrom(src => src.Weapon == null ? Guid.Empty : src.Weapon.WeaponId))
                .ForPath(dest => dest.Weapon.Name, opt => opt.MapFrom(src => src.Weapon == null ? string.Empty : src.Weapon.Name))
                .ForPath(dest => dest.Weapon.Builder, opt => opt.MapFrom(src => src.Weapon == null ? string.Empty : src.Weapon.Builder))
                .ForPath(dest => dest.Weapon.Description, opt => opt.MapFrom(src => src.Weapon == null ? string.Empty : src.Weapon.Description));
        }
    }
}

/*
 *  {
            CreateMap<Accident, AccidentResponse>()
                .ForMember(dest => dest.Vehicule != null ? dest.Vehicule.VehiculeId : Guid.Empty, opt => opt.MapFrom(src => src.Vehicule == null ? Guid.Empty : src.Vehicule.VehiculeId))
                .ForMember(dest => dest.Vehicule != null ? dest.Vehicule.Type : string.Empty, opt => opt.MapFrom(src => src.Vehicule == null ? string.Empty : src.Vehicule.Type))
                .ForMember(dest => dest.Vehicule != null ? dest.Vehicule.Builder : string.Empty, opt => opt.MapFrom(src => src.Vehicule == null ? string.Empty : src.Vehicule.Builder))
                .ForMember(dest => dest.Vehicule != null ? dest.Vehicule.Name : string.Empty, opt => opt.MapFrom(src => src.Vehicule == null ? string.Empty : src.Vehicule.Name))
                .ForMember(dest => dest.Vehicule != null ? dest.Vehicule.Description : string.Empty, opt => opt.MapFrom(src => src.Vehicule == null ? string.Empty : src.Vehicule.Description))
                .ForMember(dest => dest.Location.LocationId : Guid.Empty, opt => opt.MapFrom(src => src.Location == null ? Guid.Empty : src.Location.LocationId))
                .ForMember(dest => dest.Location.Country : string.Empty, opt => opt.MapFrom(src => src.Location == null ? string.Empty : src.Location.Country))
                .ForMember(dest => dest.Location.PositionLost : string.Empty, opt => opt.MapFrom(src => src.Location == null ? string.Empty : src.Location.PositionLost))
                .ForMember(dest => dest.Location.XCoordonate : _defautltCoordonate, opt => opt.MapFrom(src => src.Location == null ? _defautltCoordonate : src.Location.XCoordonate))
                .ForMember(dest => dest.Location.YCoordonate : _defautltCoordonate, opt => opt.MapFrom(src => src.Location == null ? _defautltCoordonate : src.Location.YCoordonate))
                .ForMember(dest => dest.Weapon.WeaponId : Guid.Empty, opt => opt.MapFrom(src => src.Weapon == null ? Guid.Empty : src.Weapon.WeaponId))
                .ForMember(dest => dest.Weapon.Name : string.Empty, opt => opt.MapFrom(src => src.Weapon == null ? string.Empty : src.Weapon.Name))
                .ForMember(dest => dest.Weapon.Builder : string.Empty, opt => opt.MapFrom(src => src.Weapon == null ? string.Empty : src.Weapon.Builder))
                .ForMember(dest => dest.Weapon.Description : string.Empty, opt => opt.MapFrom(src => src.Weapon == null ? string.Empty : src.Weapon.Description));
        }
 */
