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

        public virtual ICollection<TechnicalSkill> Skills { get; set; } = new List<TechnicalSkill>();

        public virtual ICollection<Experience> Experience { get; set; } = new List<Experience>();

        public virtual ICollection<Education> Education { get; set; } = new List<Education>();

        public virtual ICollection<Volunteering> Volunteering { get; set; } = new List<Volunteering>();

        public virtual ICollection<Qualification> Qualification { get; set; } = new List<Qualification>();

        public virtual ICollection<PersonalLink> Links { get; set; } = new List<PersonalLink>();

        public virtual ICollection<Activity> Activities { get; set; } = new List<Activity>();

        public virtual ICollection<Certificate> Certificates { get; set; } = new List<Certificate>();

        public virtual ICollection<Project> Projects { get; set; } = new List<Project>();

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
        public virtual Resume Resume { get; set; } = null!;

        public PersonalLink(string name, string link)
        {
            Name = name;
            Link = link;
        }
    }
}
