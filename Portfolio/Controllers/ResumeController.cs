using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Portfolio.Repositories;

namespace Portfolio.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/resumes")]
    [ApiController]
    public class ResumeController : ControllerBase
    {
        private readonly IResumeRepository _repository;
        private readonly IMapper _mapper;

        public ResumeController(IResumeRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("{id}", Name = "GetResume")]
        public async Task<IActionResult> GetResume([FromRoute] int id)
        {
            Resume? entity = await _repository.GetResumeAsync(id);
            if (entity is null)
            {
                throw new HttpResponseException(404, "Resume not found");
            }
            return Ok(_mapper.Map<ResumeDto>(entity));
        }

        [HttpPost]
        public async Task<IActionResult> AddResume([FromBody] ResumeCreationDto dto)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<string> errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
                throw new HttpResponseException(400, "Bad request")
                {
                    Errors = errors.ToList(),
                };
            }
            Resume entity = _mapper.Map<Resume>(dto);
            _repository.AddResume(entity);
            if (await _repository.SaveChangesAsync())
            {
                return CreatedAtRoute("GetResume", new
                {
                    Id = entity.Id,
                }, _mapper.Map<ResumeWithInfoAndAboutDto>(entity));
            };
            throw new HttpResponseException(500, "Changes not saved");
        }
    }


}
