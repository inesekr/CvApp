using CvApp.Core.Models;
using CvApp.Core.Services;
using CvApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Host;

namespace CvApp.Web.Controllers
{
    public class EducationController : Controller
    {
        private readonly IEntityService<Education> _educationService;
        public EducationController(IEntityService<Education> educationService)
        {
            _educationService = educationService;
        }

        [HttpGet]
        public IActionResult AddEducationSectionItem(int itemCount)
        {
            var model = new CvItemViewModel
            {
                Education = Enumerable.Repeat(new EducationViewModel(), itemCount + 1).ToList()
            };
            return PartialView(model);
        }

        [HttpPost]
        public IActionResult DeleteEducationItem(int id)
        {
            var education = _educationService.GetById(id);
            if (education != null)
            {
                _educationService.Delete(education);
            }
            return Ok();
        }

    }
}

