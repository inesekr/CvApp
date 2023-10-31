using CvApp.Web.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CvApp.Web
{
    public class CvEditValidations :ICvValidations
    {
        public bool IsValid(CvItemViewModel cv, ModelStateDictionary modelState)
        {
            if (!modelState.IsValid)
            {
                return false;
            }

            var duplicateLanguages = cv.LanguageKnowledge.Any(l =>
                          cv.LanguageKnowledge.Count(ll =>
                          ll.Language.ToLowerInvariant() == l.Language.ToLowerInvariant()) > 1);

            if (duplicateLanguages)
            {
                modelState.AddModelError("error", "language already exists");
                return false;
            }

            return true;
        }
    }
}