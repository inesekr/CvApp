using CvApp.Core.Enums;
using CvApp.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace CvApp.Web.Models
{
    public class LanguageKnowledgeViewModel
    {
        public int Id { get; set; }
        [Required]
        public string? Language { get; set; }
        public KnowledgeLevel LanguageLevel { get; set; }
        public int CurriculumVitaeId { get; set; }
    }
}
