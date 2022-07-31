namespace Portfolio.Models.Gets
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }

        public string Biography { get; set; } = string.Empty;

        public ICollection<SocialMediaDto> SocialMedias { get; set; } = new List<SocialMediaDto>();

        public ICollection<EducationDto> Educations { get; set; } = new List<EducationDto>();
    }
}
