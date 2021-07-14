using com.course.blog.entities.Models;
using com.course.blog.adminui.Helpers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace com.course.blog.adminui.Helpers
{
    public class AdminAuthorization: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.Get<User>("User")==null)
            {
                context.HttpContext.Session.Set<bool>("NotAuthorized",true);

                context.Result = new RedirectResult("/Login/Index");
            }
            base.OnActionExecuting(context);
        }
    }
}
