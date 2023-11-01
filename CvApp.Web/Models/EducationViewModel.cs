using CvApp.Core.Enums;

namespace CvApp.Web.Models
{
    public class EducationViewModel
    {
        public int Id { get; set; }
        public string? UniversityName { get; set; }

        public string? Faculty { get; set; }
        public string? Profile { get; set; }
        public EducationLevel Degree { get; set; }
        public StudyActualState StudyStatus { get; set; }
        public int CurriculumVitaeId { get; set; }
    }
}
