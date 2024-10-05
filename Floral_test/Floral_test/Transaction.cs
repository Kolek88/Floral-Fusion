using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floral_test
{
    public class Transaction
    {
        public decimal Amount { get; set; }
        public string TransactionID { get; set; }

        

        public void ProcessTransaction()
        {
            //transaction process semua nnti kt sini
            Console.WriteLine($"Processing transaction {TransactionID} for amount {Amount:C}");
            //kontol
        }
    }
}
