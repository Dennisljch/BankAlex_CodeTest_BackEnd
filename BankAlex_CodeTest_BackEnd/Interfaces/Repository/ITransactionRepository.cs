using BankAlex_CodeTest_BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAlex_CodeTest_BackEnd.Interfaces.Repository
{
    public interface ITransactionRepository
    {
        IQueryable<Transaction> AllTransactions { get; }
        bool AddTransaction(Transaction transaction);
        bool UpdateTransaction(Guid id, Transaction transaction);
    }
}
