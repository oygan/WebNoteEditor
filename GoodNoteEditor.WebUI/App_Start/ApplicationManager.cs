using GoodNoteEditor.Domain.Abstract;
using GoodNoteEditor.Domain.Concrete.Repository;
using Ninject;

namespace GoodNoteEditor.WebUI
{
    public class ApplicationManager
    {
        /// <summary>
        /// Register your services here!
        /// </summary>
        /// <param name="kernel"></param>
        public void RegisterServices(IKernel kernel)
        {
            kernel.Bind<INoteRepository>().To<EFNoteRepository>();
        }
    }
}