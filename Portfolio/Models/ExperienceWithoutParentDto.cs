namespace Portfolio.Models
{
    public class ExperienceWithoutParentDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Company { get; set; }

        public DateTime From { get; set; }

        public DateTime? To { get; set; } = null;

        public ICollection<ExperienceDescriptionWithoutParentDto> Descriptions = new List<ExperienceDescriptionWithoutParentDto>();

        public ExperienceWithoutParentDto(string title, string company, DateTime from)
        {
            Title = title;
            Company = company;
            From = from;
        }
    }

    public class ExperienceDescriptionWithoutParentDto
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public ExperienceDescriptionWithoutParentDto(string description)
        {
            Description = description;
        }
    }

    public class ExperienceCreationDto {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(150)]
        public string Company { get; set; }

        public DateTime From { get; set; }

        public DateTime? To { get; set; } = null;

        public ICollection<ExperienceDescriptionCreationDto> Descriptions = new List<ExperienceDescriptionCreationDto>();

        public ExperienceCreationDto(string title, string company, DateTime from)
        {
            Title = title;
            Company = company;
            From = from;
        }
    }

    public class ExperienceDescriptionCreationDto
    {
        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        public ExperienceDescriptionCreationDto(string description)        {
            Description = description;
        }

    }
        
    public class ExperienceUpdateDto
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(150)]
        public string Company { get; set; }

        public DateTime From { get; set; }

        public DateTime? To { get; set; } = null;

        public ICollection<ExperienceDescriptionCreationDto> Descriptions = new List<ExperienceDescriptionCreationDto>();

        public ExperienceUpdateDto(string title, string company, DateTime from)
        {
            Title = title;
            Company = company;
            From = from;
        }
    }
}
