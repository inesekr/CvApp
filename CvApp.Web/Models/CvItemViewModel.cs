//using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace CvApp.Web.Models
{
    public class CvItemViewModel
    {
        public int Id { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        public string? OtherName { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? PhoneNumber {  get; set; }
        public List<LanguageKnowledgeViewModel> LanguageKnowledge { get; set; } = new List<LanguageKnowledgeViewModel>();

    }
}
