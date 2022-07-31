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

        public ICollection<ExperienceDescription> Descriptions = new List<ExperienceDescription>();

        public int ResumeId { get; set; }

        [ForeignKey("ResumeId")]
        public Resume? Resume { get; set; }

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
        public Experience? Experience { get; set; }

        public ExperienceDescription(string description)
        {
            Description = description;
        }
    }
}
