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
        [MaxLength(200)]
        public string Overview { get; set; }

        public ICollection<ProjectDescription> Descriptions { get; set; } = new List<ProjectDescription>();

        public ICollection<ProjectLink> Links { get; set; } = new List<ProjectLink>();

        public int TypeId { get; set; }

        [ForeignKey("TypeId")]        
        public ProjectType? Type { get; set; }

        public int ResumeId;

        [ForeignKey("ResumeId")]
        public Resume? Resume;

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
        public Project? Project { get; set; }

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
        public Project? Project { get; set; }

        public ProjectLink(string name, string link)
        {
            Name = name;
            Link = link;
        }
    }

}
