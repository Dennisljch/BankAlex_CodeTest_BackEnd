using BankAlex_CodeTest_BackEnd.DBContext;
using BankAlex_CodeTest_BackEnd.Interfaces.Repository;
using BankAlex_CodeTest_BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 
namespace BankAlex_CodeTest_BackEnd.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppDbContext _appDbContext;

        public TransactionRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IQueryable<Transaction> AllTransactions
        {
            get
            {
                IQueryable<Transaction> allTransactions = _appDbContext.Transactions;
                return allTransactions;
            }
        }

        public bool AddTransaction(Transaction transaction)
        {
            _appDbContext.Transactions.Add(transaction);
            _appDbContext.SaveChanges();

            return true;
        }

        public bool UpdateTransaction(Guid id, Transaction transaction)
        {
            var transactionEntry = _appDbContext.Entry(transaction);
            transactionEntry.State = EntityState.Modified;
            //_appDbContext.Entry(transaction).Property(x => x.Id).IsModified = false;

            _appDbContext.SaveChanges();

            return true;
        }
    }
}
