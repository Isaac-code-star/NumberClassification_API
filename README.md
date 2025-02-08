## Number Classify API 

Here’s a detailed README.md for your Number Classification API in C# .NET with CORS support. You can upload this to GitHub to help others understand and use your project effectively.

📌 Number Classification API

A simple .NET Web API that classifies a number based on multiple mathematical properties:
	•	Prime Number
	•	Perfect Number
	•	Armstrong Number
	•	Fun Fact
	•	Sum of Digits
	•	Custom Properties (e.g., “armstrong”, “odd”)

🚀 Supports CORS for cross-origin API calls.

📂 Project Setup

1️⃣ Prerequisites
	•	.NET SDK 9.0+
	•	Visual Studio / VS Code
	•	Postman  (for testing)

2️⃣ Clone the Repository

git clone https://github.com/your-username/number-classification-api.git
cd number-classification-api

3️⃣ Install Dependencies

dotnet restore

4️⃣ Run the API

dotnet run

By default, the API runs on https://localhost:5279.

🛠 API Endpoints

✅ Classify a Number

Request

GET /api/classify-number/{number}

Example:

curl -X GET http://localhost:5000/api/classify-number/371

Response

{
  "number": 371,
  "isPrime": false,
  "isPerfect": false,
  "sumOfDigits": 11,
  "properties": ["armstrong", "odd"],
  "fun fact": "371 is an armstrong number because 3^3 + 7^3 + 1^3 = 371"
}

❌ Handling Invalid Input

If a non-numeric value is provided:

GET /api/NumberClassification/classify/abc

Response

{
  "number": "abc",
  "error": true
}

(Returns HTTP 400 Bad Request)

🌍 Enabling CORS

The API supports Cross-Origin Resource Sharing (CORS) for frontend apps to call it from different domains.

To allow all origins, it’s enabled in Program.cs:

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

Modify as needed to allow only specific domains.

🔧 Modifying Number Properties

To check for specific properties like "armstrong" and "odd", update:

var result = new
{
    Number = number,
    Properties = GetNumberProperties(number, new List<string> { "armstrong", "odd" })
};

Modify the list to include new properties.

🚀 Deployment

Deploy to Azure
	1.	Build the project:

dotnet publish -c Release -o ./publish


	

Feel free to open an issue on GitHub. 🚀

This README.md is GitHub-friendly and well-structured. Let me know if you’d like any additional sections! 🚀
