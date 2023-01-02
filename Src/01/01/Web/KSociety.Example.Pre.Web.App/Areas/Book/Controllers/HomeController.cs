using Microsoft.AspNetCore.Mvc;

namespace KSociety.Example.Pre.Web.App.Areas.Book.Controllers
{
    [Area("Book")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
