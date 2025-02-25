# Task-Billing-API
This repository contains a description of the programming task used to evaluate software developers.

## Billing API

"XYZ Inc." is an imaginary company with main business focus on selling a variety of goods and services online via their E-Shop platform. 
Currently, there is a need for a new billing API that could process orders.

Each incoming order should contain:
*   Order number;
*	User id;
*	Payable amount;
*	Payment gateway (identifier to map appropriate payment gateway);
*	Optional description.

When the billing service processes order, it sends the order to an appropriate payment gateway. If the order is processed successfully by the payment gateway, the billing service creates a receipt and returns it in response.

## Implementation rules

* Code should be covered with unit tests;
* Programming language - C#;
* Solution should be put into Github;
* Use REST API.

Rather than that, there are no restrictions - you can use any .NET framework you like, add any dependencies you want and enrich this API by any functionality you want to. The main goal of this task is to understand how you think and to see how your actual code looks.

Good luck! :)

## Result

API url is: /api/Billing

Basic auth: user: testuser, password: testpassword

Basic auth is super simple to test to require authorization when calling API. In real life you should never hardcode login information.

Body format:
```json
{
  "orderNumber": 123, //int? required
  "userId": 123, //int? required
  "payableAmount": 100, //decimal? required positive 
  "paymentGateway": "PayPal", //string? required ["PayPal", "SwedBank", "SEB"]]
  "description": "Test order" //string? optional
}
```

Controls:
* Control on required input
* There is control that checks if "userId" can work with "orderNumber". So for testing purposes I return true when both values ​​are same.
* Control payment gateway


Response format:
```json
{
	"orderNumber": 11, //int? 
	"userId": 11, //int? 
	"amountPaid": 213, //double?
	"paymentDate": "2025-02-25T20:42:07.4979497+02:00" //DateTime?
}
```

