namespace Portfolio.Models
{
    public class ProjectWithoutParentDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }

        public string Team { get; set; }

        public string Overview { get; set; }

        public ICollection<ProjectDescriptionDto> Descriptions { get; set; } = new List<ProjectDescriptionDto>();

        public ICollection<ProjectLinkDto> Links { get; set; } = new List<ProjectLinkDto>();

        public ProjectTypeDto? Type { get; set; }

        public ProjectWithoutParentDto(int id, string name, string role, string team, string overview)
        {
            Id = id;
            Name = name;
            Role = role;
            Team = team;
            Overview = overview;
        }
    }

    public class ProjectCreationDto
    {

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Role { get; set; }

        [Required]
        [MaxLength(150)]
        public string Team { get; set; }

        [Required]
        [MaxLength(300)]
        public string Overview { get; set; }

        public ICollection<ProjectDescriptionCreationDto> Descriptions { get; set; } = new List<ProjectDescriptionCreationDto>();

        public ICollection<ProjectLinkCreationDto> Links { get; set; } = new List<ProjectLinkCreationDto>();

        public int TypeId { get; set; }

        public ProjectCreationDto(int typeId, string name, string role, string team, string overview)
        { 
            TypeId = typeId;
            Name = name;
            Role = role;
            Team = team;
            Overview = overview;
        }
    }

    public class ProjectUpdateDto
    {

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Role { get; set; }

        [Required]
        [MaxLength(150)]
        public string Team { get; set; }

        [Required]
        [MaxLength(300)]
        public string Overview { get; set; }

        public ICollection<ProjectDescriptionCreationDto> Descriptions { get; set; } = new List<ProjectDescriptionCreationDto>();

        public ICollection<ProjectLinkCreationDto> Links { get; set; } = new List<ProjectLinkCreationDto>();

        public int TypeId { get; set; }

        public ProjectUpdateDto(int typeId, string name, string role, string team, string overview)
        {
            TypeId = typeId;
            Name = name;
            Role = role;
            Team = team;
            Overview = overview;
        }
    }

    public class ProjectDescriptionDto
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public ProjectDescriptionDto(int id, string description)
        {
            Id = id;
            Description = description;
        }
    }

    public class ProjectDescriptionCreationDto
    {
        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        public ProjectDescriptionCreationDto(string description)
        {
            Description = description;
        }
    }

    public class ProjectTypeDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ProjectTypeDto(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    public class ProjectTypeCreationDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public ProjectTypeCreationDto(string name)
        {
            Name = name;
        }
    }

    public class ProjectTypeUpdateDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public ProjectTypeUpdateDto(string name)
        {
            Name = name;
        }
    }

    public class ProjectLinkDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Link { get; set; }

        public ProjectLinkDto(int id, string name, string link)
        {
            Id = id;
            Name = name;
            Link = link;
        }
    }

    public class ProjectLinkCreationDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(300)]
        public string Link { get; set; }

        public ProjectLinkCreationDto(string name, string link)
        {
            Name = name;
            Link = link;
        }
    }
}
