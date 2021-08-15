using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAlex_CodeTest_BackEnd.Controllers
{
    [Route("api/transactions")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        [HttpGet(Name = nameof(GetTransaction))]
        public IActionResult GetTransaction()
        {
            var response = new
            {
                href = Url.Link(nameof(GetTransaction), null)
            };

            return Ok(response);
        }
    }
}
