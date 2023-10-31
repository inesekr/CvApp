using AutoMapper;
using CvApp.Core.Models;
using CvApp.Web.Models;

namespace CvApp.Web
{
    public class AutoMapperConfig
    {
        public static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CurriculumVitae, CvItemViewModel>()
                    .ForMember(c => c.LanguageKnowledge, opt => opt.MapFrom(cv => cv.LanguageKnowledges))            
                    .ForMember(c => c.Education, opt => opt.MapFrom(cv => cv.Education));

                cfg.CreateMap<CvItemViewModel, CurriculumVitae>()
                    .ForMember(c => c.LanguageKnowledges, opt => opt.MapFrom(cv => cv.LanguageKnowledge))
                    .ForMember(c => c.Education, opt => opt.MapFrom(cv => cv.Education));

                cfg.CreateMap<LanguageKnowledge, LanguageKnowledgeViewModel>();
                cfg.CreateMap<LanguageKnowledgeViewModel, LanguageKnowledge> ()
                    .ForMember(c => c.CurriculumVitae, opt => opt.Ignore());

               
               
                cfg.CreateMap<Education, EducationViewModel>();
                cfg.CreateMap<EducationViewModel, Education>()
                    .ForMember(c => c.CurriculumVitae, opt => opt.Ignore());
            });
            #if DEBUG
            config.AssertConfigurationIsValid();
            #endif
            return config.CreateMapper();
        } 
    }
}
