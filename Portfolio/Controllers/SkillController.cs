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
        public async Task<IActionResult> GetSkills([FromRoute] int resumeId)
        {
            Resume? resume = await _resumeRepository.GetResumeAsync(resumeId);
            if (resume is null)
            {
                throw new HttpResponseException(404, "Resume not found");
            }
            return Ok(_mapper.Map<ICollection<TechnicalSkillWithoutParentDto>>(resume.Skills));
        }

        [HttpPost]
        public async Task<IActionResult> AddSkill([FromRoute] int resumeId, [FromBody] TechnicalSkillCreationDto dto)
        {
            Resume? resume = await _resumeRepository.GetResumeAsync(resumeId);
            if (resume is null)
            {
                throw new HttpResponseException(404, "Resume not found");
            }
            int typeId = dto.TypeId;
            TechnicalSkillType? type = await _skillRepository.GetSkillTypeAsync(typeId);
            if (type is null)
            {
                throw new HttpResponseException(404, "Skill type not found");
            }
            TechnicalSkill entity = _mapper.Map<TechnicalSkill>(dto);
            entity.Type = type;
            resume.Skills.Add(entity);
            _skillRepository.AddSkill(entity);
            if (await _skillRepository.SaveChangesAsync())
            {
                return Ok(_mapper.Map<TechnicalSkillWithoutParentDto>(entity));
            }
            throw new HttpResponseException(500, "No changes happened");
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
        public async Task<IActionResult> GetSkillTypes()
        {
            return Ok(await _repository.GetSkillTypesAsync());
        }

        [HttpGet("{typeId}", Name = "GetSkillType")]
        public async Task<IActionResult> GetSkillType([FromRoute] int typeId)
        {
            TechnicalSkillType? type = await _repository.GetSkillTypeAsync(typeId);
            if (type is null)
            {
                throw new HttpResponseException(404, "Skill type not found");
            }
            return Ok(type);
        }

        [HttpPost]
        public async Task<IActionResult> AddSkillType([FromBody] TechnicalSkillTypeCreationDto dto)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<string> errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
                throw new HttpResponseException(400, "Invalid input")
                {
                    Errors = errors.ToList(),
                };
            }
            TechnicalSkillType type = _mapper.Map<TechnicalSkillType>(dto);
            _repository.AddSkillType(type);
            if (await _repository.SaveChangesAsync())
            {
                return CreatedAtRoute("GetSkillType", new
                {
                    TypeId = type.Id,
                }, _mapper.Map<TechnicalSkillTypeDto>(type));
            }
            throw new HttpResponseException(500, "No changes happened");
        }
    }
}
