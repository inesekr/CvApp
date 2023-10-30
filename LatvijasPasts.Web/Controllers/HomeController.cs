using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using CvApp.Core.Models;
using CvApp.Core.Services;
using CvApp.Services;
using CvApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using AutoMapper;

namespace CvApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEntityService<CurriculumVitae> _cvService;
        private readonly IMapper _mapper;
        private readonly ICvValidations _validations;
        public HomeController(ILogger<HomeController> logger, 
            IEntityService<CurriculumVitae> cvService,
            //IEntityService<LanguageKnowledge> languageService,
            ICvValidations validations,
            IMapper mapper)
        {
            _logger = logger;
            _cvService = cvService;
            _mapper = mapper;
            _validations = validations;
        }

        public IActionResult Index()
        {
            var cvs = _cvService.Query().Include(cv => cv.LanguageKnowledges).ToList();
            var cvList = new CvListViewModel();
            cvList.CvItems = cvs.Select(_mapper.Map<CvItemViewModel>).ToList(); 
            //before using mapper:
            //cvList.CvItems = cvs.Select(cv => new CvItemViewModel
            //{
            //    Email = cv.Email,
            //    Id = cv.Id,
            //    FirstName = cv.FirstName,
            //    LastName = cv.LastName,
            //    OtherName = cv.OtherName,
            //    PhoneNumber = cv.PhoneNumber,
            //    LanguageKnowledge = cv.LanguageKnowledges.Select(l => new LanguageKnowledgeViewModel
            //    {
            //        CurriculumVitaeId = cv.Id,
            //        Id = l.Id,
            //        Language = l.Language,
            //        LanguageLevel = l.LanguageLevel
            //    }).ToList()
            //}).ToList();

            return View(cvList);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var cv = _cvService.GetById(id);
            if (cv != null)
            {
                _cvService.Delete(cv);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var cv = _cvService.QueryById(id)
                .Include(cv => cv.LanguageKnowledges)
                .SingleOrDefault();
            if (cv != null)
            {
                var model = _mapper.Map<CvItemViewModel>(cv);

                //before using AutoMapper:
                //var model = new CvItemViewModel
                //{
                //    FirstName = cv.FirstName,
                //    Email = cv.Email,
                //    Id = cv.Id,
                //    LastName = cv.LastName,
                //    OtherName = cv.OtherName,
                //    PhoneNumber = cv.PhoneNumber,
                //    LanguageKnowledge = cv.LanguageKnowledges.Select(l => new LanguageKnowledgeViewModel 
                //    {
                //        CurriculumVitaeId = cv.Id,
                //        Id = l.Id,
                //        Language = l.Language,
                //        LanguageLevel = l.LanguageLevel
                //    }).ToList()
                //};
                return View(model);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(CvItemViewModel cv)
        {

            //var addedLanguages = cv.LanguageKnowledge.Where(l => l.Id == 0).ToList();

            // And this moved to separate class:
            //var duplicateLanguages = cv.LanguageKnowledge.Any(l =>
            //    cv.LanguageKnowledge.Count(ll =>
            //    ll.Language.ToLowerInvariant() == l.Language.ToLowerInvariant()) > 1);

            //if(!ModelState.IsValid)
            //{
            //    return View(cv);
            //}

            //if(duplicateLanguages)
            //{
            //    ModelState.AddModelError("error", "language already exists");
            //    return View(cv);
            //}


            /*var duplicateLanguages = existingCv.LanguageKnowledges
                .Any(l => addedLanguages
                .Any(added =>
                added.Language.ToLowerInvariant() == l.Language.ToLowerInvariant()));
            */

            /*var duplicateLanguages = cv.LanguageKnowledge
                .Where(l =>
                existingCv.LanguageKnowledges
                .Any(c => 
                c.Language.ToLowerInvariant() == l.Language.ToLowerInvariant()));
            if (duplicateLanguages.Any())
            {
                ModelState.AddModelError("error", "language already exists");
                return View(cv);
            }
            */

            if (!_validations.IsValid(cv,ModelState))
            {
                return View(cv);
            }

            var existingCv = _cvService.GetById(cv.Id);

            //second variant, mapping all values:

            if (existingCv != null)
            {
                _mapper.Map(cv, existingCv);

                _cvService.Update(existingCv);
            }

            // first variant mapping just languages:
            //if (existingCv != null)
            //{
            //    existingCv.FirstName = cv.FirstName;
            //    existingCv.Email = cv.Email;
            //    existingCv.Id = cv.Id;
            //    existingCv.LastName = cv.LastName;
            //    existingCv.OtherName = cv.OtherName;
            //    existingCv.PhoneNumber = cv.PhoneNumber;
            //    existingCv.LanguageKnowledges = cv.LanguageKnowledge
            //        .Where(l => l.Id == 0)
            //        .Select(_mapper.Map<LanguageKnowledge>)
            //        .ToList();

            //    _cvService.Update(existingCv);
            //}

            // before using AutoMapper:
            //if(existingCv != null)
            //{
            //    existingCv.FirstName = cv.FirstName;
            //    existingCv.Email = cv.Email;
            //    existingCv.Id = cv.Id;
            //    existingCv.LastName = cv.LastName;
            //    existingCv.OtherName = cv.OtherName;
            //    existingCv.PhoneNumber = cv.PhoneNumber;
            //    existingCv.LanguageKnowledges = cv.LanguageKnowledge.Where(l => l.Id==0).Select(l => new LanguageKnowledge
            //    {
            //        Id = l.Id,
            //        Language = l.Language,
            //        LanguageLevel = l.LanguageLevel,
            //        CurriculumVitaeId = cv.Id
            //    }).ToList();
            //    _cvService.Update(existingCv);
            //}
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddLanguageSectionItem(int itemCount)
        {
            var model = new CvItemViewModel
            {
                LanguageKnowledge = Enumerable.Repeat(new LanguageKnowledgeViewModel(), itemCount+1).ToList()
            };
            return PartialView(model);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CvItemViewModel cv)
        {
            //_cvService.Create(new CurriculumVitae
            //{
            //    Email = cv.Email,
            //    FirstName = cv.FirstName,
            //    LastName = cv.LastName,
            //    OtherName = cv.OtherName,
            //    PhoneNumber = cv.PhoneNumber

            //});

            _cvService.Create(_mapper.Map<CurriculumVitae>(cv));
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}