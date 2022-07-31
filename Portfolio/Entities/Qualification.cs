using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Entities
{
    public class Qualification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(150)]
        public string Issuer { get; set; }

        public float? Score { get; set; } = null;

        public int ResumeId { get; set; }

        [ForeignKey("ResumeId")]
        public Resume Resume { get; set; } = null!;

        public ICollection<QualificationDescription> Descriptions = new List<QualificationDescription>();

        public Qualification(string name, string issuer)
        {
            Name = name;
            Issuer = issuer;
        }
    }

    public class QualificationDescription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        [ForeignKey("QualificationId")]
        public Qualification Qualification { get; set; } = null!;

        public int QualificationId { get; set; } 

        public QualificationDescription(string description)
        {
            Description = description;
        }
    }
}
