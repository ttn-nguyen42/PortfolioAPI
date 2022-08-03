using AutoMapper;

namespace Portfolio.Profiles
{
    public class VolunteeringProfile: Profile
    {
        public VolunteeringProfile()
        {
            CreateMap<Volunteering, VolunteeringWithoutParentDto>();
            CreateMap<VolunteeringDescription, VolunteeringDescriptionWithoutParentDto>();
            CreateMap<VolunteeringCreationDto, Volunteering>();
            CreateMap<VolunteeringUpdateDto, Volunteering>();
            CreateMap<VolunteeringDescriptionCreationDto, VolunteeringDescription>();
        }
    }
}
