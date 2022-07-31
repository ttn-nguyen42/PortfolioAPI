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
}
