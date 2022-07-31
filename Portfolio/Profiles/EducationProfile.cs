using AutoMapper;

namespace Portfolio.Profiles
{
    public class EducationProfile: Profile
    {
        public EducationProfile()
        {
            CreateMap<Education, EducationWithoutParentDto>();
            CreateMap<EducationDescription, EducationDescriptionWithoutParentDto>();
        }
    }
}
