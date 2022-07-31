using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Entities
{
    public class TechnicalSkill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Language { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public int? Proficiency { get; set; } = null;

        public ICollection<TechnicalSkillDescription> Skills { get; set; } = new List<TechnicalSkillDescription>();

        public int TypeId { get; set; }

        // Should not delete this entity when its type is deleted
        [ForeignKey("TypeId")]
        public TechnicalSkillType? Type { get; set; }

        public int ResumeId { get; set; }

        [ForeignKey("ResumeId")]
        public Resume Resume { get; set; } = null!;

        public TechnicalSkill(string language, string name)
        {
            Language = language;
            Name = name;
        }
    }

    public class TechnicalSkillDescription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        public int TechnicalSkillId { get; set; }

        [ForeignKey("TechnicalSkillId")]
        public TechnicalSkill TechnicalSkill { get; set; } = null!;

        public TechnicalSkillDescription(string description)
        {
            Description = description;
        }
    }

    public class TechnicalSkillType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get; set;
        }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public TechnicalSkillType(string name)
        {
            Name = name;
        }
    }
}
