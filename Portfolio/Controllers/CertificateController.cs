

using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/resumes/{resumeId}/certificates")]
    public class CertificateController : ControllerBase
    {
        private readonly ICertificateRepository _certificateRepository;
        private readonly IResumeRepository _resumeRepository;
        private readonly IMapper _mapper;

        public CertificateController(ICertificateRepository certificateRepository, IResumeRepository resumeRepository, IMapper mapper)
        {
            _certificateRepository = certificateRepository ?? throw new ArgumentNullException(nameof(certificateRepository));
            _resumeRepository = resumeRepository ?? throw new ArgumentNullException(nameof(resumeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<CertificateWithoutParentDto>))]
        [ProducesResponseType(404, Type = typeof(ExceptionMessage))]
        [Produces("application/json")]
        public async Task<IActionResult> GetCertificates([FromRoute] int resumeId)
        {
            Resume? resume = await _resumeRepository.GetResumeAsync(resumeId);
            if (resume is null)
            {
                throw new ApiException(404, "Resume not found");
            }
            return Ok(_mapper.Map<ICollection<CertificateWithoutParentDto>>(resume.Certificates));
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(CertificateWithoutParentDto))]
        [ProducesResponseType(404, Type = typeof(ExceptionMessage))]
        [Produces("application/json")]
        public async Task<IActionResult> AddCertificate([FromRoute] int resumeId, [FromBody] CertificateCreationDto dto)
        {
            Resume? resume = await _resumeRepository.GetResumeAsync(resumeId);
            if (resume is null)
            {
                throw new ApiException(404, "Resume not found");
            }
            int typeId = dto.TypeId;
            CertificateType? type = await _certificateRepository.GetCertificateTypeAsync(typeId);
            if (type is null)
            {
                throw new ApiException(404, "Certificate type not found");
            }  
            Certificate entity = _mapper.Map<Certificate>(dto);
            entity.Type = type;
            resume.Certificates.Add(entity);
            if (await _resumeRepository.SaveChangesAsync())
            {
                return Ok(_mapper.Map<CertificateWithoutParentDto>(entity));
            }
            throw new ApiException();
        }

        [HttpPut("{certificateId}")]
        [ProducesResponseType(200, Type = typeof(CertificateWithoutParentDto))]
        [ProducesResponseType(404, Type = typeof(ExceptionMessage))]
        [ProducesResponseType(406, Type = typeof(ExceptionMessage))]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateCertificate([FromRoute] int resumeId, [FromRoute] int certificateId, [FromBody] CertificateUpdateDto dto)
        {
            Resume? resume = await _resumeRepository.GetResumeAsync(resumeId);
            if (resume is null)
            {
                throw new ApiException(404, "Resume not found");
            }
            Certificate? entity = await _certificateRepository.GetCertificateAsync(certificateId);
            if (entity is null)
            {
                throw new ApiException(404, "Certificate not found");
            }
            if (resume.Certificates.AsParallel().FirstOrDefault(c => c.Id == entity.Id) is null)
            {
                throw new ApiException(406, "Update to certificate not owned by yourself are not allowed");
            }
            _mapper.Map(dto, entity);
            if (await _certificateRepository.SaveChangesAsync())
            {
                return Ok(_mapper.Map<CertificateWithoutParentDto>(entity));
            }
            throw new ApiException();
        }

        [HttpDelete("{certificateId}")]
        [ProducesResponseType(202)]
        [ProducesResponseType(404, Type = typeof(ExceptionMessage))]
        [ProducesResponseType(406, Type = typeof(ExceptionMessage))]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteCertificate([FromRoute] int resumeId, [FromRoute] int certificateId)
        {
            Resume? resume = await _resumeRepository.GetResumeAsync(resumeId);
            if (resume is null)
            {
                throw new ApiException(404, "Resume not found");
            }
            Certificate? entity = await _certificateRepository.GetCertificateAsync(certificateId);
            if (entity is null)
            {
                throw new ApiException(404, "Certificate not found");
            }
            if (resume.Certificates.AsParallel().FirstOrDefault(c => c.Id == entity.Id) is null)
            {
                throw new ApiException(406, "Update to certificate not owned by yourself are not allowed");
            }
            _certificateRepository.RemoveCertificate(entity);
            if (await _certificateRepository.SaveChangesAsync())
            {
                return Accepted();
            }
            throw new ApiException();
        }
    }

    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/certificate-types")]
    public class CertificateTypeController : ControllerBase
    {
        private readonly ICertificateRepository _certificateRepository;
        private readonly IResumeRepository _resumeRepository;
        private readonly IMapper _mapper;

        public CertificateTypeController(ICertificateRepository certificateRepository, IResumeRepository resumeRepository, IMapper mapper)
        {
            _certificateRepository = certificateRepository ?? throw new ArgumentNullException(nameof(certificateRepository));
            _resumeRepository = resumeRepository ?? throw new ArgumentNullException(nameof(resumeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<CertificateTypeDto>))]
        [Produces("application/json")]
        public async Task<IActionResult> GetTypes()
        {
            return Ok(_mapper.Map<ICollection<CertificateTypeDto>>(await _certificateRepository.GetCertificateTypesAsync()));
        }

        [HttpGet("{typeId}")]
        [ProducesResponseType(200, Type = typeof(CertificateTypeDto))]
        [ProducesResponseType(404, Type = typeof(ExceptionMessage))]
        [Produces("application/json")]
        public async Task<IActionResult> GetType([FromRoute] int typeId)
        {
            CertificateType? entity = await _certificateRepository.GetCertificateTypeAsync(typeId);
            if (entity is null)
            {
                throw new ApiException(404, "Certificate type not found");
            }
            return Ok(_mapper.Map<CertificateTypeDto>(entity));
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(CertificateTypeDto))]
        [ProducesResponseType(404, Type = typeof(ExceptionMessage))]
        [Produces("application/json")]
        public async Task<IActionResult> AddType([FromBody] CertificateTypeCreationDto dto)
        {
            CertificateType entity = _mapper.Map<CertificateType>(dto);
            _certificateRepository.AddCertificateType(entity);
            if (await _certificateRepository.SaveChangesAsync())
            {
                return Ok(_mapper.Map<CertificateTypeDto>(entity));
            }
            throw new ApiException();
        }

        [HttpPut("{typeId}")]
        [ProducesResponseType(200, Type = typeof(CertificateTypeDto))]
        [ProducesResponseType(404, Type = typeof(ExceptionMessage))]
        [Produces("application/json")]
        public async Task<IActionResult> AddType([FromRoute] int typeId, [FromBody] CertificateTypeUpdateDto dto)
        {

            CertificateType? entity = await _certificateRepository.GetCertificateTypeAsync(typeId);
            if (entity is null)
            {
                throw new ApiException(404, "Type not found");
            }
            _mapper.Map(dto, entity);
            if (await _certificateRepository.SaveChangesAsync())
            {
                return Ok(_mapper.Map<CertificateTypeDto>(entity));
            }
            throw new ApiException();
        }
    }
}
