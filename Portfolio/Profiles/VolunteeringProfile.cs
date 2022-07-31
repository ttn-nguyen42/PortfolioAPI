using AutoMapper;

namespace Portfolio.Profiles
{
    public class VolunteeringProfile: Profile
    {
        VolunteeringProfile()
        {
            CreateMap<Volunteering, VolunteeringWithoutParentDto>();
            CreateMap<VolunteeringDescription, VolunteeringDescriptionWithoutParentDto>();
        }
    }
}
