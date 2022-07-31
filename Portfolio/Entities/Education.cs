using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Entities
{
    public class Education
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string School { get; set; }

        [Required]
        [MaxLength(150)]
        public string Major { get; set; }

        public DateTime From { get; set; }

        public DateTime? To { get; set; } = null;

        public float? Average { get; set; } = null;

        public ICollection<EducationDescription> Descriptions = new List<EducationDescription>();

        public int ResumeId { get; set; }

        [ForeignKey("ResumeId")]
        public Resume? Resume { get; set; }

        public Education(string school, string major)
        {
            School = school;
            Major = major;
        }
    }

    public class EducationDescription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        public int EducationId { get; set; }

        [ForeignKey("EducationId")]
        public Education? Education { get; set; }

        public EducationDescription(string description)
        {
            Description = description;
        }
    }
}
