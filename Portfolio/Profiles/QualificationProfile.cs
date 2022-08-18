using AutoMapper;

namespace Portfolio.Profiles
{
    public class QualificationProfile : Profile
    {
        public QualificationProfile()
        {
            CreateMap<Qualification, QualificationWithoutParentDto>();
            CreateMap<QualificationDescription, QualificationDescriptionWithoutParentDto>();
            CreateMap<QualificationCreationDto, Qualification>();
            CreateMap<QualificationDescriptionCreationDto, QualificationDescription>();
            CreateMap<QualificationUpdateDto, Qualification>();
        }
    }
}
