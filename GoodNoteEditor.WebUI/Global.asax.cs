using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using GoodNoteEditor.WebUI.Infrastructure.Extensions;
using Utils.Log;

namespace GoodNoteEditor.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            GlobalConfiguration.Configure(WebApiRouteConfig.Register);
            MvcRouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            GlobalConfiguration.Configuration.EnsureInitialized();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            // Grab information about the last error occurred 
            Exception exception = Server.GetLastError();
            if (exception == null)
                exception = new ApplicationException("The last server error is null");

            // Log the error
            string message = exception.WideInfo(nameof(MvcApplication)).ToString();
            this.Log().Error(message);
          
            // Html error page. We don't redirect to custom view to avoid possible repeated errors.
            Response.Write("<h2>Page Error</h2>\n");
            Response.Write("<p>" + exception.Message + "</p>\n");
            Response.Write("Return to the <a href='Home'>" +"Default Page</a>\n");
            Response.ContentType = "text/html";

            // clear
            Server.ClearError();
        }
    }
}
