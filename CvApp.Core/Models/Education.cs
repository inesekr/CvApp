using System.ComponentModel.DataAnnotations;
using CvApp.Core.Enums;

namespace CvApp.Core.Models
{
    public class Education : Entity
    {
        [MaxLength(100)]
        public string? UniversityName { get; set; }
        public string Faculty { get; set; }
        public string Profile {  get; set; }
        public EducationLevel  Degree { get; set; }
        public StudyActualState StudyStatus { get; set; }
        public int CurriculumVitaeId { get; set; }
        public CurriculumVitae CurriculumVitae { get; set; }
    }
 }
