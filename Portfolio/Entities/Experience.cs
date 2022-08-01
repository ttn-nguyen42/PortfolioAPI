using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Entities
{
    public class Experience
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(100)]
        public string Company { get; set; }

        [Required]
        public DateTime From { get; set; }

        public DateTime? To { get; set; } = null;

        public virtual ICollection<ExperienceDescription> Descriptions { get; set; } = new List<ExperienceDescription>();

        public int ResumeId { get; set; }

        [ForeignKey("ResumeId")]
        public virtual Resume Resume { get; set; } = null!;

        public Experience(string title, string company, DateTime from)
        {
            Title = title;
            Company = company;
            From = from;
        }
    }

    public class ExperienceDescription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        public int ExperienceId { get; set; }

        [ForeignKey("ExperienceId")]
        public virtual Experience Experience { get; set; } = null!;

        public ExperienceDescription(string description)
        {
            Description = description;
        }
    }
}
