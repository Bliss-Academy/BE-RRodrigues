using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Banco.Data.Model;


namespace Banco.Data.Interface
{
    public interface ITransaction
    {
        List<Transaction> GetAllTransactionById(string id);

        Transaction GetTransaction(string id);
    }
}
