using Banco.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banco.Data.Interface;
using System.Globalization;
using System.ComponentModel;

namespace Banco.Data.Repository
{
    public class TransactionsRepository : ITransaction
    {
        List<Transaction> lisTransanctions = new List<Transaction>
        {
            new Transaction{type="transaction", value=500, date=new DateTime(2015, 12, 31), title="Ordenado", description="Ordenado" , nomeConta="Kirtesh" },
            new Transaction{type="expense", value=100, date=new DateTime(2015, 12, 31), title="Jantar", description="Jantar na praia" , nomeConta="Kirtesh" },
            new Transaction{type="transaction", value=150, date=new DateTime(2015, 12, 31), title="Ordenado", description="Ordenado" , nomeConta="Nitya" },
            new Transaction{type="transaction", value=200, date=new DateTime(2015, 12, 31), title="Ordenado", description="Ordenado" , nomeConta="Dilip" },
            new Transaction{type="expense", value=500, date=new DateTime(2015, 12, 31), title="Jantar", description="Jantar na praia" , nomeConta="Atul" },
            new Transaction{type="expense", value=150, date=new DateTime(2015, 12, 31), title="Almoço", description="Almoço na praia" , nomeConta="Swati" },
            new Transaction{type="expense", value=200, date=new DateTime(2015, 12, 31), title="Café", description="Café na praia" , nomeConta="Rashmi" },
        };

        public List<Transaction> GetAllTransactionById(string userId)
        {
            List<Transaction> transactionSearch = new List<Transaction>();
            foreach (var transact in lisTransanctions)
            {
                if (transact.nomeConta == userId)
                {
                    transactionSearch.Add(transact);
                }
            }
            return transactionSearch;
        }


        public Transaction GetTransaction(string id)
        {
            return lisTransanctions.FirstOrDefault(x => x.nomeConta == id);
        }
    }
}
