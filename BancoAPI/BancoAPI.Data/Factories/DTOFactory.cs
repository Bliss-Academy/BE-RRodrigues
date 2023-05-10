using BancoAPI.Data.Entities;
using BancoAPI.Data.Models;
using BancoAPI.Data.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Net.Mail;
using System.Runtime.InteropServices.ComTypes;

namespace BancoAPI.Data.Factories
{
    public enum TimeFrame
    {
        daily = 1,
        weekly = 7,
        monthly = 30,
        annually = 365
    }

    public interface IDTOFactory
    {
        DashboardDTO GetDashboardDTO(AccountEntity account, List<TransactionEntity> transactions, List<TransactionEntity> timeframedTransactions);
        List<TransactionDTO> GetTransactionsDTO(List<TransactionEntity> transactions);
        TransactionEntity AddTransaction(TransactionDTO transactionDTO);
        TransactionEntity UpdateTransactionEntity(TransactionDTO transactionDTO, TransactionEntity transactionEntity);
        //AccountEntity CreateAccountEntity(TransactionDTO transactionDTO);
    }

    public class DTOFactory : IDTOFactory
    {
        public DashboardDTO GetDashboardDTO(AccountEntity account, List<TransactionEntity> transactions, List<TransactionEntity> timeframedTransactions)
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

                var lastTransactions = transactions.OrderByDescending(t => t.created).Take(3).Select(t => new TransactionDTO()
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
            else
                throw new Exception("User not found!");
            
        }

        public List<TransactionDTO> GetTransactionsDTO(List<TransactionEntity> transactions)
        {
            return transactions.Select(t => new TransactionDTO()
            {
                id = t.id,
                attachment = t.attachment,
                Created = t.created,
                description = t.description,
                userId = t.userId,
                title = t.title,
                type = t.type,
                value = t.value
            }).ToList();
        }

        public  TransactionEntity AddTransaction(TransactionDTO transactionDTO)
        {
            return new TransactionEntity
            {
                userId = transactionDTO.userId,
                title = transactionDTO.title,
                attachment = transactionDTO.attachment,
                description = transactionDTO.description,
                type = transactionDTO.type,
                value = transactionDTO.value
            };
        }

        public TransactionEntity UpdateTransactionEntity(TransactionDTO transactionDTO,TransactionEntity transactionEntity)
        {
           
            transactionEntity.id = transactionDTO.id;
            transactionEntity.userId = transactionDTO.userId;
            transactionEntity.title = transactionDTO.title;
            transactionEntity.attachment = transactionDTO.attachment;
            transactionEntity.description = transactionDTO.description;
            transactionEntity.type = transactionDTO.type;
            transactionEntity.value = transactionDTO.value;
            transactionEntity.created = transactionDTO.Created;
            transactionEntity.updated = transactionDTO.Updated;

            return transactionEntity;
        }

        //public AccountEntity CreateAccountEntity(TransactionDTO transactionDTO)
        //{
        //    if(transactionDTO.type== TrasactionType.Income)
        //    {
        //        return new AccountEntity()
        //        {
        //            userId = transactionDTO.userId,
        //            income = transactionDTO.value,
        //            expense = 0,
        //            username = "vazio"
        //        };
        //    }
        //    else
        //    {
        //        return new AccountEntity()
        //        {
        //            userId = transactionDTO.userId,
        //            income = 0,
        //            expense = transactionDTO.value,
        //            username = "vazio",
        //        };
        //    }
            
        //}

    }
}