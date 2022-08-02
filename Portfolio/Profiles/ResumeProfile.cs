using AutoMapper;

namespace Portfolio.Profiles
{
    public class ResumeProfile : Profile
    {
        public ResumeProfile()
        {
            CreateMap<Resume, ResumeDto>();
            CreateMap<Resume, InfoDto>();
            CreateMap<Resume, AboutDto>();
            CreateMap<PersonalLink, PersonalLinkWithoutParentDto>();
            CreateMap<Resume, ResumeWithInfoAndAboutDto>();
            CreateMap<ResumeCreationDto, Resume>();
        }
    }
}
