using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Repositories;

namespace Portfolio.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/resumes/{id}")]
    [ApiController]
    public class ResumeController: ControllerBase
    {
        private readonly IResumeRepository _repository;
        private readonly IMapper _mapper;

        public ResumeController(IResumeRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> GetResume([FromRoute] int id)
        {
            Resume? entity = await _repository.GetResumeAsync(id);
            if (entity is null)
            {
                throw new HttpResponseException(404, "Resume not found");
            }
            return Ok(_mapper.Map<ResumeDto>(entity));
        }
    }
}
