using BancoAPI.Data.Entities;
using BancoAPI.Data.Factories;
using BancoAPI.Data.Models;
using BancoAPI.Data.Models.ModelViews;
using BancoAPI.Data.Repository;


namespace BancoAPI.Business.Services
{
    public interface IDashboardService
    {
        DashboardDTO GetDashByUserId(string userId, TimeFrame timeFrame);
        DashboardViewModel MVGetDashByUserId(string userId, TimeFrame timeFrame);
    }
    public class DashboardService : IDashboardService
    {
        private readonly IGenericRepository<AccountEntity> _accountRepository;
        private readonly IGenericRepository<TransactionEntity> _transactionsRepository;
        private readonly IDTOFactory _dtoFactory;
        private readonly IModelViewFactory _modelViewFactory;

        public DashboardService(IGenericRepository<AccountEntity> accountRepository, IGenericRepository<TransactionEntity> transactionsRepository, IDTOFactory dtoFactory, IModelViewFactory modelViewFactory)
        {
            _accountRepository = accountRepository;
            _transactionsRepository = transactionsRepository;
            _dtoFactory = dtoFactory;
            _modelViewFactory= modelViewFactory;
        }

        public DashboardDTO GetDashByUserId(string userId, TimeFrame timeFrame)
        {
            try
            {
                var account = _accountRepository.FindByUserId(userId).FirstOrDefault();

                var transactions = _transactionsRepository.FindByUserId(userId);

                var timeframedTransactions = _transactionsRepository.FindByUserIdAndTimeframe(userId, timeFrame);
                //Convert entity to DTO
                return _dtoFactory.GetDashboardDTO(account, transactions, timeframedTransactions);
            }catch (Exception ex)
            {
                return new DashboardDTO();
            }
        }

        public DashboardViewModel MVGetDashByUserId(string userId, TimeFrame timeFrame)
        {
            try
            {
                var account = _accountRepository.FindByUserId(userId).FirstOrDefault();

                var transactions = _transactionsRepository.FindByUserId(userId);

                var timeframedTransactions = _transactionsRepository.FindByUserIdAndTimeframe(userId, timeFrame);

                return _modelViewFactory.MapperGetDashboardDTO(account);
            }
            catch (Exception ex)
            {
                return new DashboardViewModel();
            }
        }

    }
}
