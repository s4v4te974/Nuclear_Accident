using AutoMapper;
using BrokenArrowApp.Models.Dtos.Responses;
using BrokenArrowApp.Models.Entities;

namespace BrokenArrowApp.MappingProfile
{
    public class DescriptionProfile : Profile
    {
        public DescriptionProfile()
        {
            CreateMap<Description, DescriptionResponse>()
                 .ForMember(dest => dest.BrokenArrowId,
                 src => src.MapFrom(b => b.BrokenArrow != null ? b.BrokenArrow.BrokenArrowId : (Guid?)null));

        }
    }
}