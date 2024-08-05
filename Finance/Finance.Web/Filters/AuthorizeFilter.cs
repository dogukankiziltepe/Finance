using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Web.Filters
{
    public class AuthorizeFilter : IAuthorizationFilter
    {

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var isAuthorized = context.HttpContext.Session.GetString("JWTToken") != null;
            if (!isAuthorized)
            {
                context.Result = new RedirectToActionResult("Index", "Auth", null);
            }
        }
    }
}
