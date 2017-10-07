using System;
using System.Collections.Generic;
using Ninject;

namespace GoodNoteEditor.WebUI.Inject
{
    /// <summary>
    /// This class implements <see cref="IDependencyResolver" /> to inject web Mvc.
    /// </summary>
    public class MvcResolver : System.Web.Mvc.IDependencyResolver
    {
        private readonly IKernel _nKernel;

        public MvcResolver(IKernel nKernel)
        {
            _nKernel = nKernel;
        }

        public object GetService(Type serviceType)
        {
            return _nKernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _nKernel.GetAll(serviceType);
        }
    }
}