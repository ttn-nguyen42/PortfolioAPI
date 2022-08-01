namespace Portfolio.Models
{
    public class InfoDto
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string ShortBiography { get; set; }

        public string Location { get; set; }

        public string Email { get; set; }

        public ICollection<PersonalLinkWithoutParentDto> links = new List<PersonalLinkWithoutParentDto>();

        public InfoDto(string name, string shortBiography, string location, string email)
        {
            Name = name;
            ShortBiography = shortBiography;
            Location = location;
            Email = email;
        }
    }

    public class PersonalLinkWithoutParentDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Link { get; set; }

        public PersonalLinkWithoutParentDto(string name, string link)
        {
            Name = name;
            Link = link;
        }
    }
}
