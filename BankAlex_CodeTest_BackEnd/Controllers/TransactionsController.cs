using BankAlex_CodeTest_BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankAlex_CodeTest_BackEnd.Interfaces.Repository;
using BankAlex_CodeTest_BackEnd.Repository;

namespace BankAlex_CodeTest_BackEnd.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionRepository _transactionRepository;
        public TransactionsController(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        [HttpGet]
        public IActionResult GetTransaction()
        {
            var transactions = _transactionRepository.AllTransactions;

            return Ok(transactions);
        }


        [HttpPost]
        public IActionResult PostTransaction(Transaction transaction)
        {
            _transactionRepository.AddTransaction(transaction);

            return Ok();
        }


        [HttpPut("{id:guid}")]
        public IActionResult PutTransaction(Guid id, Transaction transaction)
        {
            _transactionRepository.UpdateTransaction(id, transaction);

            return Ok();
        }
    }
}
