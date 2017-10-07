using System.Web.Mvc;

namespace GoodNoteEditor.WebUI.Controllers
{
    /// <summary>
    /// Single-Page Applications controller 
    /// </summary>
    public class HomeController : Controller
    {
        
        /// <summary>
        /// Home
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}