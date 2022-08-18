using AutoMapper;

namespace Portfolio.Profiles
{
    public class ExperienceProfile : Profile
    {
        public ExperienceProfile()
        {
            CreateMap<Experience, ExperienceWithoutParentDto>();
            CreateMap<ExperienceDescription, ExperienceDescriptionWithoutParentDto>();
            CreateMap<ExperienceCreationDto, Experience>();
            CreateMap<ExperienceDescriptionCreationDto, ExperienceDescription>();
            CreateMap<ExperienceUpdateDto, Experience>();
        }
    }
}
