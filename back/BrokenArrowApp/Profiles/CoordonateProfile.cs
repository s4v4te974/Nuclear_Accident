using AutoMapper;
using BrokenArrowApp.Models.Dtos.Responses;
using BrokenArrowApp.Models.Entities;

namespace BrokenArrowApp.MappingProfile
{
    public class CoordonateProfile : Profile
    {
        public CoordonateProfile()
        {
            CreateMap<Coordonate, CoordonateResponse>()
                .ForMember(dest => dest.BrokenArrow, opt => opt.MapFrom(src => src.BrokenArrow));

            CreateMap<BrokenArrow, BrokenArrowShortResponse>();
        }
    }
}
