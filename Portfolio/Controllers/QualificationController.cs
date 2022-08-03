using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/resumes/{resumeId}/qualifications")]
    public class QualificationController : ControllerBase
    {
        private readonly IQualificationRepository _qualificationRepository;
        private readonly IResumeRepository _resumeRepository;
        private readonly IMapper _mapper;

        public QualificationController(IResumeRepository resumeRepository, IMapper mapper, IQualificationRepository qualificationRepository)
        {
            _resumeRepository = resumeRepository ?? throw new ArgumentNullException(nameof(resumeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _qualificationRepository = qualificationRepository ?? throw new ArgumentNullException(nameof(qualificationRepository));
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<QualificationWithoutParentDto>))]
        [ProducesResponseType(404, Type = typeof(ExceptionMessage))]
        [Produces("application/json")]
        public async Task<IActionResult> GetQualifications([FromRoute] int resumeId)
        {
            Resume? resume = await _resumeRepository.GetResumeAsync(resumeId);
            if (resume is null)
            {
                throw new ApiException(404, "Resume not found");
            }
            return Ok(_mapper.Map<ICollection<QualificationWithoutParentDto>>(resume.Qualification));
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(QualificationWithoutParentDto))]
        [ProducesResponseType(404, Type = typeof(ExceptionMessage))]
        [Produces("application/json")]
        public async Task<IActionResult> CreateQualification([FromRoute] int resumeId, [FromBody] QualificationCreationDto dto)
        {
            Resume? resume = await _resumeRepository.GetResumeAsync(resumeId);
            if (resume is null)
            {
                throw new ApiException(404, "Resume not found");
            }
            Qualification entity = _mapper.Map<Qualification>(dto);
            resume.Qualification.Add(entity);
            if (await _qualificationRepository.SaveChangesAsync())
            {
                return Ok(_mapper.Map<QualificationWithoutParentDto>(entity));
            }
            throw new ApiException();
        }

        [HttpPut("{qualificationId}")]
        [ProducesResponseType(200, Type = typeof(QualificationWithoutParentDto))]
        [ProducesResponseType(404, Type = typeof(ExceptionMessage))]
        [ProducesResponseType(406, Type = typeof(ExceptionMessage))]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateQualification([FromRoute] int resumeId, [FromRoute] int qualificationId, [FromBody] QualificationUpdateDto dto)
        {
            Resume? resume = await _resumeRepository.GetResumeAsync(resumeId);
            if (resume is null)
            {
                throw new ApiException(404, "Resume not found");
            }
            Qualification? entity = await _qualificationRepository.GetQualificationAsync(qualificationId);
            if (entity is null)
            {
                throw new ApiException(404, "Qualification not found");
            }
            if (resume.Experience.AsParallel().FirstOrDefault(e => e.Id == entity.Id) is null)
            {
                throw new ApiException(406, "Update to qualification not owned by yourself is not allowed");
            }
            _mapper.Map(dto, entity);
            if (await _qualificationRepository.SaveChangesAsync())
            {
                return Ok(_mapper.Map<QualificationWithoutParentDto>(entity));
            }
            throw new ApiException();

        }

        [HttpDelete("{qualificationId}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(404, Type = typeof(ExceptionMessage))]
        [ProducesResponseType(406, Type = typeof(ExceptionMessage))]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteQualification([FromRoute] int resumeId, [FromRoute] int qualificationId)
        {
            Resume? resume = await _resumeRepository.GetResumeAsync(resumeId);
            if (resume is null)
            {
                throw new ApiException(404, "Resume not found");
            }
            Qualification? entity = await _qualificationRepository.GetQualificationAsync(qualificationId);
            if (entity is null)
            {
                throw new ApiException(404, "Qualification not found");
            }
            if (resume.Experience.AsParallel().FirstOrDefault(e => e.Id == entity.Id) is null)
            {
                throw new ApiException(406, "Update to qualification not owned by yourself is not allowed");
            }
            _qualificationRepository.DeleteQualification(entity);
            if (await _qualificationRepository.SaveChangesAsync())
            {
                return Accepted();
            }
            throw new ApiException();
        }
    }
}
