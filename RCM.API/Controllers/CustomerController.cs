 
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RCM.Common.Exception;
using RCM.Business;
using RCM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace RCM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerService _customerService;

        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ICustomerService customerService, ILogger<CustomerController> logger)
        {
            this._customerService = customerService;
            this._logger = logger;
        }

                
        [HttpGet("CalculateRewardPoints")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> CalculateRewardPointsAsync(decimal amountSpent)
        {
             
            _logger.LogInformation("Start : Calculate Reward points for AmountSpent :  {AmountSpent}", amountSpent);


            int rewardPoints = 0;
            if (amountSpent < 0)
            { 
                throw new DomainValidationException("Amount Spent should be greater than or equal to 0");   
            }
            else
            {
                rewardPoints = await _customerService.CalculateRewardPointsAsync(amountSpent);

                _logger.LogInformation("Completed : Reward Points is {rewardPoints}", rewardPoints);

                return Ok(new
                {
                    StatusCode = 200,
                    rewardPoints = rewardPoints

                });
            }
        }


       
        [HttpGet("GetRewardSummaryAll")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]      
        public async Task<ActionResult<IEnumerable<CustomerRewardSummary>>> GetRewardSummaryAllAsync()
        {
            _logger.LogInformation("Start : GetRewardSummaryAll");

            IEnumerable<CustomerRewardSummary> rewardSummarylst = await _customerService.GetRewardSummaryAllAsync();

            _logger.LogInformation("Completed : GetRewardSummaryAll");

            return Ok(new
            {
                StatusCode = 200,
                RewardSummaryDetails = rewardSummarylst

            });
        }


        [HttpGet("GetRewardSummaryByCustomerId")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CustomerRewardSummary>> GetRewardSummaryByCustomerIdAsync(long customerId)
        {
            _logger.LogInformation("Start : GetRewardSummaryByCustomerId {customerId}", customerId);

            CustomerRewardSummary rewardSummaryObj = await _customerService.GetRewardSummaryByCustomerIdAsync(customerId);

            if (rewardSummaryObj == null)
            {
                throw new DomainNotFoundException("CustomerId Not Found.Please enter valid customerId");               
            }
            else
            {
                _logger.LogInformation("Completed : GetRewardSummaryByCustomerId");

                return Ok(new
                {
                    StatusCode = 200,
                    RewardSummary = rewardSummaryObj

                });
            }
        }

         

        [HttpGet("GetCustomerAll")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]      
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomerAll()
        {
             
            _logger.LogInformation("Start : GetCustomerAll");

            var lstCustomer = await _customerService.GetCustomerAllAsync();

            _logger.LogInformation("Completed : GetCustomerAll");

            return Ok(new
            {
                StatusCode = 200,
                CustomerDetails = lstCustomer

            });
        }



        [HttpGet("GetCustomerById")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Customer>> GetCustomerByIdAsync(long customerId)
        {

            _logger.LogInformation("Start : GetCustomerById {CustomerId}", customerId);

            Customer customerObj = await _customerService.GetCustomerByIdAsync(customerId);

            if (customerObj == null)
            {
                throw new DomainNotFoundException("CustomerId Not Found.Please enter valid customerId");                
            }
            else
            {
                _logger.LogInformation("Completed : GetCustomerById");

                return Ok(new
                {
                    StatusCode = 200,
                    Customer = customerObj

                });
            }


        }

    }
}
