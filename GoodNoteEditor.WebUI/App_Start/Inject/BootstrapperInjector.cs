[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(GoodNoteEditor.WebUI.App_Start.BootstrapperInjector), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(GoodNoteEditor.WebUI.App_Start.BootstrapperInjector), "Stop")]

namespace GoodNoteEditor.WebUI.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using WebUI;
    using Inject;

    /// <summary>
    /// This class an injects general start method to include DI container in our application.
    /// It works for any asp.net mvc (with web api) application.
    /// But this class has a tight bondage with ApplicationController. 
    /// </summary>
    public static class BootstrapperInjector 
    {
        /// <summary>
        /// bootstrapper
        /// </summary>
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                // common services
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                // common resolvers
                CreateAndSetResolvers(kernel);

                // your application services
                new ApplicationManager().RegisterServices(kernel);

                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Creates web api and mvc resolvers.
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void CreateAndSetResolvers(IKernel kernel)
        {
            // Web Api
            System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver = new WebApiResolver(kernel);

            // MVC 
            System.Web.Mvc.DependencyResolver.SetResolver(new MvcResolver(kernel));
        }
    }
}
