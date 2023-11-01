using System.ComponentModel.DataAnnotations;

namespace CvApp.Core.Models
{
    public class CurriculumVitae : Entity
    {
        [MaxLength(50)]
        public string? FirstName { get; set; }
        [MaxLength(50)]
        public string? LastName { get; set; }
        [MaxLength(50)]
        public string? OtherName { get; set; }
        [MaxLength(13)]
        public string? PhoneNumber { get; set; }
        [MaxLength(50)]
        public string? Email { get; set; }
        public ICollection<LanguageKnowledge> LanguageKnowledges { get; set; } = new List<LanguageKnowledge>();
        public ICollection<Education> Education { get; set; } = new List<Education>();
    }
}
