using System;
using System.Collections.Generic;
using System.Text;

namespace RCM.Model
{
    public class CustomerTransactionData
    {
        public long CustomerId { get; set; }
        public decimal AmountSpent { get; set; }
        public int RewardsPointsEarned { get; set; }
        public DateTime TransactionDateTime { get; set; }

    }
}
