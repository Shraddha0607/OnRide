using Microsoft.AspNetCore.Mvc.Filters;

namespace OnRideApp.CustomActionFilters
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            context.Result = new BadRequestResult();
        }
    }
}
