//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection.Emit;
//using BancoAPI.Data.Entities;
//using BancoAPI.Data.Factories;

//namespace BancoAPI.Data.Repository
//{
 
//    public interface ITransactionsRepository
//    {
//        List<TransactionEntity> GetTransactionsByUserId(string userId);
//        List<TransactionEntity> GetTransactiosnByUserIdAndTimeFrame(string userId, TimeFrame timeframe);
        
//    }

//    public class TransactionsRepository : ITransactionsRepository
//    {
//        List<TransactionEntity> listTransactions = new List<TransactionEntity>
//        {
//            new TransactionEntity{ type=TrasactionType.Income, value=500, title="Ordenado", description="Ordenado" ,userId="1", attachment=""},
//            new TransactionEntity{ type=TrasactionType.Expense, value=100, title="Jantar", description="Jantar na praia",userId="1" , attachment="" },
//            new TransactionEntity{ type=TrasactionType.Income, value=150, title="Ordenado", description="Ordenado",userId="1" , attachment="" },
//            new TransactionEntity{ type=TrasactionType.Income, value=200, title="Ordenado", description="Ordenado" ,userId="1", attachment=""},
//            new TransactionEntity{ type=TrasactionType.Expense, value=500, title="Jantar", description="Jantar na praia" ,userId="1" , attachment=""},
//            new TransactionEntity{ type=TrasactionType.Expense, value=150, title="Almoço", description="Almoço na praia",userId="1", attachment="" },
//            new TransactionEntity{type=TrasactionType.Expense, value=200,  title="Café", description="Café na praia" ,userId="1", attachment=""},
//            new TransactionEntity{type=TrasactionType.Expense, value=200,  title="Café", description="Café na praia" ,userId="2", attachment=""},
//            new TransactionEntity{type=TrasactionType.Expense, value=200, date=new DateTime(2021, 3, 20), title="Café", description="Café na praia" ,userId="3", attachment=""},
//            new TransactionEntity{type=TrasactionType.Expense, value=200, date=new DateTime(2021, 3, 20), title="Café", description="Café na praia" ,userId="3", attachment=""},
//            new TransactionEntity{type=TrasactionType.Expense, value=200, date=new DateTime(2021, 3, 20), title="Café", description="Café na praia" ,userId="4", attachment=""},

//        };

//        public List<TransactionEntity> GetTransactionsByUserId(string userId)
//        {
//            return listTransactions.Where(i => i.userId == userId).ToList();
//        }

//        public List<TransactionEntity> GetTransactiosnByUserIdAndTimeFrame(string userId, TimeFrame timeframe)
//        {
//            var minDate = DateTime.Now.AddDays(-(int)timeframe);
//            return listTransactions.Where(i => i.date > minDate).ToList();
//        }

 
//    }
//}

