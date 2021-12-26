using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Quiz.App.Filters
{
    public class ModelStateFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid) return;
            
            var errors = 
                context.ModelState.SelectMany(x => x.Value?.Errors).Select(x => x.ErrorMessage);

            context.Result = new BadRequestObjectResult(errors);
        }
    }
}