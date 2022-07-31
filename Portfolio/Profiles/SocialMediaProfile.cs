using AutoMapper;
using Portfolio.Entities;
using Portfolio.Models.Gets;

namespace Portfolio.Profiles
{
    public class SocialMediaProfile: Profile
    {
        public SocialMediaProfile()
        {
            CreateMap<SocialMedia, SocialMediaDto>();
        }
    }
}
