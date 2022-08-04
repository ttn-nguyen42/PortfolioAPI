using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/resumes/{resumeId}/skills")]
    public class SkillController : ControllerBase
    {
        private readonly ISkillRepository _skillRepository;
        private readonly IResumeRepository _resumeRepository;
        private readonly IMapper _mapper;

        public SkillController(ISkillRepository skillRepository, IResumeRepository resumeRepository, IMapper mapper)
        {
            _skillRepository = skillRepository ?? throw new ArgumentNullException(nameof(skillRepository));
            _resumeRepository = resumeRepository ?? throw new ArgumentNullException(nameof(resumeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<TechnicalSkillWithoutParentDto>))]
        [ProducesResponseType(404, Type = typeof(ExceptionMessage))]
        [Produces("application/json")]
        public async Task<IActionResult> GetSkills([FromRoute] int resumeId)
        {
            Resume? resume = await _resumeRepository.GetResumeAsync(resumeId);
            if (resume is null)
            {
                throw new ApiException(404, "Resume not found");
            }
            return Ok(_mapper.Map<ICollection<TechnicalSkillWithoutParentDto>>(resume.Skills));
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(TechnicalSkillWithoutParentDto))]
        [ProducesResponseType(404, Type = typeof(ExceptionMessage))]
        [Produces("application/json")]
        public async Task<IActionResult> AddSkill([FromRoute] int resumeId, [FromBody] TechnicalSkillCreationDto dto)
        {
            Resume? resume = await _resumeRepository.GetResumeAsync(resumeId);
            if (resume is null)
            {
                throw new ApiException(404, "Resume not found");
            }
            int typeId = dto.TypeId;
            TechnicalSkillType? type = await _skillRepository.GetSkillTypeAsync(typeId);
            if (type is null)
            {
                throw new ApiException(404, "Skill type not found");
            }
            TechnicalSkill entity = _mapper.Map<TechnicalSkill>(dto);
            entity.Type = type;
            resume.Skills.Add(entity);
            _skillRepository.AddSkill(entity);
            if (await _skillRepository.SaveChangesAsync())
            {
                return Ok(_mapper.Map<TechnicalSkillWithoutParentDto>(entity));
            }
            throw new ApiException(500, "No changes happened");
        }

        [HttpPut("{skillId}")]
        [ProducesResponseType(200, Type = typeof(TechnicalSkillWithoutParentDto))]
        [ProducesResponseType(404, Type = typeof(ExceptionMessage))]
        [ProducesResponseType(406, Type = typeof(ExceptionMessage))]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateSkill([FromRoute] int resumeId, [FromRoute] int skillId, [FromBody] TechnicalSkillUpdateDto dto)
        {
            Resume? resume = await _resumeRepository.GetResumeAsync(resumeId);
            if (resume is null)
            {
                throw new ApiException(404, "Resume not found");
            }
            TechnicalSkill? skill = await _skillRepository.GetSkillAsync(skillId);
            if (skill is null)
            {
                throw new ApiException(404, "Skill not found");
            }
            if (resume.Skills.AsParallel().FirstOrDefault(s => s.Id == skill.Id) is null)
            {
                throw new ApiException(406, "Update to skills not owned by yourself are not allowed");
            }
            _mapper.Map(dto, skill);
            if (await _resumeRepository.SaveChangesAsync())
            {
                return Ok(_mapper.Map<TechnicalSkillWithoutParentDto>(skill));
            }
            throw new ApiException();
        }

        [HttpDelete("{skillId}")]
        [ProducesResponseType(202)]
        [ProducesResponseType(404, Type = typeof(ExceptionMessage))]
        [ProducesResponseType(406, Type = typeof(ExceptionMessage))]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteSkill([FromRoute] int resumeId, [FromRoute] int skillId)
        {
            Resume? resume = await _resumeRepository.GetResumeAsync(resumeId);
            if (resume is null)
            {
                throw new ApiException(404, "Resume not found");
            }
            TechnicalSkill? skill = await _skillRepository.GetSkillAsync(skillId);
            if (skill is null)
            {
                throw new ApiException(404, "Skill not found");
            }
            if (resume.Skills.AsParallel().FirstOrDefault(s => s.Id == skill.Id) is null)
            {
                throw new ApiException(406, "Update to skills not owned by yourself are not allowed");
            }
            _skillRepository.RemoveSkill(skill);
            if (await _skillRepository.SaveChangesAsync())
            {
                return Accepted();
            }
            throw new ApiException();
        }
    }

    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/skill-types")]
    public class SkillTypeController : ControllerBase
    {
        private readonly ISkillRepository _repository;
        private readonly IMapper _mapper;

        public SkillTypeController(ISkillRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<TechnicalSkillTypeDto>))]
        [Produces("application/json")]
        public async Task<IActionResult> GetSkillTypes()
        {
            return Ok(_mapper.Map<TechnicalSkillTypeDto>(await _repository.GetSkillTypesAsync()));
        }

        [HttpGet("{typeId}", Name = "GetSkillType")]
        [ProducesResponseType(200, Type = typeof(TechnicalSkillTypeDto))]
        [ProducesResponseType(404, Type = typeof(ExceptionMessage))]
        [Produces("application/json")]
        public async Task<IActionResult> GetSkillType([FromRoute] int typeId)
        {
            TechnicalSkillType? type = await _repository.GetSkillTypeAsync(typeId);
            if (type is null)
            {
                throw new ApiException(404, "Skill type not found");
            }
            return Ok(_mapper.Map<TechnicalSkillTypeDto>(type));
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(TechnicalSkillTypeDto))]
        [ProducesResponseType(404, Type = typeof(ExceptionMessage))]
        [Produces("application/json")]
        public async Task<IActionResult> AddSkillType([FromBody] TechnicalSkillTypeCreationDto dto)
        {
            TechnicalSkillType type = _mapper.Map<TechnicalSkillType>(dto);
            _repository.AddSkillType(type);
            if (await _repository.SaveChangesAsync())
            {
                return Ok(_mapper.Map<TechnicalSkillTypeDto>(type));
            }
            throw new ApiException();
        }
    }
}
