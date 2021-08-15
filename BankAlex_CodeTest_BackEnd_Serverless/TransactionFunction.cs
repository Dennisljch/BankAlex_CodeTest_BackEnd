using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using BankAlex_CodeTest_BackEnd_Serverless.DBContext;
using BankAlex_CodeTest_BackEnd_Serverless.Interfaces.Repository;
using System.Linq;
using BankAlex_CodeTest_BackEnd_Serverless.Models.Models;

namespace BankAlex_CodeTest_BackEnd_Serverless
{
    public class TransactionFunction
    {
        private readonly ITransactionRepository _transactionRepository;
        public TransactionFunction(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        [FunctionName("Transactions")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", "put", Route = "Transactions/{id?}")] HttpRequest req,
            ILogger log, string id)
        {
            try
            {
                if (id == null)
                {
                    if (req.Method == HttpMethods.Get)
                    {
                        var transactions = _transactionRepository.AllTransactions.ToList();

                        return new OkObjectResult(transactions);
                    }
                    else
                    {
                        var content = new StreamReader(req.Body).ReadToEndAsync().Result;
                        Transaction transaction = JsonConvert.DeserializeObject<Transaction>(content);

                        _transactionRepository.AddTransaction(transaction);

                        return new OkObjectResult("transaction created");
                    }
                }
                else 
                {
                    Guid transactionID = Guid.Parse(id);
                    var content = new StreamReader(req.Body).ReadToEndAsync().Result;
                    Transaction transaction = JsonConvert.DeserializeObject<Transaction>(content);

                    _transactionRepository.UpdateTransaction(transactionID, transaction);

                    return new OkObjectResult("transaction updated");
                }
            }
            catch
            {
                return new BadRequestObjectResult("validation errors");
            }
        }
    }
}
