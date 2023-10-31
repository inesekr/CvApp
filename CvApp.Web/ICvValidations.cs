using CvApp.Web.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CvApp.Web
{
    public interface ICvValidations
    {
        bool IsValid(CvItemViewModel cv, ModelStateDictionary modelState);
    }

}
