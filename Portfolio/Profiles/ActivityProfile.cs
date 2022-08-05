namespace Portfolio.Profiles
{
    public class ActivityProfile : Profile
    {
        public ActivityProfile()
        {
            CreateMap<Activity, ActivityWithoutParentDto>();
            CreateMap<ActivityDescription, ActivityDescriptionWithoutParentDto>();
            CreateMap<ActivityLink, ActivityLinkWithoutParentDto>();
            CreateMap<ActivityType, ActivityTypeWithoutParentDto>();

            CreateMap<ActivityCreationDto, Activity>();
            CreateMap<ActivityDescriptionCreationDto, ActivityDescription>();
            CreateMap<ActivityLinkCreationDto, ActivityLink>();
            CreateMap<ActivityUpdateDto, Activity>();
            CreateMap<ActivityTypeCreationDto, ActivityType>();
            CreateMap<ActivityTypeUpdateDto, ActivityType>();
        }
    }
}
