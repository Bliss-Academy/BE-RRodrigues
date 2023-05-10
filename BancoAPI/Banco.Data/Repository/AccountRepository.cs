using System.Collections.Generic;
using System.Linq;
using Banco.Data.Entities;

namespace Banco.Data.Repository
{
    public interface IAccountRepository
    {
        AccountEntity GetAccountByUserId(string userId);
    }

    public class AccountRepository : IAccountRepository
    {
        List<AccountEntity> listAccounts = new List<AccountEntity>
        {
            new AccountEntity{Id=1, userId="1", income=500, expense=100, username="Kirtesh" },
            new AccountEntity{Id=2, userId="2",  income=1500, expense=200, username="Nitya" },
            new AccountEntity{Id=3, userId="3",  income=2000, expense=200, username="Dilip" },
            new AccountEntity{Id=4, userId="4", income=3000, expense=300, username="Atul" },
            new AccountEntity{Id=5, userId="5",  income=4500, expense=400, username="Swati" },
            new AccountEntity{Id=6, userId="6",  income=5000, expense=2000, username="Rashmi" },
        };

        public AccountEntity GetAccountByUserId(string userId)
        {
            return listAccounts.FirstOrDefault(x => x.userId == userId);
        }

   
    }
}
