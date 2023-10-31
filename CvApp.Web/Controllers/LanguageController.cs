using CvApp.Core.Models;
using CvApp.Core.Services;
using CvApp.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CvApp.Web.Controllers
{
    public class LanguageController : Controller
    {
        private readonly IEntityService<LanguageKnowledge> _languageService;

        public LanguageController(IEntityService<LanguageKnowledge> languageService)
        {
            _languageService = languageService;
        }

        [HttpGet]
        public IActionResult AddLanguageSectionItem(int itemCount)
        {
            var model = new CvItemViewModel
            {
                LanguageKnowledge = Enumerable.Repeat(new LanguageKnowledgeViewModel(), itemCount + 1).ToList()
            };

            return PartialView(model);
        }

        [HttpPost]
        public IActionResult DeleteLanguageItem(int id)
        {
            var languageKnowledge = _languageService.GetById(id);
            if (languageKnowledge != null)
            {
                _languageService.Delete(languageKnowledge);
            }

            return Ok();
        }
    }
}
