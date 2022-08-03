using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/resumes/{resumeId}/volunteerings")]
    public class VolunteeringController: ControllerBase
    {

        private readonly IVolunteeringRepository _volunteeringRepository;
        private readonly IResumeRepository _resumeRepository;
        private readonly IMapper _mapper;

        public VolunteeringController(IResumeRepository resumeRepository, IMapper mapper, IVolunteeringRepository volunteeringRepository)
        {
            _resumeRepository = resumeRepository ?? throw new ArgumentNullException(nameof(resumeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _volunteeringRepository = volunteeringRepository ?? throw new ArgumentNullException(nameof(volunteeringRepository));
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<VolunteeringWithoutParentDto>))]
        [ProducesResponseType(404, Type = typeof(ExceptionMessage))]
        [Produces("application/json")]
        public async Task<IActionResult> GetVolunteerings([FromRoute] int resumeId)
        {
            Resume? resume = await _resumeRepository.GetResumeAsync(resumeId);
            if (resume is null)
            {
                throw new ApiException(404, "Resume not found");
            }
            return Ok(_mapper.Map<ICollection<VolunteeringWithoutParentDto>>(resume.Qualification));
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(VolunteeringWithoutParentDto))]
        [ProducesResponseType(404, Type = typeof(ExceptionMessage))]
        [Produces("application/json")]
        public async Task<IActionResult> CreateVolunteering([FromRoute] int resumeId, [FromBody] VolunteeringCreationDto dto)
        {
            Resume? resume = await _resumeRepository.GetResumeAsync(resumeId);
            if (resume is null)
            {
                throw new ApiException(404, "Resume not found");
            }
            Volunteering? entity = _mapper.Map<Volunteering>(dto);
            resume.Volunteering.Add(entity);
            if (await _volunteeringRepository.SaveChangesAsync())
            {
                return Ok(_mapper.Map<VolunteeringWithoutParentDto>(entity));
            }
            throw new ApiException();
        }

        [HttpPut("{volunteeringId}")]
        [ProducesResponseType(200, Type = typeof(VolunteeringWithoutParentDto))]
        [ProducesResponseType(404, Type = typeof(ExceptionMessage))]
        [ProducesResponseType(406, Type = typeof(ExceptionMessage))]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateVolunteering([FromRoute] int resumeId, [FromRoute] int volunteeringId, [FromBody] VolunteeringUpdateDto dto)
        {
            Resume? resume = await _resumeRepository.GetResumeAsync(resumeId);
            if (resume is null)
            {
                throw new ApiException(404, "Resume not found");
            }
            Volunteering? entity = await _volunteeringRepository.GetVolunteeringAsync(volunteeringId);
            if (entity is null)
            {
                throw new ApiException(404, "Qualification not found");
            }
            if (resume.Experience.AsParallel().FirstOrDefault(e => e.Id == entity.Id) is null)
            {
                throw new ApiException(406, "Update to volunteering not owned by yourself is not allowed");
            }
            _mapper.Map(dto, entity);
            if (await _volunteeringRepository.SaveChangesAsync())
            {
                return Ok(_mapper.Map<VolunteeringWithoutParentDto>(entity));
            }
            throw new ApiException();

        }

        [HttpDelete("{volunteeringId}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(404, Type = typeof(ExceptionMessage))]
        [ProducesResponseType(406, Type = typeof(ExceptionMessage))]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteVolunteering([FromRoute] int resumeId, [FromRoute] int volunteeringId)
        {
            Resume? resume = await _resumeRepository.GetResumeAsync(resumeId);
            if (resume is null)
            {
                throw new ApiException(404, "Resume not found");
            }
            Volunteering? entity = await _volunteeringRepository.GetVolunteeringAsync(volunteeringId);
            if (entity is null)
            {
                throw new ApiException(404, "Volunteering not found");
            }
            if (resume.Experience.AsParallel().FirstOrDefault(e => e.Id == entity.Id) is null)
            {
                throw new ApiException(406, "Update to volunteering not owned by yourself is not allowed");
            }
            _volunteeringRepository.DeleteVolunteering(entity);
            if (await _volunteeringRepository.SaveChangesAsync())
            {
                return Accepted();
            }
            throw new ApiException();
        }
    }
}
