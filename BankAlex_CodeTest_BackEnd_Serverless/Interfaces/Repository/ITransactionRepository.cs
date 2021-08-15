using BankAlex_CodeTest_BackEnd_Serverless.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankAlex_CodeTest_BackEnd_Serverless.Interfaces.Repository
{
    public interface ITransactionRepository
    {
        IQueryable<Transaction> AllTransactions { get; }
        bool AddTransaction(Transaction transaction);
        bool UpdateTransaction(Guid id, Transaction transaction);
    }
}
