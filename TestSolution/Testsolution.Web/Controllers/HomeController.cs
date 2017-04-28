namespace Testsolution.Web.Controllers
{
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        [HttpGet]
        public ViewResult Index()
        {
            return View("~/Views/Home.cshtml");
        }
    }
}
