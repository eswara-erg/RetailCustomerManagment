using RCM.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RCM.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public async Task<int> CalculateRewardPointsAsync(decimal amountSpent)
        {
            //Reading Reward Point slab rates from MockData /backend DB .
            //We can Add multiple slabs for reward points in database without modifying the code.

            IEnumerable<RewardPointSlabRate> lstRewardPointSlabRates =  await GetMockRewardPointSlabRatesAsync();

            //Logic given in email to calculate the rewardpoints.
            //(120 -50) *1 + (120 -100)*1=90 points 

            int rewardPoints = 0;
            foreach (var rewardPointSlabRateObj in lstRewardPointSlabRates)
            {
                if (amountSpent > rewardPointSlabRateObj.SlabRate)
                {
                    rewardPoints = rewardPoints + Convert.ToInt32((amountSpent - rewardPointSlabRateObj.SlabRate) * rewardPointSlabRateObj.RewardPointsEarned);
                }
            }
            return rewardPoints;


        }


        public async Task<IEnumerable<CustomerRewardSummary>> GetRewardSummaryAllAsync()
        {
            IEnumerable<CustomerRewardSummary> lstRewardSummary = await GetMockRewardSummaryDataAsync(); ;
            
            return lstRewardSummary;
        }



        public async Task<CustomerRewardSummary> GetRewardSummaryByCustomerIdAsync(long customerId)
        {
            List<CustomerRewardSummary> lstRewardSummary = await GetMockRewardSummaryDataAsync();
            CustomerRewardSummary rewardSummaryObj = lstRewardSummary.Find(i => i.CustomerId == customerId);
            return rewardSummaryObj;
        }
         

        public async Task<IEnumerable<Customer>> GetCustomerAllAsync()
        {
            IEnumerable<Customer> lstCustomer  = await GetMockCustomerDataAsync();
            return lstCustomer;
        }


        public async Task<Customer> GetCustomerByIdAsync(long customerId)
        {
            List<Customer> lstCustomer = await GetMockCustomerDataAsync();   
            Customer customerObj = lstCustomer.Find(i => i.CustomerId == customerId);
            return customerObj;
        }


        public async Task<IEnumerable<RewardPointSlabRate>> GetMockRewardPointSlabRatesAsync()
        {

            List<RewardPointSlabRate> lstRewardPointSlabRates = null;

            await Task.Run(() =>
            {
                    lstRewardPointSlabRates = new List<RewardPointSlabRate>()
                    {
                         new RewardPointSlabRate()
                         {
                             SlabId =1,
                             RewardPointsEarned =1,
                             SlabRate =50
                         },

                         new RewardPointSlabRate()
                         {
                             SlabId =2,
                             RewardPointsEarned =1,
                             SlabRate =100
                         }
                    };
            });



            return lstRewardPointSlabRates;

        }

        public async Task<List<Customer>> GetMockCustomerDataAsync()
        {

            List<Customer> customerlst = null;

            await Task.Run(() =>
            {
                customerlst = new List<Customer>()
                {
                    #region TestData

                    new Customer() {
                        CustomerId = 1,FirstName="Rajesh",LastName="Kumar",
                        MobileNumber= "9393939393", EmailId ="rajesh@gmail.com",
                        CreatedDateTime= Convert.ToDateTime("02-04-2020  10:30:54") ,
                        UpdatedDateTime= Convert.ToDateTime("11-04-2020  17:30:54")
                     },


                   new Customer() {
                        CustomerId = 2,FirstName="Bhaskar",LastName="Raju",
                        MobileNumber= "7894569777", EmailId ="bhaskar@gmail.com",
                        CreatedDateTime= Convert.ToDateTime("18-06-2021  12:30:55") ,
                        UpdatedDateTime= Convert.ToDateTime("18-06-2021  12:30:55")
                   },


                    new Customer() {
                        CustomerId = 3,FirstName="Shanu",LastName="Mohidhin",
                        MobileNumber= "5555555555", EmailId ="shanu@gmail.com",
                        CreatedDateTime= Convert.ToDateTime("19-06-2021  14:55:12") ,
                        UpdatedDateTime= Convert.ToDateTime("19-06-2021  14:55:12")
                    },


                   new Customer() {
                        CustomerId = 4,FirstName="Sudheer",LastName="Kumar",
                        MobileNumber= "7895693265", EmailId ="sudheer@gmail.com",
                        CreatedDateTime= Convert.ToDateTime("26-08-2021  18:11:25") ,
                        UpdatedDateTime= Convert.ToDateTime("26-08-2021  18:11:25")
                   },


                    new Customer() {
                        CustomerId = 5,FirstName="Pavan",LastName="Behathi",
                        MobileNumber= "4546414949", EmailId ="pavan@gmail.com",
                        CreatedDateTime= Convert.ToDateTime("12-09-2021  11:48:33") ,
                        UpdatedDateTime= Convert.ToDateTime("12-09-2021  11:48:33")
                    },


                    new Customer() {
                        CustomerId = 6,FirstName="Ram",LastName="Potheneni",
                        MobileNumber= "4565548463", EmailId ="ram@gmail.com",
                        CreatedDateTime= Convert.ToDateTime("25-10-2021  13:45:59") ,
                        UpdatedDateTime= Convert.ToDateTime("25-10-2021  13:45:59")
                    },


                    new Customer() {
                        CustomerId = 7,FirstName="Chaithanya",LastName="Reddy",
                        MobileNumber= "7956959859", EmailId ="chaithanya@gmail.com",
                        CreatedDateTime= Convert.ToDateTime("08-11-2021  16:11:20") ,
                        UpdatedDateTime= Convert.ToDateTime("08-11-2021  16:11:20")
                    },


                    new Customer() {
                        CustomerId = 8,FirstName="Sudeshana",LastName="Singh",
                        MobileNumber= "4595956148", EmailId ="sudheshana@gmail.com",
                        CreatedDateTime= Convert.ToDateTime("16-12-2021  20:30:22") ,
                        UpdatedDateTime= Convert.ToDateTime("16-12-2021  20:30:22")
                    },


                    new Customer() {
                        CustomerId = 9,FirstName="Vaishnavi",LastName="Devi",
                        MobileNumber= "8878945687", EmailId ="vaishnavi@gmail.com",
                        CreatedDateTime= Convert.ToDateTime("05-01-2022  10:16:21") ,
                        UpdatedDateTime= Convert.ToDateTime("05-01-2022  10:16:21")
                    },


                    new Customer() {
                        CustomerId = 10,FirstName="Siva",LastName="Shanmathi",
                        MobileNumber= "7985569595", EmailId ="siva@gmail.com",
                        CreatedDateTime= Convert.ToDateTime("21-02-2022  18:29:11") ,
                        UpdatedDateTime= Convert.ToDateTime("21-02-2022  18:29:11")
                    },
                 

                    #endregion TestData 
                };

            });


            return customerlst;
        }

        public async Task<List<CustomerRewardSummary>> GetMockRewardSummaryDataAsync()
        {
            List<CustomerRewardSummary> _rewardSummarylst = null;

            await Task.Run(() =>
            {
                 _rewardSummarylst = new List<CustomerRewardSummary>()
                    {
                        #region TestData

                        new CustomerRewardSummary() {
                            RewardSummaryId = 1,CustomerId=1,CustomerName="Rajesh Kumar",
                            CurrentMonthRewardPoints= 1800, PreviousMonthRewardPoints =0,
                            PriorToPreviousMonthRewardPoints=100,TotalRewardPointsInLast3Months =1900 ,
                            UpdatedDateTime= Convert.ToDateTime("25-05-2022  22:17:54")},


                        new CustomerRewardSummary() {
                            RewardSummaryId = 2,CustomerId=2,CustomerName="Bhaskar Raju",
                            CurrentMonthRewardPoints= 13, PreviousMonthRewardPoints =100,
                            PriorToPreviousMonthRewardPoints=500,TotalRewardPointsInLast3Months =613 ,
                            UpdatedDateTime= Convert.ToDateTime("25-05-2022  22:17:54")},


                        new CustomerRewardSummary() {
                            RewardSummaryId = 3,CustomerId=3,CustomerName="Shanu Mohidhin",
                            CurrentMonthRewardPoints= 0, PreviousMonthRewardPoints =0,
                            PriorToPreviousMonthRewardPoints=0,TotalRewardPointsInLast3Months =0 ,
                            UpdatedDateTime= Convert.ToDateTime("25-05-2022  22:17:54")},


                        new CustomerRewardSummary() {
                            RewardSummaryId = 4,CustomerId=4,CustomerName="Sudheer Kumar",
                            CurrentMonthRewardPoints= 233, PreviousMonthRewardPoints =450,
                            PriorToPreviousMonthRewardPoints=600,TotalRewardPointsInLast3Months =1283 ,
                            UpdatedDateTime= Convert.ToDateTime("25-05-2022  22:17:54")},


                        new CustomerRewardSummary() {
                            RewardSummaryId = 5,CustomerId=5,CustomerName="Pavan Behathi",
                            CurrentMonthRewardPoints= 250, PreviousMonthRewardPoints =500,
                            PriorToPreviousMonthRewardPoints=0,TotalRewardPointsInLast3Months =750 ,
                            UpdatedDateTime= Convert.ToDateTime("25-05-2022  22:17:54")},


                        new CustomerRewardSummary() {
                            RewardSummaryId = 6,CustomerId=6,CustomerName="Ram Potheneni",
                            CurrentMonthRewardPoints= 25, PreviousMonthRewardPoints =1000,
                            PriorToPreviousMonthRewardPoints=1800,TotalRewardPointsInLast3Months =2825 ,
                            UpdatedDateTime= Convert.ToDateTime("25-05-2022  22:17:54")},


                        new CustomerRewardSummary() {
                            RewardSummaryId = 7,CustomerId=7,CustomerName="Chaithanya Reddy",
                            CurrentMonthRewardPoints= 1500, PreviousMonthRewardPoints =2500,
                            PriorToPreviousMonthRewardPoints=20,TotalRewardPointsInLast3Months =4020 ,
                            UpdatedDateTime= Convert.ToDateTime("25-05-2022  22:17:54")},


                        new CustomerRewardSummary() {
                            RewardSummaryId = 8,CustomerId=8,CustomerName="Sudeshana Singh",
                            CurrentMonthRewardPoints= 1800, PreviousMonthRewardPoints =0,
                            PriorToPreviousMonthRewardPoints=100,TotalRewardPointsInLast3Months =150 ,
                            UpdatedDateTime= Convert.ToDateTime("25-05-2022  22:17:54")},


                        new CustomerRewardSummary() {
                            RewardSummaryId = 9,CustomerId=9,CustomerName="Vaishnavi Devi",
                            CurrentMonthRewardPoints= 120, PreviousMonthRewardPoints =1500,
                            PriorToPreviousMonthRewardPoints=120,TotalRewardPointsInLast3Months =1740 ,
                            UpdatedDateTime= Convert.ToDateTime("25-05-2022  22:17:54")},


                        new CustomerRewardSummary() {
                            RewardSummaryId = 10,CustomerId=10,CustomerName="Siva Shanmathi",
                            CurrentMonthRewardPoints= 188, PreviousMonthRewardPoints =60,
                            PriorToPreviousMonthRewardPoints=0,TotalRewardPointsInLast3Months =248 ,
                            UpdatedDateTime= Convert.ToDateTime("25-05-2022  22:17:54")},
                 

                        #endregion TestData 
                    };

            });


           

            return _rewardSummarylst;
        }

    }
}
