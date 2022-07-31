using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Entities
{
    public class Resume
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string ShortBiography { get; set; }

        [Required]
        [MaxLength(800)]
        public string Biography { get; set; }

        [Required]
        [MaxLength(100)]
        public string Location { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        /*
         * Cascade delete: When a child is deleted (i.e TechnicalSkill), its parent will not reference to it anymore
         * When its parent is deleted, itself are also deleted
         */

        public ICollection<TechnicalSkill> Skills = new List<TechnicalSkill>();

        public ICollection<Experience> Experience = new List<Experience>();

        public ICollection<Education> Education = new List<Education>();

        public ICollection<Volunteering> Volunteering = new List<Volunteering>();

        public ICollection<Qualification> Qualification = new List<Qualification>();

        public ICollection<PersonalLink> PersonalLink = new List<PersonalLink>();

        public ICollection<Activity> Activities = new List<Activity>();

        public ICollection<Certificate> Certificates = new List<Certificate>();

        public ICollection<Project> Projects = new List<Project>();

        public Resume(string name, string shortBiography, string location, string email, string biography)
        {
            Name = name;
            ShortBiography = shortBiography;
            Location = location;
            Email = email;
            Biography = biography;
        }
    }

    public class PersonalLink
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

        public int ResumeId { get; set; }

        [ForeignKey("ResumeId")]
        public Resume Resume { get; set; } = null!;

        public PersonalLink(string name, string link)
        {
            Name = name;
            Link = link;
        }
    }
}
