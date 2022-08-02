using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class TechnicalSkillWithoutParentDto
    {
        public int Id { get; set; }

        public string Language { get; set; }

        public string Name { get; set; }

        public int? Proficiency { get; set; } = null;

        public TechnicalSkillTypeDto? Type { get; set; } = null!;

        public ICollection<TechnicalSkillDescriptionWithoutParentDto> Skills { get; set; } = new List<TechnicalSkillDescriptionWithoutParentDto>();

        public TechnicalSkillWithoutParentDto(string language, string name)
        {
            Language = language;
            Name = name;
        }
    }

    public class TechnicalSkillTypeDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public TechnicalSkillTypeDto(string name)
        {
            Name = name;
        }
    }

    public class TechnicalSkillDescriptionWithoutParentDto
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public TechnicalSkillDescriptionWithoutParentDto(string description)
        {
            Description = description;
        }
    }

    public class TechnicalSkillTypeCreationDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public TechnicalSkillTypeCreationDto(string name)
        {
            Name = name;
        }
    }

    public class TechnicalSkillDescriptionCreationDto
    {
        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        public TechnicalSkillDescriptionCreationDto(string description)
        {
            Description = description;
        }
    }

    public class TechnicalSkillCreationDto
    {
        [Required]
        [MaxLength(100)]
        public string Language { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public int? Proficiency { get; set; } = null;

        [Required]
        public int TypeId { get; set; }

        [Required]
        public ICollection<TechnicalSkillDescriptionCreationDto> Skills { get; set; } = new List<TechnicalSkillDescriptionCreationDto>();

        public TechnicalSkillCreationDto(string language, string name)
        {
            Language = language;
            Name = name;
        }
    }

    public class TechnicalSkillUpdateDto
    {
        [Required]
        [MaxLength(100)]
        public string Language { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public int? Proficiency { get; set; } = null;

        [Required]
        public int TypeId { get; set; }

        [Required]
        public ICollection<TechnicalSkillDescriptionCreationDto> Skills { get; set; } = new List<TechnicalSkillDescriptionCreationDto>();

        public TechnicalSkillUpdateDto(string language, string name)
        {
            Language = language;
            Name = name;
        }
    }
}
