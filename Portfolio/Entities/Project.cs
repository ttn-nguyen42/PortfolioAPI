using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Entities
{
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Role { get; set; }

        [Required]
        [MaxLength(150)]
        public string Team { get; set; }

        [Required]
        [MaxLength(300)]
        public string Overview { get; set; }

        public virtual ICollection<ProjectDescription> Descriptions { get; set; } = new List<ProjectDescription>();

        public virtual ICollection<ProjectLink> Links { get; set; } = new List<ProjectLink>();

        public int TypeId { get; set; }

        // Should not delete this entity when its type is deleted
        [ForeignKey("TypeId")]        
        public virtual ProjectType? Type { get; set; }

        public int ResumeId { get; set; }

        [ForeignKey("ResumeId")]
        public virtual Resume Resume { get; set; } = null!;

        public Project(string name, string role, string team, string overview)
        {
            Name = name;
            Role = role;
            Team = team;
            Overview = overview;
        }

    }

    public class ProjectDescription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        public int ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; } = null!;

        public ProjectDescription(string description)
        {
            Description = description;
        }
    }

    public class ProjectType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name
        {
            get; set;
        }

        public ProjectType(string name)
        {
            Name = name;
        }
    }

    public class ProjectLink
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name
        {
            get; set;
        }

        [Required]
        [MaxLength(300)]
        public string Link
        {
            get; set;
        }

        public int ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; } = null!;

        public ProjectLink(string name, string link)
        {
            Name = name;
            Link = link;
        }
    }

}
