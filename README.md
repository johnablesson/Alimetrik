# Alimetrik
Alimetrik coding challenge

# How to Build and Run the code

## PreRequsites
1. Visual Studio 2022
1. .NET6 SDK

- Open the solution file Zip.InstallmentsService.sln in Visual Studio 2022.
- Build the solution
- Run the solution is IIS Express
- On the start of the API, you will be provided with a swagger page with 2 endpoints

# Swagger Documentation
There are 2 API endpoints in the swagger documentation.

## Create Payment Plan

This endpoint will create a payment plan for a given Purhcase amount, Purchase Date and number of installments.

###Request Url

POST https://localhost:44384/api/v1/paymentplan

###Request Body

{
  "purhcaseDate": "2022-10-25T11:01:15.749Z",
  "purchaseAmount": 0,
  "installments": 0
}


## Get Payment Plan

###Request

This endpoint will return Payment Plan details for a given Payment Plan Id.

GET api/v1/paymentplan/id/3fa85f64-5717-4562-b3fc-2c963f66afa6



