using Finance.Application.Models.Agreement;

namespace Finance.Web.Models
{
    public class AgreementViewModel
    {
        public List<AgreementResponseModel> Agreements { get; set; }
        public AgreementFilter Filter { get; set; }
    }


}
