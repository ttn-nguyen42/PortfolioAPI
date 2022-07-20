using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string City { get; set; }

        [Required]
        [MaxLength(100)]
        public string Country { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [MaxLength(200)]
        public string Biography { get; set; } = string.Empty;

        public ICollection<SocialMedia> SocialMedias { get; set; } = new List<SocialMedia>();

        public ICollection<Education> Educations { get; set; } = new List<Education>();

        public User(string name, string city, string country, DateTime dateOfBirth)
        {
            Name = name;
            City = city;
            Country = country;
            DateOfBirth = dateOfBirth;
        }
    }
}
