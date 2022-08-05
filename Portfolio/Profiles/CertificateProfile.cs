namespace Portfolio.Profiles
{
    public class CertificateProfile : Profile
    {
        public CertificateProfile()
        {
            CreateMap<Certificate, CertificateWithoutParentDto>();
            CreateMap<CertificateDescription, CertificateDescriptionWithoutParentDto>();
            CreateMap<CertificateType, CertificateTypeDto>();
            CreateMap<CertificateLink, CertificateLinkWithoutParentDto>();

            CreateMap<CertificateCreationDto, Certificate>();
            CreateMap<CertificateDescriptionCreationDto, CertificateDescription>();
            CreateMap<CertificateTypeCreationDto, CertificateType>();
            CreateMap<CertificateTypeUpdateDto, CertificateType>();
            CreateMap<CertificateUpdateDto, Certificate>();
            CreateMap<CertificateLinkCreationDto, CertificateLink>();
        }
    }
}
