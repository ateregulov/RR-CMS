using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RrCms.Controllers.Models
{
    public class NeedEditorRoleAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(!filterContext.HttpContext.User.IsInRole("Editor"))
                filterContext.Result = new RedirectResult("/");

            base.OnActionExecuting(filterContext);
        }
    }
}