using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class ResumeDto
    {
        public int Id { get; set; }

        public ICollection<TechnicalSkillWithoutParentDto> Skills { get; set; } = new List<TechnicalSkillWithoutParentDto>();

        public ICollection<ExperienceWithoutParentDto> Experience { get; set; } = new List<ExperienceWithoutParentDto>();

        public ICollection<EducationWithoutParentDto> Education { get; set; } = new List<EducationWithoutParentDto>();

        public ICollection<VolunteeringWithoutParentDto> Volunteering { get; set; } = new List<VolunteeringWithoutParentDto>();

        public ICollection<QualificationWithoutParentDto> Qualification { get; set; } = new List<QualificationWithoutParentDto>();

        public ResumeDto() { }
    }

    public class ResumeCreationDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string ShortBiography { get; set; }

        [Required]
        [MaxLength(800)]
        public string Biography { get; set; }

        [Required]
        [MaxLength(100)]
        public string Location { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        public ICollection<PersonalLinkCreationDto> Links { get; set; } = new List<PersonalLinkCreationDto>();

        public ResumeCreationDto(string name, string shortBiography, string biography, string location, string email)
        {
            Name = name;
            ShortBiography = shortBiography;
            Biography = biography;
            Location = location;
            Email = email;
        }
    }

    public class ResumeWithInfoAndAboutDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ShortBiography { get; set; }

        public string Biography { get; set; }

        public string Location { get; set; }

        public string Email { get; set; }

        public ICollection<TechnicalSkillWithoutParentDto> Skills { get; set; } = new List<TechnicalSkillWithoutParentDto>();

        public ICollection<ExperienceWithoutParentDto> Experience { get; set; } = new List<ExperienceWithoutParentDto>();

        public ICollection<EducationWithoutParentDto> Education { get; set; } = new List<EducationWithoutParentDto>();

        public ICollection<VolunteeringWithoutParentDto> Volunteering { get; set; } = new List<VolunteeringWithoutParentDto>();

        public ICollection<QualificationWithoutParentDto> Qualification { get; set; } = new List<QualificationWithoutParentDto>();

        public ICollection<PersonalLinkWithoutParentDto> Links { get; set; } = new List<PersonalLinkWithoutParentDto>();

        public ResumeWithInfoAndAboutDto(string name, string shortBiography, string biography, string location, string email)
        {
            Name = name;
            ShortBiography = shortBiography;
            Biography = biography;
            Location = location;
            Email = email;
        }
    }

    public class ResumeUpdateDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string ShortBiography { get; set; }

        [Required]
        [MaxLength(800)]
        public string Biography { get; set; }

        [Required]
        [MaxLength(100)]
        public string Location { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        public ICollection<PersonalLinkCreationDto> Links { get; set; } = new List<PersonalLinkCreationDto>();

        public ResumeUpdateDto(string name, string shortBiography, string biography, string location, string email)
        {
            Name = name;
            ShortBiography = shortBiography;
            Biography = biography;
            Location = location;
            Email = email;
        }
    }
}
