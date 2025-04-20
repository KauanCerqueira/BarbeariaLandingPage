// HomeController.cs
using Microsoft.AspNetCore.Mvc;

namespace BarbeariaLandingPage.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(); // Isso renderiza a View Index.cshtml na pasta Views/Home
        }
    }
}
