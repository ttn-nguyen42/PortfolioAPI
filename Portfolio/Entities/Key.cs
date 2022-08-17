using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Entities
{
    public class Key
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Value { get; set; }

        [Required]
        public KeyAuthorization Authorization { get; set; } = KeyAuthorization.READONLY;

        public Key(int id, string value, KeyAuthorization authorization)
        {
            Id = id;
            Value = value;
            Authorization = authorization;
        }

        public Key(string value, KeyAuthorization authorization)
        {
            Value = value;
            Authorization = authorization;
        }
    }

    public enum KeyAuthorization
    {
        ADMIN,
        READONLY,
    }
}
