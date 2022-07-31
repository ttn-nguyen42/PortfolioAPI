namespace Portfolio.Models
{
    public class EducationWithoutParentDto
    {
        public int Id { get; set; }

        public string School { get; set; }

        public string Major { get; set; }

        public DateTime From { get; set; }

        public DateTime? To { get; set; } = null;

        public float? Average { get; set; } = null;

        public ICollection<EducationDescriptionWithoutParentDto> Descriptions = new List<EducationDescriptionWithoutParentDto>();

        public EducationWithoutParentDto(string school, string major, DateTime from)
        {
            School = school;
            Major = major;
            From = from;
        }
    }

    public class EducationDescriptionWithoutParentDto
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public EducationDescriptionWithoutParentDto(string description)
        {
            Description = description;
        }
    }
}
