using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace testAmazeUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //登入界面
            routes.MapRoute(
            name: "Login",
            url: "Login",
            defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }
           );
            //主页
            routes.MapRoute(
            name: "Index",
            url: "Index",
            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
           );
            //默认路由
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }
            );
           
           
        }
    }
}
