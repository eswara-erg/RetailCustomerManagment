using RCM.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RCM.Repositories
{
    public interface ICustomerRepository
    {
        Task<int> CalculateRewardPointsAsync(decimal amountSpent);

        Task<IEnumerable<CustomerRewardSummary>> GetRewardSummaryAllAsync();

        Task<CustomerRewardSummary> GetRewardSummaryByCustomerIdAsync(long customerId);      

        Task<IEnumerable<Customer>> GetCustomerAllAsync();

        Task<Customer> GetCustomerByIdAsync(long customerId);

        
    }
}
