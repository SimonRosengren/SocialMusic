using SocialMusic.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialMusic.Attributes
{
    public class AuthenticateAttribute : ActionFilterAttribute
    {
        public string View { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            var authenticationHandler = new AuthentificationHandler(filterContext.HttpContext.Session);

            if (!authenticationHandler.IsAuthenticated())
            {
                if (string.IsNullOrWhiteSpace(View))
                {
                    filterContext.Result = new HttpStatusCodeResult(403);
                }
                filterContext.Result = new ViewResult()
                {
                    ViewName = "NotAuthenticated"
                };
            }
        }
    }
}