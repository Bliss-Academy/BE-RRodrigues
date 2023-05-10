using Banco.Data.Entities;
using Banco.Data.Models;
using Banco.Data.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Net.Mail;
using System.Runtime.InteropServices.ComTypes;

namespace Banco.Data.Factories
{
    public interface IDTOFactory
    {
        DashboardDTO GetDashboardDTO(AccountEntity account, List<TransactionEntity> transactions, List<TransactionEntity> timeframedTransactions);
        List<TransactionDTO> GetTransactionsDTO(List<TransactionEntity> transactions);
        
    }

    public class DTOFactory : IDTOFactory
    {
        public DashboardDTO GetDashboardDTO(AccountEntity account, List<TransactionEntity> transactions, List<TransactionEntity> timeframedTransactions)
        {

            var timeframedTransactionsDto = timeframedTransactions.OrderByDescending(t => t.date).Select(t => new TransactionDTO()
            {
                userId = t.userId,
                title = t.title,
                attachment = t.attachment,
                date = t.date,
                description = t.description,
                type = t.type,
                value = t.value
            }).ToList();

            var lastTransactions = transactions.OrderByDescending(t => t.date).Take(3).Select(t => new TransactionDTO()
            {
                userId = t.userId,
                title = t.title,
                attachment = t.attachment,
                date = t.date,
                description = t.description,
                type = t.type,
                value = t.value
            }).ToList();

            return new DashboardDTO()
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

        public List<TransactionDTO> GetTransactionsDTO(List<TransactionEntity> transactions)
        {
            return transactions.Select(t => new TransactionDTO()
            {
                attachment = t.attachment,
                date = t.date,
                description = t.description,
                userId = t.userId,
                title = t.title,
                type = t.type,
                value = t.value
            }).ToList();
        }

        public void AddTransactionById(TransactionDTO transactionDTO, TransactionEntity AddTransactionById)
        {
            
        }

    }
}