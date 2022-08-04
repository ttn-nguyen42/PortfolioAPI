namespace Portfolio.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/resumes/{resumeId}/projects")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IResumeRepository _resumeRepository;
        private readonly IMapper _mapper;

        public ProjectController(IProjectRepository projectRepository, IResumeRepository resumeRepository, IMapper mapper)
        {
            _projectRepository = projectRepository ?? throw new ArgumentNullException(nameof(projectRepository));
            _resumeRepository = resumeRepository ?? throw new ArgumentNullException(nameof(resumeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<ProjectWithoutParentDto>))]
        [ProducesResponseType(404, Type = typeof(ExceptionMessage))]
        [Produces("application/json")]
        public async Task<IActionResult> GetProjects([FromRoute] int resumeId)
        {
            Resume? resume = await _resumeRepository.GetResumeAsync(resumeId);
            if (resume is null)
            {
                throw new ApiException(404, "Resume not found");
            }
            return Ok(_mapper.Map<ICollection<ProjectWithoutParentDto>>(resume.Projects));
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ProjectWithoutParentDto))]
        [ProducesResponseType(404, Type = typeof(ExceptionMessage))]
        [Produces("application/json")]
        public async Task<IActionResult> AddProject([FromRoute] int resumeId, [FromBody] ProjectCreationDto dto)
        {
            Resume? resume = await _resumeRepository.GetResumeAsync(resumeId);
            if (resume is null)
            {
                throw new ApiException(404, "Resume not found");
            }
            int typeId = dto.TypeId;
            ProjectType? type = await _projectRepository.GetProjectTypeAsync(typeId);
            if (type is null)
            {
                throw new ApiException(404, "Project type not found");
            }
            Project entity = _mapper.Map<Project>(dto);
            entity.Type = type;
            resume.Projects.Add(entity);
            if (await _resumeRepository.SaveChangesAsync())
            {
                return Ok(_mapper.Map<ProjectWithoutParentDto>(entity));
            }
            throw new ApiException();
        }

        [HttpPut("{projectId}")]
        [ProducesResponseType(200, Type = typeof(ProjectWithoutParentDto))]
        [ProducesResponseType(404, Type = typeof(ExceptionMessage))]
        [ProducesResponseType(406, Type = typeof(ExceptionMessage))]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateProject([FromRoute] int resumeId, [FromRoute] int projectId, [FromBody] ProjectUpdateDto dto)
        {
            Resume? resume = await _resumeRepository.GetResumeAsync(resumeId);
            if (resume is null)
            {
                throw new ApiException(404, "Resume not found");
            }
            Project? entity = await _projectRepository.GetProjectAsync(projectId);
            if (entity is null)
            {
                throw new ApiException(404, "Project not found");
            }
            if (resume.Projects.AsParallel().FirstOrDefault(c => c.Id == entity.Id) is null)
            {
                throw new ApiException(406, "Update to project not owned by yourself are not allowed");
            }
            _mapper.Map(dto, entity);
            if (await _projectRepository.SaveChangesAsync())
            {
                return Ok(_mapper.Map<ProjectWithoutParentDto>(entity));
            }
            throw new ApiException();
        }

        [HttpDelete("{projectId}")]
        [ProducesResponseType(202)]
        [ProducesResponseType(404, Type = typeof(ExceptionMessage))]
        [ProducesResponseType(406, Type = typeof(ExceptionMessage))]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteProject([FromRoute] int resumeId, [FromRoute] int projectId)
        {
            Resume? resume = await _resumeRepository.GetResumeAsync(resumeId);
            if (resume is null)
            {
                throw new ApiException(404, "Resume not found");
            }
            Project? entity = await _projectRepository.GetProjectAsync(projectId);
            if (entity is null)
            {
                throw new ApiException(404, "Project not found");
            }
            if (resume.Projects.AsParallel().FirstOrDefault(c => c.Id == entity.Id) is null)
            {
                throw new ApiException(406, "Update to project not owned by yourself are not allowed");
            }
            _projectRepository.RemoveProject(entity);
            if (await _projectRepository.SaveChangesAsync())
            {
                return Accepted();
            }
            throw new ApiException();
        }
    }

    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/project-types")]
    public class ProjectTypeController : ControllerBase
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IResumeRepository _resumeRepository;
        private readonly IMapper _mapper;

        public ProjectTypeController(IProjectRepository projectRepository, IResumeRepository resumeRepository, IMapper mapper)
        {
            _projectRepository = projectRepository ?? throw new ArgumentNullException(nameof(projectRepository));
            _resumeRepository = resumeRepository ?? throw new ArgumentNullException(nameof(resumeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<ProjectTypeDto>))]
        [Produces("application/json")]
        public async Task<IActionResult> GetTypes()
        {
            return Ok(_mapper.Map<ICollection<ProjectTypeDto>>(await _projectRepository.GetProjectTypesAsync()));
        }

        [HttpGet("{typeId}")]
        [ProducesResponseType(200, Type = typeof(ProjectTypeDto))]
        [ProducesResponseType(404, Type = typeof(ExceptionMessage))]
        [Produces("application/json")]
        public async Task<IActionResult> GetType(int typeId)
        {
            ProjectType? entity = await _projectRepository.GetProjectTypeAsync(typeId);
            if (entity is null)
            {
                throw new ApiException(404, "Type not found");
            }
            return Ok(_mapper.Map<ProjectTypeDto>(entity));
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ProjectTypeDto))]
        [ProducesResponseType(404, Type = typeof(ExceptionMessage))]
        [Produces("application/json")]
        public async Task<IActionResult> AddType([FromBody] ProjectTypeCreationDto dto)
        {
            ProjectType entity = _mapper.Map<ProjectType>(dto);
            _projectRepository.AddProjectType(entity);
            if (await _projectRepository.SaveChangesAsync())
            {
                return Ok(_mapper.Map<ProjectTypeDto>(entity));
            }
            throw new ApiException();
        }

        [HttpPut("{typeId}")]
        [ProducesResponseType(200, Type = typeof(ProjectTypeDto))]
        [ProducesResponseType(404, Type = typeof(ExceptionMessage))]
        [Produces("application/json")]
        public async Task<IActionResult> AddType([FromRoute] int typeId, [FromBody] ProjectTypeUpdateDto dto)
        {

            ProjectType? entity = await _projectRepository.GetProjectTypeAsync(typeId);
            if (entity is null)
            {
                throw new ApiException(404, "Type not found");
            }
            _mapper.Map(dto, entity);
            if (await _projectRepository.SaveChangesAsync())
            {
                return Ok(_mapper.Map<ProjectTypeDto>(entity));
            }
            throw new ApiException();
        }
    }
}
