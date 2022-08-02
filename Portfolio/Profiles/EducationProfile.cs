using AutoMapper;

namespace Portfolio.Profiles
{
    public class EducationProfile: Profile
    {
        public EducationProfile()
        {
            CreateMap<Education, EducationWithoutParentDto>();
            CreateMap<EducationDescription, EducationDescriptionWithoutParentDto>();
            CreateMap<EducationCreationDto, Education>();
            CreateMap<EducationUpdateDto, Education>();
            CreateMap<EducationDescriptionCreationDto, EducationDescription>();
        }
    }
}
