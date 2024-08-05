using Finance.Application.Models.Auth;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Web.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Login(LoginRequest request)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7191/");

                var response = await client.PostAsJsonAsync("api/auth/login", request);
                var s = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<LoginResponse>();
                    // Token'ı sakla (örneğin, session'da)
                    HttpContext.Session.SetString("JWTToken", result.Token);
                    HttpContext.Session.SetString("Role", result.Role);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Kullanıcı adı veya şifre yanlış.");
                }
            }
            return View("Index");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("JWTToken");
            HttpContext.Session.Remove("Role");
            HttpContext.Session.Remove("Username");
            return RedirectToAction("Index", "Login");
        }
    }
}
