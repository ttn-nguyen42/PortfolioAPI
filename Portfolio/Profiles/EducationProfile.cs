using AutoMapper;
using Portfolio.Entities;
using Portfolio.Models.Gets;

namespace Portfolio.Profiles
{
    public class EducationProfile: Profile
    {
        public EducationProfile()
        {
            CreateMap<Education, EducationDto>();
        }
    }
}
