namespace Portfolio.Models
{
    public class QualificationWithoutParentDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Issuer { get; set; }

        public float? Score { get; set; } = null;

        public ICollection<QualificationDescriptionWithoutParentDto> Descriptions = new List<QualificationDescriptionWithoutParentDto>();

        public QualificationWithoutParentDto(string name, string issuer)
        {
            Name = name;
            Issuer = issuer;
        }
    }

    public class QualificationDescriptionWithoutParentDto
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public QualificationDescriptionWithoutParentDto(string description)
        {
            Description = description;
        }
    }
}
