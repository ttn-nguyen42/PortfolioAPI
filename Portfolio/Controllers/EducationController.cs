using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/resume/{resumeId}/educations")]
    public class EducationController : ControllerBase
    {
        private readonly IEducationRepository _educationRepository;
        private readonly IResumeRepository _resumeRepository;
        private readonly IMapper _mapper;

        public EducationController(IEducationRepository educationRepository, IResumeRepository resumeRepository, IMapper mapper)
        {
            _educationRepository = educationRepository
                ?? throw new ArgumentNullException(nameof(educationRepository));
            _resumeRepository = resumeRepository ?? throw new ArgumentNullException(nameof(resumeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


    }
}
