using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Entities
{
    public class Activity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(150)]
        public string Organizer { get; set; }

        [Required]
        [MaxLength(200)]
        public string Overview { get; set; }

        public ICollection<ActivityDescription> Descriptions = new List<ActivityDescription>();

        public int TypeId { get; set; }

        [ForeignKey("TypeId")]
        public ActivityType? Type { get; set; }

        public ICollection<ActivityLink> Links = new List<ActivityLink>();

        [ForeignKey("ResumeId")]
        public Resume? Resume;

        public int ResumeId;

        public Activity(string name, string organizer, string overview)
        {
            Name = name;
            Organizer = organizer;
            Overview = overview;
        }
    }

    public class ActivityDescription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        public int ActivityId { get; set; }

        [ForeignKey("ActivityId")]
        public Activity? Activity { get; set; }

        public ActivityDescription(string description)
        {
            Description = description;
        }
    }

    public class ActivityType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public ActivityType(string name)
        {
            Name = name;
        }
    }

    public class ActivityLink
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(300)]
        public string Link { get; set; }

        public int ActivityId { get; set; }

        [ForeignKey("ActivityId")]
        public Activity? Activity { get; set; }

        public ActivityLink(string name, string link)
        {
            Name = name;
            Link = link;
        }
    }

}
