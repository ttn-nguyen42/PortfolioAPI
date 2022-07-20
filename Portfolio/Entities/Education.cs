using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Entities
{
    public class Education
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string School { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Start { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime End { get; set; }

        [Required]
        [MaxLength(200)]
        public string Degree { get; set; }

        public ICollection<Major> Majors { get; set; } = new List<Major>();

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User? User { get; set; }

        public Education(string school, DateTime start, DateTime end, string degree)
        {
            School = school;
            Start = start;
            End = end;
            Degree = degree;
        }
    }
}
