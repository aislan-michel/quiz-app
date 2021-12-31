using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Quiz.App.Extensions
{
    public static class ModelStateExtensions
    {
        public static void AddIdentityErrors(this ModelStateDictionary modelState, IEnumerable<IdentityError> identityErrors)
        {
            foreach (var error in identityErrors)
            {
                modelState.AddModelError($"identity-{error.Code}", error.Description);
            }
        }

        public static IEnumerable<string> GetErrors(this ModelStateDictionary modelState)
        {
            return modelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage);
        }
    }
}