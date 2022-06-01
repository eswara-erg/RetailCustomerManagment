using RCM.Repositories;
using RCM.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RCM.Business
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        public CustomerService(ICustomerRepository repository)
        {
            this._repository = repository;
        }



        public async Task<int> CalculateRewardPointsAsync(decimal amountSpent)
        {
            int RewardPoints = await _repository.CalculateRewardPointsAsync(amountSpent);
            return RewardPoints;
        }


        public async Task<IEnumerable<CustomerRewardSummary>> GetRewardSummaryAllAsync()
        {
            IEnumerable<CustomerRewardSummary> rewardSummarylst = await _repository.GetRewardSummaryAllAsync();
            return rewardSummarylst;
        }

        public async Task<CustomerRewardSummary> GetRewardSummaryByCustomerIdAsync(long customerId)
        {
            CustomerRewardSummary rewardSummaryObj = await _repository.GetRewardSummaryByCustomerIdAsync(customerId);
            return rewardSummaryObj;
        }

         

        public async Task<IEnumerable<Customer>> GetCustomerAllAsync()
        {
            IEnumerable<Customer> lstCustomer = await _repository.GetCustomerAllAsync();
            return lstCustomer;
        }

        public async Task<Customer> GetCustomerByIdAsync(long customerId)
        {
            Customer customerObj = await _repository.GetCustomerByIdAsync(customerId);
            return customerObj;
        }

    }
}
