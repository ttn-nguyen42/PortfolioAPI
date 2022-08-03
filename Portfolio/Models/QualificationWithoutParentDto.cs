namespace Portfolio.Models
{
    public class QualificationWithoutParentDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Issuer { get; set; }

        public float? Score { get; set; } = null;

        public ICollection<QualificationDescriptionWithoutParentDto> Descriptions { get; set; } = new List<QualificationDescriptionWithoutParentDto>();

        public QualificationWithoutParentDto(string name, string issuer)
        {
            Name = name;
            Issuer = issuer;
        }
    }

    public class QualificationDescriptionWithoutParentDto
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public QualificationDescriptionWithoutParentDto(string description)
        {
            Description = description;
        }
    }

    public class QualificationCreationDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Issuer { get; set; }

        public float? Score { get; set; } = null;

        public ICollection<QualificationDescriptionCreationDto> Descriptions { get; set; } = new List<QualificationDescriptionCreationDto>();

        public QualificationCreationDto(string name, string issuer)
        {
            Name = name;
            Issuer = issuer;
        }
    }

    public class QualificationUpdateDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Issuer { get; set; }

        public float? Score { get; set; } = null;

        public ICollection<QualificationDescriptionCreationDto> Descriptions { get; set; } = new List<QualificationDescriptionCreationDto>();

        public QualificationUpdateDto(string name, string issuer)
        {
            Name = name;
            Issuer = issuer;
        }
    }

    public class QualificationDescriptionCreationDto
    {
        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        public QualificationDescriptionCreationDto(string description)
        {
            Description = description;
        }
    }
}
