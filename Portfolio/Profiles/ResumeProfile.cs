using AutoMapper;

namespace Portfolio.Profiles
{
    public class ResumeProfile : Profile
    {
        public ResumeProfile()
        {
            CreateMap<Resume, ResumeDto>();
            CreateMap<Resume, InfoDto>();
            CreateMap<PersonalLink, PersonalLinkWithoutParentDto>();
            CreateMap<Resume, ResumeWithInfoAndAboutDto>();
            CreateMap<ResumeCreationDto, Resume>();
            CreateMap<ResumeUpdateDto, Resume>();
            CreateMap<Resume, AboutDto>();
            CreateMap<PersonalLinkCreationDto, PersonalLink>();
        }
    }
}
