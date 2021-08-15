using BankAlex_CodeTest_BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAlex_CodeTest_BackEnd.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetTransaction()
        {
            var response = new
            {
                href = nameof(GetTransaction)
            };

            return Ok(response);
        }


        [HttpPost]
        public IActionResult PostTransaction(Transaction transaction)
        {
            var response = new
            {
                href = nameof(PostTransaction) + $" Amount: {transaction.Amount} Owner Name: {transaction.Owner.Name}"
            };

            return Ok(response);
        }


        [HttpPut("{id:guid}")]
        public IActionResult PutTransaction(Guid id, Transaction transaction)
        {
            var response = new
            {
                href = nameof(PutTransaction) + $" {id}" + $" Amount: {transaction.Amount} Owner Name: {transaction.Owner.Name}"
            };

            return Ok(response);
        }
    }
}
