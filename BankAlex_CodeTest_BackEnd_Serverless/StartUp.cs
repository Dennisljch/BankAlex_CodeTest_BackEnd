using BankAlex_CodeTest_BackEnd_Serverless.DBContext;
using BankAlex_CodeTest_BackEnd_Serverless.Interfaces.Repository;
using BankAlex_CodeTest_BackEnd_Serverless.Repository;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;


[assembly: FunctionsStartup(typeof(BankAlex_CodeTest_BackEnd_Serverless.StartUp))]

namespace BankAlex_CodeTest_BackEnd_Serverless
{
    public class StartUp : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            string connectionString = Environment.GetEnvironmentVariable("DefaultConnection");
            builder.Services.AddDbContext<AppDbContext>(
              options => SqlServerDbContextOptionsExtensions.UseSqlServer(options, connectionString));

            builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
        }
    }
}
