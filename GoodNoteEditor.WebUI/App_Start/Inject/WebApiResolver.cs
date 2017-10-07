using System.Web.Http.Dependencies;
using Ninject;

namespace GoodNoteEditor.WebUI.Inject
{
    /// <summary>
    /// This class implements <see cref="IDependencyResolver" /> to inject web Api.
    /// </summary>
    public class WebApiResolver : WebApiScope, IDependencyResolver
    {
        private readonly IKernel _kernel;
        public WebApiResolver(IKernel kernel)
            : base(kernel)
        {
            _kernel = kernel;
        }

        public IDependencyScope BeginScope()
        {
            return new WebApiScope(_kernel.BeginBlock());
        }
    }
}