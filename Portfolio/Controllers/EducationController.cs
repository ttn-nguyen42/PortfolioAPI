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

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<EducationWithoutParentDto>))]
        [ProducesResponseType(404, Type = typeof(ExceptionMessage))]
        [Produces("application/json")]
        public async Task<IActionResult> GetSkills([FromRoute] int resumeId)
        {
            Resume? resume = await _resumeRepository.GetResumeAsync(resumeId);
            if (resume is null)
            {
                throw new ApiException(404, "Resume not found");
            }
            return Ok(_mapper.Map<ICollection<EducationWithoutParentDto>>(resume.Education));
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(EducationWithoutParentDto))]
        [ProducesResponseType(404, Type = typeof(ExceptionMessage))]
        [Produces("application/json")]
        public async Task<IActionResult> AddEducation([FromRoute] int resumeId, [FromBody] EducationCreationDto dto)
        {
            Resume? resume = await _resumeRepository.GetResumeAsync(resumeId);
            if (resume is null)
            {
                throw new ApiException(404, "Resume not found");
            }
            Education entity = _mapper.Map<Education>(dto);
            resume.Education.Add(entity);
            if (await _educationRepository.SaveChangesAsync())
            {
                return Ok(_mapper.Map<EducationWithoutParentDto>(entity));
            }
            throw new ApiException();
        }

        [HttpPut("{educationId}")]
        [ProducesResponseType(200, Type = typeof(EducationWithoutParentDto))]
        [ProducesResponseType(404, Type = typeof(ExceptionMessage))]
        [ProducesResponseType(406, Type = typeof(ExceptionMessage))]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateEducation([FromRoute] int resumeId, [FromRoute] int educationId, [FromBody] EducationUpdateDto dto)
        {
            Resume? resume = await _resumeRepository.GetResumeAsync(resumeId);
            if (resume is null)
            {
                throw new ApiException(404, "Resume not found");
            }
            Education? entity = await _educationRepository.GetEducationAsync(educationId);
            if (entity is null)
            {
                throw new ApiException(404, "Education not found");
            }
            if (resume.Education.AsParallel().FirstOrDefault(e => e.Id == educationId) is null)
            {
                throw new ApiException(406, "Update to education not owned by yourself is not allowed");
            }
            _mapper.Map(dto, entity);
            if (await _educationRepository.SaveChangesAsync())
            {
                return Ok(_mapper.Map<EducationWithoutParentDto>(resume));
            }
            throw new ApiException();
        }

        [HttpDelete("{educationId}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(404, Type = typeof(ExceptionMessage))]
        [ProducesResponseType(406, Type = typeof(ExceptionMessage))]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteEducation([FromRoute] int resumeId, [FromRoute] int educationId)
        {
            Resume? resume = await _resumeRepository.GetResumeAsync(resumeId);
            if (resume is null)
            {
                throw new ApiException(404, "Resume not found");
            }
            Education? entity = await _educationRepository.GetEducationAsync(educationId);
            if (entity is null)
            {
                throw new ApiException(404, "Education not found");
            }
            if (resume.Education.AsParallel().FirstOrDefault(e => e.Id == entity.Id) is null)
            {
                throw new ApiException(406, "Update to education not owned by yourself is not allowed");
            }
            _educationRepository.DeleteEducation(entity);
            if (await _educationRepository.SaveChangesAsync())
            {
                return Accepted();
            }
            throw new ApiException();
        }
    }
}
