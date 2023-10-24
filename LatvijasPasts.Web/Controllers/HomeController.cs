﻿using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using LatvijasPasts.Core.Models;
using LatvijasPasts.Core.Services;
using LatvijasPasts.Services;
using LatvijasPasts.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LatvijasPasts.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEntityService<CurriculumVitae> _cvService;

        public HomeController(ILogger<HomeController> logger, IEntityService<CurriculumVitae> cvService)
        {
            _logger = logger;
            _cvService = cvService;
        }

        public IActionResult Index()
        {
            var cvs = _cvService.Query().Include(cv => cv.LanguageKnowledges).ToList();
            var cvList = new CvListViewModel();
            cvList.CvItems = cvs.Select(cv => new CvItemViewModel
            {
                Email = cv.Email,
                Id = cv.Id,
                Name = cv.FirstName,
                LastName = cv.LastName,
                OtherName = cv.OtherName,
                PhoneNumber = cv.PhoneNumber,
                LanguageKnowledge = cv.LanguageKnowledges.Select(l => new LanguageKnowledgeViewModel
                {
                    CurriculumVitaeId = cv.Id,
                    Id = l.Id,
                    Language = l.Language,
                    LanguageLevel = l.LanguageLevel
                }).ToList()
            }).ToList();
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
                var model = new CvItemViewModel
                {
                    Name = cv.FirstName,
                    Email = cv.Email,
                    Id = cv.Id,
                    LastName = cv.LastName,
                    OtherName = cv.OtherName,
                    PhoneNumber = cv.PhoneNumber,
                    LanguageKnowledge = cv.LanguageKnowledges.Select(l => new LanguageKnowledgeViewModel 
                    {
                        CurriculumVitaeId = cv.Id,
                        Id = l.Id,
                        Language = l.Language,
                        LanguageLevel = l.LanguageLevel
                    }).ToList()
                };
                return View(model);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(CvItemViewModel cv)
        {
            var existingCv = _cvService.GetById(cv.Id);
            if(existingCv != null)
            {
                existingCv.FirstName = cv.Name;
                existingCv.Email = cv.Email;
                existingCv.Id = cv.Id;
                existingCv.LastName = cv.LastName;
                existingCv.OtherName = cv.OtherName;
                existingCv.PhoneNumber = cv.PhoneNumber;
                _cvService.Update(existingCv);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CvItemViewModel cv)
        {
            _cvService.Create(new CurriculumVitae
            {
                Email = cv.Email,
                FirstName = cv.Name,
                LastName = cv.LastName,
                OtherName = cv.OtherName,
                PhoneNumber = cv.PhoneNumber

            });
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