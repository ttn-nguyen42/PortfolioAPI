using AutoMapper;

namespace Portfolio.Profiles
{
    public class TechnicalSkillProfile : Profile
    {
        public TechnicalSkillProfile()
        {
            CreateMap<TechnicalSkill, TechnicalSkillWithoutParentDto>();
            CreateMap<TechnicalSkillType, TechnicalSkillTypeDto>();
            CreateMap<TechnicalSkillDescription, TechnicalSkillDescriptionWithoutParentDto>();
            CreateMap<TechnicalSkillTypeCreationDto, TechnicalSkillType>();
            CreateMap<TechnicalSkillDescriptionCreationDto, TechnicalSkillDescription>();
            CreateMap<TechnicalSkillCreationDto, TechnicalSkill>();
            CreateMap<TechnicalSkillUpdateDto, TechnicalSkill>();
        }
    }
}
