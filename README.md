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

The swager documentation link is https://localhost:44384/swagger

There are 2 API endpoints in the swagger documentation.

## Create Payment Plan

This endpoint will create a payment plan for a given Purhcase amount, Purchase Date and number of installments.

### Request

```
POST https://localhost:44384/api/v1/paymentplan
{
  "purhcaseDate": "2022-10-25T11:01:15.749Z",
  "purchaseAmount": 1000,
  "installments": 4
}
```

## Get Payment Plan

This endpoint will return Payment Plan details for a given Payment Plan Id.

### Request

```
GET api/v1/paymentplan/id/3fa85f64-5717-4562-b3fc-2c963f66afa6
```

# How to Run Unit Tests
The unit tests are present in the project *Zip.InstallmentsService.Test* in the same solution. You can open the test explorer and run all the tests.

# How to setup the database

There is no need to setup any database. The project uses Entity Framework Core with In-Memory database. So, the database is created in-memory on the fly.


