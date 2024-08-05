using Finance.Web.Filters;
using Finance.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Finance.Web.Controllers
{
    [ServiceFilter(typeof(AuthorizeFilter))]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var token = HttpContext.Session.GetString("JWTToken");
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var role = HttpContext.Session.GetString("Role");
                if (role == "Admin")
                {
                    return RedirectToAction("AdminDashboard");
                }
                return RedirectToAction("UserDashboard");
            }
        }

        public IActionResult AdminDashboard()
        {
            return View();
        }

        public IActionResult UserDashboard()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
