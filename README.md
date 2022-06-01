# Retail Customer Management

 
 
### Table of Contents 
 1. [ Database Tables. ](#DatabaseTables)
 2. [ Technologies Used ](#TechnologiesUsed)
 3. [ Swagger UI ](#SwaggerUI)
 4. [ Code Description ](#CodeDescription)
 5. [ Custom Logging: Log4Net ](#CustomLogging)
 6. [ Exception Handling ](#ExceptionHandling)
 7. [ Health Check Endpoint ](#HealthCheckEndpoint)
 8.  [ Test Cases ](#TestCases)
     *   [Method 1  -  CalculateRewardPoints ](#CalculateRewardPoints)
     *   [Method 2  -  GetRewardSummaryAll ](#GetRewardSummaryAll)
     *   [Method 3  -  GetRewardSummaryByCustomerId ](#GetRewardSummaryByCustomerId)
     *   [Method 4  -  GetCustomerAll ](#GetCustomerAll)
     *   [Method 5  -  GetCustomerById ](#GetCustomerById)

 <br />
 <br />
  
<a name="DatabaseTables"></a>
## Database Tables

### Table 1 :  tblCustomer  
  All the customer related data will be stored in this table. Below is the table with some TestData.
 
 ![image](https://user-images.githubusercontent.com/106505508/171414845-6c425499-8179-49c5-a9f8-7640bb36c886.png)


### Table 2:  tblRewardPointSlabRate
  This tables will have Slab rates  for rewardpoints i.e how many points a customer can get for the amount spent on items.
. Below is the table with some TestData

![image](https://user-images.githubusercontent.com/106505508/171414938-1900553a-fea3-4ca3-973f-2ee2e2f47fb2.png)

 

 
![image](https://user-images.githubusercontent.com/106505508/171414983-6d33c6f4-f0e7-4338-84a4-f2bfaaf96f8b.png)






### Table 3 :  tblCustomerTransactionDetails
This table stores  all the transaction details for each individual customer. It will have  details related to CustomerID,  amount spent , reward points earned and TransactionDateTime.

 
![image](https://user-images.githubusercontent.com/106505508/171415205-eedb4292-8c59-4337-b458-18f0d864706b.png)






### Table 4 :  tblRewardsSummary
This table stores  reward point summary details  for each individual customer for the last three months.
It will have separate column for  current month rewardPoints, Previous month reward points and priorToPreviousmonth reward Points.

 

![image](https://user-images.githubusercontent.com/106505508/171415256-b1dfbd60-a913-46d6-8663-0a5d8129cd18.png)



 <br /><br />
<a name="TechnologiesUsed"></a> 
## Technologies Used:

Asp.Net Core Web API and .NET Core 3.1 is used to implement the task assigned.
<br/>Tools -  Visual Studio -2019 Community Edition.

 
![image](https://user-images.githubusercontent.com/106505508/171415317-caf31f6e-b0b6-44ad-ad50-58f2b048a993.png)


<br /><br />
<a name="SwaggerUI"></a>
## Swagger UI:

Swagger is a simple yet powerful representation of your Restful API. 
It is implemented in the project using Nuget package manager.
 

![image](https://user-images.githubusercontent.com/106505508/171415657-e56a0800-0f4c-4860-8e80-7ad56e580a5e.png)



<br /><br />
<a name="CodeDescription"></a>
## Code Description:

RetailCustomerManagment project consists of Multilayer architecture and follows the Repository pattern to loosely couple all the Project modules.

 
![image](https://user-images.githubusercontent.com/106505508/171497072-ebcedd00-bb9c-4437-aa73-d0ef8edede77.png)


It has following sub projects.
#### &nbsp;&nbsp; 1.	RCM.API: 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;This project consists of all the ASPDotNet Core WEB API related logic.

#### &nbsp;&nbsp; 2.	RCM.Business: 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;This Project consists of all the Business related logic.

#### &nbsp;&nbsp; 3.	RCM.Repositories:
 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;This Project consists of all the Data repostitories  related logic.

#### &nbsp;&nbsp; 4.	RCM.Model: 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;This Project consists of all the Models objects for the Project.

#### &nbsp;&nbsp; 5.	RCM.Common : 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;This Project consists of all the common logic related to the project. 
 </br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Ex : Common Exception Logic.


<br /><br />
<a name="CustomLogging"></a>
## Custom Logging: Log4Net

All the logging is implemented in the application using Log4Net.
It will have below configurations.
 
![image](https://user-images.githubusercontent.com/106505508/171415762-fca402b7-a1ba-4a2d-b42a-a86e2f49ec1f.png)


<br /><br />
<a name="ExceptionHandling"></a>
## Exception Handling:

Domain related custom Exception Handling is implemented in the project  using  Middleware.

app.UseMiddleware<ExceptionHandlingMiddleware>();
 
![image](https://user-images.githubusercontent.com/106505508/171415832-ffc3d16a-3e66-4f88-aa1e-5d036fb94236.png)


 ![image](https://user-images.githubusercontent.com/106505508/171415911-03beb42c-15b3-402e-84c9-43fadcebabb0.png)


 <br /><br /> 
 <a name="HealthCheckEndpoint"></a>
## Health Check Endpoint:

A health check endpoint is added to project using Microsoft.AspNetCore.Diagnostics.HealthChecks
 
  ![image](https://user-images.githubusercontent.com/106505508/171415979-4b5c9924-d43b-4616-8959-9bb7320c991c.png)

  
The Endpoint will return “Healthy” ,if the application is live and running.
  
<br /><br />  

<a name="TestCases"></a>
# TestCases:
<br /><br />
<a name="CalculateRewardPoints"></a>
## Method 1  -  CalculateRewardPoints
  
  Request URL : https://localhost:44363/api/Customer/CalculateRewardPoints?amountSpent=120
<br />  
#### Scenario 1 Test Data: 
Amount Spent = 120<br />  
Expected output:  90 points.<br />
Status code =200 OK.<br />
Test Result: Pass<br />
  <br />  
#### Output from Postman application:

  ![image](https://user-images.githubusercontent.com/106505508/171465582-107ba7e4-bc7c-42e5-9958-2c1336b0fc50.png)
  <br />  
#### Output from Swagger UI:
  
  ![image](https://user-images.githubusercontent.com/106505508/171465684-4086b7c3-69ff-4a13-a857-330d2b5daf26.png)

  <br />  <br />  
#### Scenario 2 Test Data: 
Amount Spent =  -100<br />  
Expected output:   “"Amount Spent should be greater than or equal to 0<br />  
 
Status code =400 Bad Request.<br />  
Test Result: Pass<br />  
  
https://localhost:44363/api/Customer/CalculateRewardPoints?amountSpent=-100

  ![image](https://user-images.githubusercontent.com/106505508/171465846-998f1125-a447-4099-8dd6-f94fde853b76.png)

  
<br /><br />  
<a name="GetRewardSummaryAll"></a>
## Method 2  -  GetRewardSummaryAll
  
##### URL: https://localhost:44363/api/Customer/GetRewardSummaryAll

This method will return Reward Summary data of all the customers in the last 3months.<br />  
Test Result  : <b>Pass<b><br />  
  
![image](https://user-images.githubusercontent.com/106505508/171465947-5b764c1b-deb6-4969-9d7f-b23ff9f9cda1.png)
<br /><br /><br />
  
 <a name="GetRewardSummaryByCustomerId"></a>
## Method 3 -  GetRewardSummaryByCustomerId
 
#####  URL: https://localhost:44363/api/Customer/GetRewardSummaryByCustomerId?customerId=4

This method will return Reward Summary details of last 3months for the customer ID given. 
 <br />  
####  Scenario 1 Test Data: 
 CustmomerID = 4<br />
Expected output:   Sudheer Kumar details has to be shown which is of customerID 4.<br />
Status code =200 OK.<br />  
Test Result: Pass<br />  

  ![image](https://user-images.githubusercontent.com/106505508/171466521-4d0dc71c-b76a-483e-a3e2-240237747c87.png)

####  Scenario 2 Test Data:<br />
#####  URI : https://localhost:44363/api/Customer/GetRewardSummaryByCustomerId?customerId=55 <br />

This method will return status code 404 as the given customer id is not found in the database<br />
CustmomerID = 55 <br /> 
Expected output:   CustomerId Not Found.Please enter valid customerId.<br />
Status code =404 OK.<br /> 
Test Result: Pass<br />

  
  ![image](https://user-images.githubusercontent.com/106505508/171466586-254cd519-ebb4-494e-8f50-e423e7f747a7.png)
  
  
 <br /><br /> 
 
 <a name="GetCustomerAll"></a>
##  Method 4 -  GetCustomerAll
  
####  URL: https://localhost:44363/api/Customer/GetCustomerAll

This method will return all the customer details.<br /> 
Expected output: It should return all the 10 customer details.<br /> 
Test result : Pass<br /> 
  
  ![image](https://user-images.githubusercontent.com/106505508/171467604-6b1bc833-3548-4b89-9474-c9532a2bdc5c.png)

<br /><br />
 <a name="GetCustomerById"></a>
##  Method 5 -  GetCustomerById
  
URI:  https://localhost:44363/api/Customer/GetCustomerById?customerId=6

This method will give the customer details of the ID given as input.<br /> 
Input Customer ID : 6<br /> 
Expected output:   Ram Potheneni details have to be returned.<br /> 

  
  ![image](https://user-images.githubusercontent.com/106505508/171467706-42b2ecce-c9fc-4e9b-b297-6238f089b12e.png)

  
  
