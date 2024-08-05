using Finance.Application.Models.Agreement;
using Finance.Application.Models.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Application.Abstract.Service
{
    /// <summary>
    /// Anlaşmalar için gerekli servis
    /// </summary>
    public interface IAgreementService
    {
        /// <summary>
        /// Anlaşma oluştur
        /// </summary>
        /// <param name="agreementModel">Anlaşma oluşturma Modeli</param>
        /// <returns>bool</returns>
        public Task<bool> CreateAgreement(CreateAgreementModel agreementModel);
        /// <summary>
        /// Anlaşmayı Güncelle
        /// </summary>
        /// <param name="id">Anlaşma Id'si</param>
        /// <param name="agreementModel">Anlaşma Güncelleme Modeli</param>
        /// <returns></returns>
        public Task<bool> UpdateAgreemnet(string id, UpdateAgreementModel agreementModel);
        /// <summary>
        /// Anlaşma Silme
        /// </summary>
        /// <param name="id">Anlaşma Id'si</param>
        /// <returns></returns>
        public Task<bool> DeleteAgreement(string id);
        /// <summary>
        /// Id ye göre Anlaşma Getirme
        /// </summary>
        /// <param name="id">Anlaşma Id</param>
        /// <param name="companyId">Kullanıcının Şirket Id'si</param>
        /// <returns></returns>
        public Task<AgreementResponseModel> GetAgreement(string id, string companyId);
        /// <summary>
        /// Anlaşma listesini filtrelemek ve getirmek için kullanılan method
        /// </summary>
        /// <param name="model">Liste için gerekli model</param>
        /// <param name="companyId">Kullanıcının Şirket Id'si</param>
        /// <returns></returns>
        public Task<List<AgreementResponseModel>> GetAgreements(AgreementGetListModel model,string companyId);
    }
}
