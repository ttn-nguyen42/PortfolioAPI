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
        public string IssuerId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Instructor { get; set; }

        public DateTime Time { get; set; }

        public ICollection<CertificateDescription> Descriptions = new List<CertificateDescription>();

        public int TypeId;

        [ForeignKey("TypeId")]
        public CertificateType? Type;

        public ICollection<CertificateLink> Links = new List<CertificateLink>();

        [ForeignKey("ResumeId")]
        public Resume? Resume;

        public int ResumeId;

        public Certificate(string name, string issuerId, string instructor, DateTime time)
        {
            Name = name;
            IssuerId = issuerId;
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
        public Certificate? Certificate { get; set; }

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
        public Certificate? Certificate { get; set; }

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

        public int CertificateId { get; set; }

        [ForeignKey("CertificateId")]
        public Certificate? Certificate { get; set; }

        public CertificateType(string name)
        {
            Name = name;
        }
    }
}
