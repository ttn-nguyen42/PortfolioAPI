namespace Portfolio.Models
{
    public class ExperienceWithoutParentDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Company { get; set; }

        public DateTime From { get; set; }

        public DateTime? To { get; set; } = null;

        public ICollection<ExperienceDescriptionWithoutParentDto> Descriptions = new List<ExperienceDescriptionWithoutParentDto>();

        public ExperienceWithoutParentDto(string title, string company, DateTime from)
        {
            Title = title;
            Company = company;
            From = from;
        }
    }

    public class ExperienceDescriptionWithoutParentDto
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public ExperienceDescriptionWithoutParentDto(string description)
        {
            Description = description;
        }
    }
}
