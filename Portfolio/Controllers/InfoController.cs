using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/resumes/{id}/info")]
    public class InfoController: ControllerBase
    {
        private readonly IResumeRepository _repository;
        private readonly IMapper _mapper;

        public InfoController(IResumeRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(InfoDto))]
        [ProducesResponseType(404, Type = typeof(ExceptionMessage))]
        [Produces("application/json")]
        public async Task<IActionResult> GetInfo([FromRoute] int id)
        {
            Resume? entity = await _repository.GetResumeAsync(id);
            if (entity is null)
            {
                throw new ApiException(404, "Resume not found");
            }
            return Ok(_mapper.Map<InfoDto>(entity));
        }
    }
}
