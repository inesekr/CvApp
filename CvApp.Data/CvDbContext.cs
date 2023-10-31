using CvApp.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace CvApp.Data
{
    public class CvDbContext : DbContext
    {
        public CvDbContext(DbContextOptions<CvDbContext> options):base(options)
        {
            
        }

        DbSet<CurriculumVitae> CurriculumVitae { get; set; }
        DbSet<LanguageKnowledge> LanguageKnowledges { get; set; }   
        DbSet<Education> Education { get; set; }

    }
}
