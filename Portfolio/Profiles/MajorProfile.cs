using AutoMapper;
using Portfolio.Entities;
using Portfolio.Models.Gets;

namespace Portfolio.Profiles
{
    public class MajorProfile: Profile
    {
        public MajorProfile()
        {
            CreateMap<Major, MajorDto>();
        }
    }
}
