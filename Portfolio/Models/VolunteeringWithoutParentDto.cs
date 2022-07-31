namespace Portfolio.Models
{
    public class VolunteeringWithoutParentDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Organization { get; set; }

        public DateTime From { get; set; }

        public DateTime? To { get; set; }

        public ICollection<VolunteeringDescriptionWithoutParentDto> Descriptions = new List<VolunteeringDescriptionWithoutParentDto>();

        public VolunteeringWithoutParentDto(string title, string organization, DateTime from)
        {
            Title = title;
            Organization = organization;
            From = from;
        }
    }

    public class VolunteeringDescriptionWithoutParentDto
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public VolunteeringDescriptionWithoutParentDto(string description)
        {
            Description = description;
        }
    }
}
