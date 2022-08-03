namespace Portfolio.Models
{
    public class EducationWithoutParentDto
    {
        public int Id { get; set; }

        public string School { get; set; }

        public string Major { get; set; }

        public DateTime From { get; set; }

        public DateTime? To { get; set; } = null;

        public float? Average { get; set; } = null;

        public ICollection<EducationDescriptionWithoutParentDto> Descriptions { get; set; } = new List<EducationDescriptionWithoutParentDto>();

        public EducationWithoutParentDto(string school, string major, DateTime from)
        {
            School = school;
            Major = major;
            From = from;
        }
    }

    public class EducationDescriptionWithoutParentDto
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public EducationDescriptionWithoutParentDto(string description)
        {
            Description = description;
        }
    }

    public class EducationDescriptionCreationDto
    {
        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        public EducationDescriptionCreationDto(string description)
        {
            Description = description;
        }
    }

    public class EducationCreationDto
    {
        [Required]
        [MaxLength(100)]
        public string School { get; set; }

        [Required]
        [MaxLength(150)]
        public string Major { get; set; }

        public DateTime From { get; set; }

        public DateTime? To { get; set; } = null;

        public float? Average { get; set; } = null;

        public ICollection<EducationDescriptionCreationDto> Descriptions { get; set; } = new List<EducationDescriptionCreationDto>();

        public EducationCreationDto(string school, string major, DateTime from)
        {
            School = school;
            Major = major;
            From = from;
        }
    }

    public class EducationUpdateDto
    {
        [Required]
        [MaxLength(100)]
        public string School { get; set; }

        [Required]
        [MaxLength(150)]
        public string Major { get; set; }

        public DateTime From { get; set; }

        public DateTime? To { get; set; } = null;

        public float? Average { get; set; } = null;

        public ICollection<EducationDescriptionCreationDto> Descriptions { get; set; } = new List<EducationDescriptionCreationDto>();

        public EducationUpdateDto(string school, string major, DateTime from)
        {
            School = school;
            Major = major;
            From = from;
        }
    }
}
