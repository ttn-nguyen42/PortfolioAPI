namespace Portfolio.Models
{
    public class ActivityWithoutParentDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Organizer { get; set; }

        public int TypeId { get; set; }

        public ICollection<ActivityDescriptionWithoutParentDto> Descriptions = new List<ActivityDescriptionWithoutParentDto>();

        public ICollection<ActivityLinkWithoutParentDto> Links { get; set; } = new List<ActivityLinkWithoutParentDto>();

        public ActivityTypeWithoutParentDto? Type { get; set; }

        public ActivityWithoutParentDto(int id, string name, string organizer, int typeId, ActivityTypeWithoutParentDto? type)
        {
            Id = id;
            Name = name;
            Organizer = organizer;
            TypeId = typeId;
            Type = type;
        }
    }

    public class ActivityCreationDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(150)]
        public string Organizer { get; set; }

        [Required]
        [MaxLength(200)]
        public string Overview { get; set; }

        public ICollection<ActivityDescriptionCreationDto> Descriptions { get; set; } = new List<ActivityDescriptionCreationDto>();

        public int TypeId { get; set; }

        public ICollection<ActivityLinkCreationDto> Links { get; set; } = new List<ActivityLinkCreationDto>();

        public ActivityCreationDto(string name, string organizer, string overview, int typeId)
        {
            Name = name;
            Organizer = organizer;
            Overview = overview;
            TypeId = typeId;
        }
    }

    public class ActivityUpdateDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(150)]
        public string Organizer { get; set; }

        [Required]
        [MaxLength(200)]
        public string Overview { get; set; }

        public ICollection<ActivityDescriptionCreationDto> Descriptions { get; set; } = new List<ActivityDescriptionCreationDto>();

        public int TypeId { get; set; }

        public ICollection<ActivityLinkCreationDto> Links { get; set; } = new List<ActivityLinkCreationDto>();

        public ActivityUpdateDto(string name, string organizer, string overview, int typeId)
        {
            Name = name;
            Organizer = organizer;
            Overview = overview;
            TypeId = typeId;
        }
    }

    public class ActivityTypeWithoutParentDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ActivityTypeWithoutParentDto(string name)
        {
            Name = name;
        }
    }

    public class ActivityTypeCreationDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public ActivityTypeCreationDto(string name)
        {
            Name = name;
        }
    }

    public class ActivityTypeUpdateDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public ActivityTypeUpdateDto(string name)
        {
            Name = name;
        }
    }

    public class ActivityDescriptionWithoutParentDto
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public ActivityDescriptionWithoutParentDto(int id, string description)
        {
            Id = id;
            Description = description;
        }
    }

    public class ActivityDescriptionCreationDto
    {
        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        public ActivityDescriptionCreationDto(string description)
        {
            Description = description;
        }
    }

    public class ActivityLinkWithoutParentDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Link { get; set; }

        public ActivityLinkWithoutParentDto(int id, string name, string link)
        {
            Id = id;
            Name = name;
            Link = link;
        }
    }

    public class ActivityLinkCreationDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(300)]
        public string Link { get; set; }

        public ActivityLinkCreationDto(string name, string link)
        {
            Name = name;
            Link = link;
        }
    }

}
