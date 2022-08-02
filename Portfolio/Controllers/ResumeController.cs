﻿using AutoMapper;
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
                throw new ApiException(404, "Resume not found");
            }
            return Ok(_mapper.Map<ResumeDto>(entity));
        }

        [HttpPost]
        public async Task<IActionResult> AddResume([FromBody] ResumeCreationDto dto)
        {
            Resume entity = _mapper.Map<Resume>(dto);
            _repository.AddResume(entity);
            if (await _repository.SaveChangesAsync())
            {
                return CreatedAtRoute("GetResume", new
                {
                    Id = entity.Id,
                }, _mapper.Map<ResumeWithInfoAndAboutDto>(entity));
            };
            throw new ApiException();
        }

        [HttpPut("{resumeId}")]
        public async Task<IActionResult> UpdateResume([FromRoute] int resumeId, [FromBody] ResumeUpdateDto dto)
        {
            Resume? resume = await _repository.GetResumeAsync(resumeId);
            if (resume is null)
            {
                throw new ApiException(404, "Resume not found");
            }
            _mapper.Map(dto, resume);
            if (await _repository.SaveChangesAsync())
            {
                // Can return NoContent but will takes one more request if a read is needed afterward
                return Ok(resume);
            }
            throw new ApiException();
        }
    }

}
