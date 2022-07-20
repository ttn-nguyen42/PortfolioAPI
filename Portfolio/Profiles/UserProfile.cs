using AutoMapper;
using Portfolio.Entities;
using Portfolio.Models.Gets;

namespace Portfolio.Profiles
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}
