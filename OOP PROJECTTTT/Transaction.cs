using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloralFusion
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public double Amount { get; set; }

        public Transaction(int transactionId, double amount)
        {
            TransactionID = transactionId;
            Amount = amount;
        }
    }
}
