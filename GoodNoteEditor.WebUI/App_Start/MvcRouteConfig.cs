using System.Web.Mvc;
using System.Web.Routing;

namespace GoodNoteEditor.WebUI
{
    public class MvcRouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null,
                "",
                new
                {
                    controller = "Home",
                    action = "Index"
                });
            routes.MapRoute(null, "{controller}/{action}");

            // Add this code to handle non-existing urls
            routes.MapRoute(
                "404-PageNotFound",
                // This will handle any non-existing urls
                "{*url}",
                // "Shared" is the name of your error controller, and "Error" is the action/page
                // that handles all your custom errors
                // note: Application_Error is fired if shared/error is not exist
                new { controller = "Shared", action = "Error" }
            );

        }
    }
}
