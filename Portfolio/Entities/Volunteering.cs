using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Entities
{
    public class Volunteering
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(150)]
        public string Organization { get; set; }

        public DateTime From { get; set; }

        public DateTime? To { get; set; } = null;

        public ICollection<VolunteeringDescription> Descriptions = new List<VolunteeringDescription>();

        public int ResumeId { get; set; }

        [ForeignKey("ResumeId")]
        public Resume Resume { get; set; } = null!;

        public Volunteering(string title, string organization)
        {
            Title = title;
            Organization = organization;
        }
    }

    public class VolunteeringDescription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        public int VolunteeringId { get; set; }

        [ForeignKey("VolunteeringId")]
        public Volunteering Volunteering { get; set; } = null!;

        public VolunteeringDescription(string description)
        {
            Description = description;
        }
    }
}
