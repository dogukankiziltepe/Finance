using Finance.Application.Abstract.Service;
using Finance.Application.Models.Agreement;
using Finance.Application.Models.Search;
using Finance.Base.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Finance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AgreementController(IAgreementService agreementService) : BaseController
    {
        private readonly IAgreementService _agreementService = agreementService;

        [HttpPost]
        public async Task<IActionResult> CreateAgreement([FromBody] CreateAgreementModel model)
        {
            var result = await _agreementService.CreateAgreement(model);
            if (result)
                return Ok(result);
            else return BadRequest();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAgreement([FromBody] UpdateAgreementModel model,string id)
        {
            var result = await _agreementService.UpdateAgreemnet(id,model);
            return Ok(result);
        }
        [HttpPost("GetAgreements")]
        public async Task<IActionResult> GetAgreements([FromBody] AgreementGetListModel model)
        {
            var result = await _agreementService.GetAgreements(model,CompanyId);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAgreementDetail(string id)
        {
            var result = await _agreementService.GetAgreement(id,CompanyId);
            return Ok(result);
        }   
    }
}
