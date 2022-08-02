using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/resumes/{id}/experiences")]
    public class ExperienceController
    {
        private readonly IExperienceRepository _experienceRepository;
        private readonly IResumeRepository _resumeRepository;
        private readonly IMapper _mapper;

        public ExperienceController(IExperienceRepository experienceRepository, IResumeRepository resumeRepository, IMapper mapper)
        {
            _experienceRepository = experienceRepository
                ?? throw new ArgumentNullException(nameof(experienceRepository));
            _resumeRepository = resumeRepository ?? throw new ArgumentNullException(nameof(resumeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
    }
}
