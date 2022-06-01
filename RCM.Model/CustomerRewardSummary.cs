using System;
using System.Collections.Generic;
using System.Text;

namespace RCM.Model
{
    public class CustomerRewardSummary
    {
        public long RewardSummaryId { get; set; }
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int CurrentMonthRewardPoints { get; set; }
        public int PreviousMonthRewardPoints { get; set; }
        public int PriorToPreviousMonthRewardPoints { get; set; }
        public int TotalRewardPointsInLast3Months { get; set; }
        public DateTime UpdatedDateTime { get; set; }

    }
}
