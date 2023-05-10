using AutoMapper;
using BancoAPI.Data.Entities;
using BancoAPI.Data.Models;
using BancoAPI.Data.Models.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BancoAPI.Data.Factories
{
    public interface IModelViewFactory
    {
        DashboardViewModel GetDashboardDTO(AccountEntity account, List<TransactionEntity> transactions, List<TransactionEntity> timeframedTransactions);
        DashboardViewModel MapperGetDashboardDTO(AccountEntity account);

        DashboardViewModel MapperGetDashboardModelView(AccountEntity accountEntity, List<TransactionEntity> timeframe, List<TransactionEntity> transactions, TimeFrame time);
    }

    public class ModelViewFactory : IModelViewFactory
    {
        private readonly IMapper _mapper;

        public ModelViewFactory(IMapper mapper)
        {
            _mapper = mapper;
        }

        public DashboardViewModel MapperGetDashboardDTO(AccountEntity account)
        {
            var model = _mapper.Map<DashboardViewModel>(account);
            return model;
        }

        public DashboardViewModel GetDashboardDTO(AccountEntity account, List<TransactionEntity> transactions, List<TransactionEntity> timeframedTransactions)
        {
            if (account != null)
            {
                var timeframedTransactionsDto = timeframedTransactions.OrderByDescending(t => t.created).Select(t => new TransactionDTO()
                {
                    id = t.id,
                    userId = t.userId,
                    title = t.title,
                    attachment = t.attachment,
                    Created = t.created,
                    description = t.description,
                    type = t.type,
                    value = t.value
                }).ToList();

                var lastTransactions = _mapper.Map<List<TransactionDTO>>(transactions.OrderByDescending(t => t.created).Take(3).ToList());

                return new DashboardViewModel()
                {
                    income = account.income,
                    expense = account.expense,
                    balance = account.income - account.expense,
                    userId = account.userId,
                    username = account.username,
                    timeframedTransactions = timeframedTransactionsDto,
                    lastTransactions = lastTransactions
                };
            }
            else
                throw new Exception("User not found!");

        }

        public DashboardViewModel MapperGetDashboardModelView(AccountEntity accountEntity, List<TransactionEntity> timeframe, List<TransactionEntity> transactions, TimeFrame time)
        {
            if (accountEntity != null){
                var minDate = DateTime.Now.AddDays(-(int)time);
                var timeframedTransactionsDto = _mapper.Map<List<TransactionDTO>>(transactions.Where(i => i.created > minDate).OrderBy(t => t.created).ToList());
                var lastTransactions = _mapper.Map<List<TransactionDTO>>(transactions.OrderByDescending(t => t.created).Take(3).ToList());
                var model = _mapper.Map<DashboardViewModel>(accountEntity);

                model.timeframedTransactions = timeframedTransactionsDto;
                model.lastTransactions = lastTransactions;

                return model;
            }
            else
                throw new Exception("Error: User Not Found!");
        }

    }
}
