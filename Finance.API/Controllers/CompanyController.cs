using Finance.Application.Abstract.Service;
using Finance.Application.Models.Company;
using Finance.Application.Models.Search;
using Finance.Base.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Finance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Admin")]
    public class CompanyController(ICompanyService companyService) : BaseController
    {
        private readonly ICompanyService _companyService = companyService;
        [HttpGet]
        public async Task<IActionResult> GetCompanies([FromBody] CompanyGetListModel model)
        {
            var result = await _companyService.GetCompanies(model);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompany(string id)
        {
            var result = await _companyService.GetCompany(id);
            return Ok(result);
        }
    }
}
