using Group6_Profile.DTO.DTO;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Group6_Profile.web.WebExtends
{
    public class CheckCustomerAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session.Get<LoginUserDTO>("LoginUser") == null)
            {
                //Redirect To Login Page
                var result = new RedirectResult("~/Login/Index");
                filterContext.Result = result;
                return;
            }

        }
    }
}
