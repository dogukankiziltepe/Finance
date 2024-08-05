using Finance.Application.Abstract.Service;
using Finance.Application.Models.Agreement;
using Finance.Application.Models.Search;
using Finance.Domain.Entities.Agreements;
using Finance.Persistence.Abstract.Repositories;
using Finance.Persistence.Abstract.Service;
using Finance.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Finance.Persistence.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace Finance.Persistence.Concrete.Service
{
    public class AgreementService : IAgreementService
    {
        private readonly IAgreementRepository _repo;
        private readonly IUserService _userService;
        private readonly FinanceDbContext _financeDbContext;
        private readonly IHubContext<NotificationHub> _hubContext;

        public AgreementService(IAgreementRepository repo, IUserService userService, FinanceDbContext financeDbContext)
        {
            _repo = repo;
            _userService = userService;
            _financeDbContext = financeDbContext;
        }
        public async Task<bool> CreateAgreement(CreateAgreementModel agreementModel)
        {
            try
            {
                var agreement = new Agreement
                {
                    CompanyId = _userService.GetUserCompany(),
                    Content = agreementModel.Content,
                    Title = agreementModel.Title,
                    StartDate = agreementModel.StartDate,
                    EndDate = agreementModel.EndDate,
                };
                await _repo.AddAsync(agreement);
                _ = RiskAnalsys(agreement.Id,_userService.GetUserId());
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> DeleteAgreement(string id)
        {
            await _repo.DeleteAsync(id);
            return true;
        }

        public async Task<AgreementResponseModel> GetAgreement(string id, string companyId)
        {
            try
            {
                var result = (await _repo.FindWithInclude(x => x.Id == id && x.CompanyId == companyId, x => x.Company)).FirstOrDefault();
                return new AgreementResponseModel
                {
                    Company = result.Company.Name,
                    StartDate = result.StartDate,
                    EndDate = result.EndDate,
                    RiskValue = result.RiskValue ?? 0,
                    Title = result.Title,
                };
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<AgreementResponseModel>> GetAgreements(AgreementGetListModel model, string companyId)
        {
            try
            {
                var query = companyId != "0" ? _financeDbContext.Agreements.Where(x => x.CompanyId == companyId) : _financeDbContext.Agreements.AsQueryable();
                if(model.Filter != null)
                {
                    foreach (var filterProperty in typeof(AgreementFilter).GetProperties())
                    {
                        var filterValue = filterProperty.GetValue(model.Filter);
                        if (filterValue != null)
                        {
                            var column = typeof(Agreement).GetProperty(filterProperty.Name);
                            if (column == null)
                            {
                                throw new ArgumentException($"Property {filterProperty.Name} not found");
                            }

                            if (column.PropertyType == typeof(string))
                            {
                                query = query.Where(x => EF.Property<string>(x, column.Name).Contains(filterValue.ToString()));
                            }
                            else
                            {
                                query = query.Where(x => EF.Property<object>(x, column.Name).Equals(filterValue));
                            }
                        }
                    }
                }
                var agreements = query.Include(x => x.Company).ToList();
                return agreements.Select(x => new AgreementResponseModel
                {
                    Title = x.Title,
                    StartDate = x.StartDate,
                    Company = x.Company.Name,
                    EndDate = x.EndDate,
                    RiskValue = x.RiskValue ?? 0,

                }).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateAgreemnet(string id, UpdateAgreementModel agreementModel)
        {
            var agreement = _repo.GetById(id);
            agreement.Title = agreementModel?.Title ?? agreement.Title;
            agreement.StartDate = agreementModel?.StartDate ?? agreement.StartDate;
            agreement.Content = agreementModel?.Content ?? agreement.Content;
            agreement.EndDate = agreementModel?.EndDate ?? agreement.EndDate;
            await _repo.UpdateAsync(agreement);
            return true;
        }

        private async Task RiskAnalsys(string id,string userId)
        {
            var agreement = await _financeDbContext.Agreements.FindAsync(id);
            agreement.RiskValue = 23;
            _financeDbContext.Update(agreement);
            _financeDbContext.SaveChanges();
            var connection = _financeDbContext.UserConnections.FirstOrDefault(x => x.UserId == userId);
            if (connection != null)
            {
                await _hubContext.Clients.Client(connection.ConnectionId)
                                 .SendAsync("ReceiveNotification", "Son oluşturduğunuz anlaşmanın risk puanı hesaplanmıştır. Risk puanı: "+agreement.RiskValue );
            }


        }
    }
}
