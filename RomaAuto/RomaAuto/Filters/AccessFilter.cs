using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using RomaAuto.Models;
using System.Net;

namespace RomaAuto.Filters
{
    public class LoginFilter : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            RomaAutoDBEntities _db = new RomaAutoDBEntities();
            MainUser user = (MainUser)filterContext.HttpContext.Session["user"];
            if (user == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                       new RouteValueDictionary{{ "controller", "Account" }, { "action", "Login" } });
            }
            else
            {
                var userFromDb = _db.Admins.FirstOrDefault(item => item.Id == user.Id && item.Name == user.Name && item.AdminCategoryId == user.Category);
                if (userFromDb == null)
                {
                    filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.Forbidden);
                }
            }
            
            base.OnActionExecuting(filterContext);
        }
    }

    public class AccessFilter : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            RomaAutoDBEntities _db = new RomaAutoDBEntities();
            MainUser user = (MainUser)filterContext.HttpContext.Session["user"];

            if (_db.Admins.FirstOrDefault(item => item.AdminCategoryId == user.Category) == null || user.Category != 1)
            {
                filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            base.OnActionExecuting(filterContext);
        }
    }
}