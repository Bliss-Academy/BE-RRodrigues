using Banco.Data.Model;
using Banco.Data.Interface;
using Banco.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Globalization;

namespace BancoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashAPI : ControllerBase
    {
        private IDashboard dash = new DashboardRepository();
        private ITransaction transactionShow = new TransactionsRepository();

        [HttpGet]
        public ActionResult<Dashboard> GetMemberById(string id)
        {
            return dash.GetDash(id);
        }

        [HttpGet("{id}")]
        public ActionResult<Transaction> GetAllTransaction(string id)
        {
            return transactionShow.GetTransaction(id);
        }

        [HttpGet]
        [Route("api/GetAllTransactions")]
        public ActionResult<IEnumerable<Transaction>> GetAllMembers(string id)
        {
            return transactionShow.GetAllTransactionById(id);
        }

    }
}
