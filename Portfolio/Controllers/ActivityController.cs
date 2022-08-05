namespace Portfolio.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/resumes/{resumeId}/activities")]
    public class ActivityController : ControllerBase
    {
        private readonly IActivitiesRepository _activitiesRepository;
        private readonly IResumeRepository _resumeRepository;
        private readonly IMapper _mapper;

        public ActivityController(IActivitiesRepository activitiesRepository, IResumeRepository resumeRepository, IMapper mapper)
        {
            _activitiesRepository = activitiesRepository ?? throw new ArgumentNullException(nameof(activitiesRepository));
            _resumeRepository = resumeRepository ?? throw new ArgumentNullException(nameof(resumeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<ActivityWithoutParentDto>))]
        [ProducesResponseType(404, Type = typeof(ExceptionMessage))]
        [Produces("application/json")]
        public async Task<IActionResult> GetAll([FromRoute] int resumeId)
        {
            Resume? resume = await _resumeRepository.GetResumeAsync(resumeId);
            if (resume is null)
            {
                throw new ApiException(404, "Resume not found");
            }
            return Ok(_mapper.Map<ICollection<ActivityWithoutParentDto>>(resume.Activities));
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ActivityWithoutParentDto))]
        [ProducesResponseType(404, Type = typeof(ExceptionMessage))]
        [Produces("application/json")]
        public async Task<IActionResult> AddOne([FromRoute] int resumeId, [FromBody] ActivityCreationDto dto)
        {
            Resume? resume = await _resumeRepository.GetResumeAsync(resumeId);
            if (resume is null)
            {
                throw new ApiException(404, "Resume not found");
            }
            int typeId = dto.TypeId;
            ActivityType? type = await _activitiesRepository.GetActivityTypeAsync(typeId);
            if (type is null)
            {
                throw new ApiException(404, "Activity type not found");
            }
            Activity entity = _mapper.Map<Activity>(dto);
            entity.Type = type;
            resume.Activities.Add(entity);
            if (await _resumeRepository.SaveChangesAsync())
            {
                return Ok(_mapper.Map<ActivityWithoutParentDto>(entity));
            }
            throw new ApiException();
        }

        [HttpPut("{ActivityId}")]
        [ProducesResponseType(200, Type = typeof(ActivityWithoutParentDto))]
        [ProducesResponseType(404, Type = typeof(ExceptionMessage))]
        [ProducesResponseType(406, Type = typeof(ExceptionMessage))]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateOne([FromRoute] int resumeId, [FromRoute] int ActivityId, [FromBody] ActivityUpdateDto dto)
        {
            Resume? resume = await _resumeRepository.GetResumeAsync(resumeId);
            if (resume is null)
            {
                throw new ApiException(404, "Resume not found");
            }
            Activity? entity = await _activitiesRepository.GetActivityAsync(ActivityId);
            if (entity is null)
            {
                throw new ApiException(404, "Activity not found");
            }
            if (resume.Activities.AsParallel().FirstOrDefault(c => c.Id == entity.Id) is null)
            {
                throw new ApiException(406, "Update to activity not owned by yourself are not allowed");
            }
            _mapper.Map(dto, entity);
            if (await _activitiesRepository.SaveChangesAsync())
            {
                return Ok(_mapper.Map<ActivityWithoutParentDto>(entity));
            }
            throw new ApiException();
        }

        [HttpDelete("{ActivityId}")]
        [ProducesResponseType(202)]
        [ProducesResponseType(404, Type = typeof(ExceptionMessage))]
        [ProducesResponseType(406, Type = typeof(ExceptionMessage))]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteOne([FromRoute] int resumeId, [FromRoute] int ActivityId)
        {
            Resume? resume = await _resumeRepository.GetResumeAsync(resumeId);
            if (resume is null)
            {
                throw new ApiException(404, "Resume not found");
            }
            Activity? entity = await _activitiesRepository.GetActivityAsync(ActivityId);
            if (entity is null)
            {
                throw new ApiException(404, "Activity not found");
            }
            if (resume.Activities.AsParallel().FirstOrDefault(c => c.Id == entity.Id) is null)
            {
                throw new ApiException(406, "Update to activity not owned by yourself are not allowed");
            }
            _activitiesRepository.RemoveActivity(entity);
            if (await _activitiesRepository.SaveChangesAsync())
            {
                return Accepted();
            }
            throw new ApiException();
        }
    }

    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/activity-types")]
    public class ActivityTypeController : ControllerBase
    {
        private readonly IActivitiesRepository _activitiesRepository;
        private readonly IMapper _mapper;

        public ActivityTypeController(IActivitiesRepository activitiesRepository, IMapper mapper)
        {
            _activitiesRepository = activitiesRepository ?? throw new ArgumentNullException(nameof(activitiesRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<ActivityWithoutParentDto>))]
        [Produces("application/json")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_mapper.Map<ICollection<ActivityWithoutParentDto>>(await _activitiesRepository.GetActivityTypesAsync()));
        }

        [HttpGet("{typeId}")]
        [ProducesResponseType(200, Type = typeof(ActivityWithoutParentDto))]
        [ProducesResponseType(404, Type = typeof(ExceptionMessage))]
        [Produces("application/json")]
        public async Task<IActionResult> GetOne([FromRoute] int typeId)
        {
            ActivityType? entity = await _activitiesRepository.GetActivityTypeAsync(typeId);
            if (entity is null)
            {
                throw new ApiException(404, "Type not found");
            }
            return Ok(_mapper.Map<ActivityTypeWithoutParentDto>(entity));
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ActivityTypeWithoutParentDto))]
        [ProducesResponseType(404, Type = typeof(ExceptionMessage))]
        [Produces("application/json")]
        public async Task<IActionResult> AddOne([FromBody] ActivityTypeCreationDto dto)
        {
            ActivityType entity = _mapper.Map<ActivityType>(dto);
            await _activitiesRepository.AddActivityType(entity);
            if (await _activitiesRepository.SaveChangesAsync())
            {
                return Ok(_mapper.Map<ActivityTypeWithoutParentDto>(entity));
            }
            throw new ApiException();
        }

        [HttpPut("{typeId}")]
        [ProducesResponseType(200, Type = typeof(ActivityTypeWithoutParentDto))]
        [ProducesResponseType(404, Type = typeof(ExceptionMessage))]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateOne([FromRoute] int typeId, [FromBody] ActivityTypeUpdateDto dto)
        {
            ActivityType? entity = await _activitiesRepository.GetActivityTypeAsync(typeId);
            if (entity is null)
            {
                throw new ApiException(404, "Type not found");
            }
            _mapper.Map(dto, entity);
            if (await _activitiesRepository.SaveChangesAsync())
            {
                return Ok(_mapper.Map<ActivityTypeWithoutParentDto>(entity));
            }
            throw new ApiException();
        }
    }
}
