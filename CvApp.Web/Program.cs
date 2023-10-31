using CvApp.Core.Models;
using CvApp.Core.Services;
using CvApp.Data;
using CvApp.Services;
using Microsoft.EntityFrameworkCore;

namespace CvApp.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<CvDbContext>(options => 
                options.UseSqlServer(builder.Configuration.GetConnectionString("cvDb")));
            var mapper = AutoMapperConfig.CreateMapper();
            builder.Services.AddSingleton(mapper);
            builder.Services.AddSingleton<ICvValidations, CvEditValidations>();
            builder.Services.AddTransient<IDbService, DbService>();
            builder.Services.AddTransient<IEntityService<CurriculumVitae>, EntityService<CurriculumVitae>>();
            builder.Services.AddTransient<IEntityService<LanguageKnowledge>, EntityService<LanguageKnowledge>>();
            builder.Services.AddTransient<IEntityService<Education>, EntityService<Education>>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}