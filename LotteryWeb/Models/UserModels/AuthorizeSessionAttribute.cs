using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LotteryWeb.Models.UserModels
{
    public class AuthorizeSessionAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            if (HttpContext.Current.Session["User"] == null)
            {
                filterContext.Result = new RedirectResult("/");
            }
            base.OnActionExecuting(filterContext);

        }


    }
}