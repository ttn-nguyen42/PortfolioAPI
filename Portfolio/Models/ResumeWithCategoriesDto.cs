namespace Portfolio.Models
{
    public class ResumeDto
    {
        public int Id { get; set; }

        public ICollection<TechnicalSkillDescriptionWithoutParentDto> Skills { get; set; } = new List<TechnicalSkillDescriptionWithoutParentDto>();

        public ICollection<ExperienceWithoutParentDto> Experience { get; set; } = new List<ExperienceWithoutParentDto>();

        public ICollection<EducationWithoutParentDto> Education { get; set; } = new List<EducationWithoutParentDto>();

        public ICollection<VolunteeringWithoutParentDto> Volunteering { get; set; } = new List<VolunteeringWithoutParentDto>();

        public ICollection<QualificationWithoutParentDto> Qualification { get; set; } = new List<QualificationWithoutParentDto>();
    }
}
