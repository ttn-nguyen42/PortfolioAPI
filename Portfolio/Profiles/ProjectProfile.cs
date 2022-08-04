namespace Portfolio.Profiles
{
    public class ProjectProfile: Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project, ProjectWithoutParentDto>();
            CreateMap<ProjectDescription, ProjectDescriptionDto>();
            CreateMap<ProjectType, ProjectTypeDto>();
            CreateMap<ProjectLink, ProjectLinkDto>();

            CreateMap<ProjectCreationDto, Project>();
            CreateMap<ProjectDescriptionCreationDto, ProjectDescription>();
            CreateMap<ProjectTypeCreationDto, ProjectType>();
            CreateMap<ProjectLinkCreationDto, ProjectLink>();

            CreateMap<ProjectUpdateDto, Project>();
            CreateMap<ProjectTypeUpdateDto, ProjectType>();
        }
    }
}
