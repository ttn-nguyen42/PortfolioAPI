using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Entities
{
    public class Certificate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Issuer { get; set; }

        [Required]
        [MaxLength(200)]
        public string Instructor { get; set; }

        public DateTime Time { get; set; }

        public virtual ICollection<CertificateDescription> Descriptions { get; set; } = new List<CertificateDescription>();

        public int? TypeId;

        // Should not delete this entity when its type is deleted
        [ForeignKey("TypeId")]
        public virtual CertificateType? Type { get; set; }

        public virtual ICollection<CertificateLink> Links { get; set; } = new List<CertificateLink>();

        [ForeignKey("ResumeId")]
        public virtual Resume Resume { get; set; } = null!;

        public int ResumeId { get; set; }

        public Certificate(string name, string issuer, string instructor, DateTime time)
        {
            Name = name;
            Issuer = issuer;
            Instructor = instructor;
            Time = time;
        }
    }

    public class CertificateDescription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        public int CertificateId { get; set; }

        [ForeignKey("CertificateId")]
        public virtual Certificate Certificate { get; set; } = null!;

        public CertificateDescription(string description)
        {
            Description = description;
        }

    }

    public class CertificateLink
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string Link { get; set; }

        public int CertificateId { get; set; }

        [ForeignKey("CertificateId")]
        public virtual Certificate Certificate { get; set; } = null!;

        public CertificateLink(string name, string link)
        {
            Link = link;
            Name = name;
        }
    }

    public class CertificateType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public CertificateType(string name)
        {
            Name = name;
        }
    }
}
