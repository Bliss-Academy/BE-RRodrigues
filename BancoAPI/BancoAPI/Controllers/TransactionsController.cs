using BancoAPI.Business.Services;
using BancoAPI.Data.Entities;
using BancoAPI.Data.Factories;
using BancoAPI.Data.Models;
using BancoAPI.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using System.Globalization;
using System.Security.Principal;

namespace BancoAPI.Controllers
{
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService)
        {

            _transactionService = transactionService;
        }

        [HttpGet]
        [Route("gettransactionsbyid/{userId}")]
        public ActionResult<List<TransactionDTO>> GetTransactionsByUserId(string userId)=> _transactionService.GetTransactionsByUserId(userId);

        [HttpPost]
        [Route("addtransaction")]
        public ActionResult<bool> AddTransaction([FromBody] TransactionDTO transationDTO) => _transactionService.AddTransaction(transationDTO);

        [HttpPut]
        [Route("edittransaction")]
        public ActionResult<bool> EditTransaction([FromBody] TransactionDTO transactionDTO)=> _transactionService.EditTransaction(transactionDTO);

        [HttpDelete]
        [Route("deleteTransaction")]
        public ActionResult<bool> deleteTransaction(int Id, TrasactionType type)=> _transactionService.deleteTransaction(Id, type);
    }
}
