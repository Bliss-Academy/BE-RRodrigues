using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using Banco.Data.Entities;

namespace Banco.Data.Repository
{
    public enum TimeFrame
    {
        daily = 1,
        weekly = 7,
        monthly = 30,
        annually = 365
    }
    public interface ITransactionsRepository
    {
        List<TransactionEntity> GetTransactionsByUserId(string userId);
        List<TransactionEntity> GetTransactiosnByUserIdAndTimeFrame(string userId, TimeFrame timeframe);
        
    }

    public class TransactionsRepository : ITransactionsRepository
    {
        List<TransactionEntity> listTransactions = new List<TransactionEntity>
        {
            new TransactionEntity{id=0, type=TrasactionType.Income, value=500, date=new DateTime(2023, 4, 5), title="Ordenado", description="Ordenado" ,userId="1", attachment=""},
            new TransactionEntity{id=1, type=TrasactionType.Expense, value=100, date=new DateTime(2023, 4, 6), title="Jantar", description="Jantar na praia",userId="1" , attachment="" },
            new TransactionEntity{id=2, type=TrasactionType.Income, value=150, date=new DateTime(2022, 7, 3), title="Ordenado", description="Ordenado",userId="1" , attachment="" },
            new TransactionEntity{id=3, type=TrasactionType.Income, value=200, date=new DateTime(2023, 4, 2), title="Ordenado", description="Ordenado" ,userId="1", attachment=""},
            new TransactionEntity{id=4, type=TrasactionType.Expense, value=500, date=new DateTime(2023, 4, 1), title="Jantar", description="Jantar na praia" ,userId="1" , attachment=""},
            new TransactionEntity{id=5, type=TrasactionType.Expense, value=150, date=new DateTime(2023, 2, 14), title="Almoço", description="Almoço na praia",userId="1", attachment="" },
            new TransactionEntity{id=6,type=TrasactionType.Expense, value=200, date=new DateTime(2021, 3, 20), title="Café", description="Café na praia" ,userId="1", attachment=""},
            new TransactionEntity{id=7,type=TrasactionType.Expense, value=200, date=new DateTime(2021, 3, 20), title="Café", description="Café na praia" ,userId="2", attachment=""},
            new TransactionEntity{id=8,type=TrasactionType.Expense, value=200, date=new DateTime(2021, 3, 20), title="Café", description="Café na praia" ,userId="3", attachment=""},
            new TransactionEntity{id=9,type=TrasactionType.Expense, value=200, date=new DateTime(2021, 3, 20), title="Café", description="Café na praia" ,userId="3", attachment=""},
            new TransactionEntity{id=10,type=TrasactionType.Expense, value=200, date=new DateTime(2021, 3, 20), title="Café", description="Café na praia" ,userId="4", attachment=""},

        };

        public List<TransactionEntity> GetTransactionsByUserId(string userId)
        {
            return listTransactions.Where(i => i.userId == userId).ToList();
        }

        public List<TransactionEntity> GetTransactiosnByUserIdAndTimeFrame(string userId, TimeFrame timeframe)
        {
            var minDate = DateTime.Now.AddDays(-(int)timeframe);
            return listTransactions.Where(i => i.date > minDate).ToList();
        }

        public TransactionEntity AddTransactionById(string userId, TrasactionType type, decimal value, DateTime date, string title, string description, string attachment)
        {
            new TransactionEntity { id =11, type = type , value = value, date = date, title = title, description = description, userId = userId, attachment = attachment };
            return null;
        }

 
    }
}

