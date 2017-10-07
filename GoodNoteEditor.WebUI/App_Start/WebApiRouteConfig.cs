using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace GoodNoteEditor.WebUI
{
    public static class WebApiRouteConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            // Convention-based routing.
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
