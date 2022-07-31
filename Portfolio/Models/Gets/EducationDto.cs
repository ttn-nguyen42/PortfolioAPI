namespace Portfolio.Models.Gets
{
    public class EducationDto
    {
        public int Id { get; set; }

        public string School { get; set; } = string.Empty;

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public string Degree { get; set; } = string.Empty;

        public ICollection<MajorDto> Majors { get; set; } = new List<MajorDto>();
    }
}
