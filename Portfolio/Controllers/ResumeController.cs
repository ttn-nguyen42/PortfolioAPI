using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Repositories;

namespace Portfolio.Controllers
{
    [Route("api/v1/resumes/{id}")]
    [ApiController]
    public class ResumeController: ControllerBase
    {
        private readonly IResumeRepository _repository;
        private readonly IMapper _mapper;

        public ResumeController(IResumeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ActionResult<>
    }
}
