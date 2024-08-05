using Finance.Application.Models.Agreement;
using Finance.Application.Models.Search;
using Finance.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace Finance.Web.Controllers
{
    public class AgreementController : Controller
    {
        public IActionResult Index(AgreementViewModel model)
        {
            var agreements = GetAgreementsFromApi(new AgreementGetListModel
            {
                Page = 1,
                PageSize = 10,
                Filter = model.Filter

            });

            var viewModel = new AgreementViewModel
            {
                Agreements = agreements,
                Filter = model.Filter,
            };

            return View(viewModel);
        }

        private List<AgreementResponseModel> GetAgreementsFromApi(AgreementGetListModel filter)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7191");
                var token = HttpContext.Session.GetString("JWTToken");

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = client.PostAsJsonAsync("api/agreement/getAgreements", filter).Result;

                if (response.IsSuccessStatusCode)
                {
                    var agreements = response.Content.ReadFromJsonAsync<List<AgreementResponseModel>>().Result;
                    return agreements;
                }
            }

            return new List<AgreementResponseModel>();
        }

        public IActionResult Detail(string id)
        {
            return View(id);
        }

        // GET: MyModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MyModels/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Content,StartDate,EndDate,Keywords")] CreateAgreementModel model)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7191");
                    var token = HttpContext.Session.GetString("JWTToken");

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    var response = client.PostAsJsonAsync("api/agreement", model).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index)); // Veya uygun bir sayfaya yönlendirme
                    }
                }
            }
            return View(model);
        }
    }
}
