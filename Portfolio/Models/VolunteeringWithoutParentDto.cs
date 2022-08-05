namespace Portfolio.Models
{
    public class VolunteeringWithoutParentDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Organization { get; set; }

        public DateTime From { get; set; }

        public DateTime? To { get; set; }

        public ICollection<VolunteeringDescriptionWithoutParentDto> Descriptions { get; set; } = new List<VolunteeringDescriptionWithoutParentDto>();

        public VolunteeringWithoutParentDto(string title, string organization, DateTime from)
        {
            Title = title;
            Organization = organization;
            From = from;
        }
    }

    public class VolunteeringDescriptionWithoutParentDto
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public VolunteeringDescriptionWithoutParentDto(string description)
        {
            Description = description;
        }
    }

    public class VolunteeringCreationDto
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(150)]
        public string Organization { get; set; }

        public DateTime From { get; set; }

        public DateTime? To { get; set; }

        public ICollection<VolunteeringDescriptionCreationDto> Descriptions { get; set; } = new List<VolunteeringDescriptionCreationDto>();

        public VolunteeringCreationDto(string title, string organization, DateTime from)
        {
            Title = title;
            Organization = organization;
            From = from;
        }
    }

    public class VolunteeringUpdateDto
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(150)]
        public string Organization { get; set; }

        public DateTime From { get; set; }

        public DateTime? To { get; set; }

        public ICollection<VolunteeringDescriptionCreationDto> Descriptions { get; set; } = new List<VolunteeringDescriptionCreationDto>();

        public VolunteeringUpdateDto(string title, string organization, DateTime from)
        {
            Title = title;
            Organization = organization;
            From = from;
        }
    }

    public class VolunteeringDescriptionCreationDto
    {
        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        public VolunteeringDescriptionCreationDto(string description)
        {
            Description = description;
        }
    }
}
