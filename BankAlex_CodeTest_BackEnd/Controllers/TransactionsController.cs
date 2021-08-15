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
        public IActionResult PostTransaction()
        {
            var response = new
            {
                href = nameof(PostTransaction)
            };

            return Ok(response);
        }


        [HttpPut("{id:int}")]
        public IActionResult PutTransaction(int id)
        {
            var response = new
            {
                href = nameof(PutTransaction) + $" {id}"
            };

            return Ok(response);
        }
    }
}
