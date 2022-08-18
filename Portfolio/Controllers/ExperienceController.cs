using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/resumes/{resumeId}/experiences")]
    public class ExperienceController : ControllerBase
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

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<ExperienceWithoutParentDto>))]
        [ProducesResponseType(404, Type = typeof(ExceptionMessage))]
        [Produces("application/json")]
        public async Task<IActionResult> GetExperiences([FromRoute] int resumeId)
        {
            Resume? resume = await _resumeRepository.GetResumeAsync(resumeId);
            if (resume is null)
            {
                throw new ApiException(404, "Resume not found");
            }
            return Ok(_mapper.Map<ICollection<ExperienceWithoutParentDto>>(resume.Experience));
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ExperienceWithoutParentDto))]
        [ProducesResponseType(404, Type = typeof(ExceptionMessage))]
        [Produces("application/json")]
        public async Task<IActionResult> AddExperience([FromRoute] int resumeId, [FromBody] ExperienceCreationDto dto)
        {
            Resume? resume = await _resumeRepository.GetResumeAsync(resumeId);
            if (resume is null)
            {
                throw new ApiException(404, "Resume not found");
            }
            Experience entity = _mapper.Map<Experience>(dto);
            resume.Experience.Add(entity);
            if (await _experienceRepository.SaveChangesAsync())
            {
                return Ok(_mapper.Map<ExperienceWithoutParentDto>(entity));
            }
            throw new ApiException();
        }

        [HttpPut("{experienceId}")]
        [ProducesResponseType(200, Type = typeof(ExperienceWithoutParentDto))]
        [ProducesResponseType(404, Type = typeof(ExceptionMessage))]
        [ProducesResponseType(406, Type = typeof(ExceptionMessage))]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateExperience([FromRoute] int resumeId, [FromRoute] int experienceId, [FromBody] ExperienceUpdateDto dto)
        {
            Resume? resume = await _resumeRepository.GetResumeAsync(resumeId);
            if (resume is null)
            {
                throw new ApiException(404, "Resume not found");
            }
            Experience? entity = await _experienceRepository.GetExperienceAsync(experienceId);
            if (entity is null)
            {
                throw new ApiException(404, "Experience not found");
            }
            if (resume.Experience.AsParallel().FirstOrDefault(e => e.Id == entity.Id) is null)
            {
                throw new ApiException(406, "Update to experience not owned by yourself is not allowed");
            }
            _mapper.Map(dto, entity);
            if (await _experienceRepository.SaveChangesAsync())
            {
                return Ok(_mapper.Map<ExperienceWithoutParentDto>(entity));
            }
            throw new ApiException();
        }

        [HttpDelete]
        [ProducesResponseType(201)]
        [ProducesResponseType(404, Type = typeof(ExceptionMessage))]
        [ProducesResponseType(406, Type = typeof(ExceptionMessage))]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteExperience([FromRoute] int resumeId, [FromRoute] int experienceId)
        {
            Resume? resume = await _resumeRepository.GetResumeAsync(resumeId);
            if (resume is null)
            {
                throw new ApiException(404, "Resume not found");
            }
            Experience? entity = await _experienceRepository.GetExperienceAsync(experienceId);
            if (entity is null)
            {
                throw new ApiException(404, "Experience not found");
            }
            if (resume.Experience.AsParallel().FirstOrDefault(e => e.Id == entity.Id) is null)
            {
                throw new ApiException(406, "Update to experience not owned by yourself is not allowed");
            }
            _experienceRepository.DeleteExperience(entity);
            if (await _experienceRepository.SaveChangesAsync())
            {
                return Accepted();
            }
            throw new ApiException();
        }
    }
}
