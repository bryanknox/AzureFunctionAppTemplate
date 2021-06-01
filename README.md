# AzureFunctionApp Template Repo
Template repo for creating a C# Azure Function App.

# This Sample Uses:
- C#
- .NET Core v3.1
- Azure Functions v3
- [Dependency Injection](https://docs.microsoft.com/en-us/azure/azure-functions/functions-dotnet-dependency-injection)

# Usage
Add your own functions (even Durable functions) and wire up the dependencies in the `Startup.cs` file.

## Sample Function and Service Library
`HelloService` class is implemented in the `Service.Hello` class library project.
It is injected into the sample `HttpTriggeredFunction`. 

### Removing the sample Function and Service Library
To get rid of the sample function and service library:
1. Delete the `HttpTriggeredFunction`.
1. Remove the `builder.Services.AddHelloService();` line from `Startup.cs`.
1. Remove `Service.Hello` libary from the solution and delete the `Service.Hello` folder from your workspace.
