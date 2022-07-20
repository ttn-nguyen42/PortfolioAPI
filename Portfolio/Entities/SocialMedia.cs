using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Entities
{
    public class SocialMedia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Platform { get; set; }

        [Required]
        [MaxLength(200)]
        public string Link { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public User? User { get; set; }

        public SocialMedia(int id, string platform, string link)
        {
            Id = id;
            Platform = platform;
            Link = link;
        }
    }
}
