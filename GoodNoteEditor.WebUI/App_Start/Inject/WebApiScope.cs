using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using Ninject.Activation;
using Ninject.Parameters;
using Ninject.Syntax;

namespace GoodNoteEditor.WebUI.Inject
{
    public class WebApiScope : IDependencyScope
    {
        private IResolutionRoot _resolutionRoot;
        public WebApiScope(IResolutionRoot kernel)
        {
            _resolutionRoot = kernel;
        }
        public object GetService(Type serviceType)
        {
            IRequest request = _resolutionRoot.CreateRequest(serviceType, null, new Parameter[0], true, true);
            return _resolutionRoot.Resolve(request).SingleOrDefault();
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            IRequest request = _resolutionRoot.CreateRequest(serviceType, null, new Parameter[0], true, true);
            return _resolutionRoot.Resolve(request).ToList();
        }
        public void Dispose()
        {
            IDisposable disposable = (IDisposable)_resolutionRoot;
            if (disposable != null) disposable.Dispose();
            _resolutionRoot = null;
        }
    }
}