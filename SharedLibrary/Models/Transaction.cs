using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Models
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public string FromAccount { get; set; }
        public string ToAccount { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public Customer Owner { get; set; }
    }
}
