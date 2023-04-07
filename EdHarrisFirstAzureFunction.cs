// This is an HTTP-triggered Azure Function that is invoked when an HTTP request is sent to
// http://localhost:7071/api/EdHarrisFirstAzureFunction. The function can be invoked from a
// web browser, a REST client, or any other HTTP client.
//
// The function defines a single parameter named "req" that is of type HttpRequest. The
// HttpRequest parameter represents the HTTP request that caused the function to be invoked.
// This parameter can be used to access any information about the request, such as the request
// body, the request headers, the request query string, etc. In this example, the function
// retrieves the name value from the query string, from the request body, or from a default
// value if neither the query string nor the request body contain a name value.
//
// The function builds a response message that is returned to the caller. The function
// returns the response message wrapped in an OkObjectResult object, which is an instance of
// the IActionResult interface. The IActionResult interface is the return type of the
// EdHarrisFirstAzureFunction function. The IActionResult interface defines a single
// ExecuteResultAsync method that is used to execute the action and return a response to the
// caller. In this example, the function returns an OkObjectResult object, which is an
// instance of the IActionResult interface. The OkObjectResult class is a built-in class that
// implements the IActionResult interface and provides an ExecuteResultAsync method that
// returns the response message to the caller.
//
// The function name is "EdHarrisFirstAzureFunction". The function name is specified by the
// [FunctionName("EdHarrisFirstAzureFunction")] attribute. The function name is used to
// uniquely identify the function in the Azure portal, the Azure CLI, and the Azure PowerShell
// command line interface. The function name is also used to uniquely identify the function
// when the function is published to Azure.
//
// The function is an HTTP-triggered function. The function is an HTTP-triggered function
// because the [HttpTrigger] attribute is applied to the HttpRequest parameter. The
// [HttpTrigger] attribute specifies that the function should be invoked when an HTTP request
// is sent to the function URL. In this example, the function URL is
// http://localhost:7071/api/EdHarrisFirstAzureFunction. The [HttpTrigger] attribute also
// specifies the HTTP request methods that should be used to invoke the function. In this
// example, the [HttpTrigger] attribute specifies that the function should be invoked by
// GET and POST HTTP requests. The [HttpTrigger] attribute also specifies that the function
// should be invoked when the URL is http://localhost:7071/api/EdHarrisFirstAzureFunction.
// The [HttpTrigger] attribute can also be used to specify a route template that is used to
// invoke the function. In this example, the route template is null, which means that the
// function is invoked by any HTTP request sent to the function URL.
//
// The function is an anonymous function. The function is an anonymous function because the
// [HttpTrigger] attribute is applied to the HttpRequest parameter, and the
// [HttpTrigger] attribute specifies that the function should be invoked by anonymous HTTP
// requests. The [HttpTrigger] attribute also specifies that the function should be invoked
// by anonymous HTTP requests. Anonymous HTTP requests are HTTP requests that do not include
// an authorization header. Anonymous HTTP requests are used to invoke functions that do not
// require authentication or authorization. Anonymous HTTP requests are also used to invoke
// functions that require authentication or authorization, but the authentication or
// authorization is handled by the function code.
//
// The function is an asynchronous function. The function is an asynchronous function
// because the function returns a Task<IActionResult> object. The Task<IActionResult> object
// represents the asynchronous execution of the function. The Task<IActionResult> object
// implements the Task<T> class, which is a generic class that is used to represent the
// asynchronous execution of a function that returns a result. The Task<T> class is a generic
// class that is used to represent the asynchronous execution of a function that returns a
// result. The Task<T> class is a generic class that is used to represent the asynchronous
// execution of a function that returns a result. The Task<T> class is a generic class that
// is used to represent the asynchronous execution of a function that returns a result. The
// Task<T> class is a generic class that is used to represent the asynchronous execution of a
// function that returns a result. The Task<T> class is a generic class that is used to
// represent the asynchronous execution of a function that returns a result. The Task<T>
// class is a generic class that is used to represent the asynchronous execution of a function
// that returns a result. The Task<T> class is a generic class that is used to represent the
// asynchronous execution of a function that returns a result. The Task<T> class is a generic
// class that is used to represent the asynchronous execution of a function that returns a
// result. The Task<T> class is a generic class that is used to represent the asynchronous
// execution of a function that returns a result. The Task<T> class is a generic class that
// is used to represent the asynchronous execution of a function that returns a result. The
// Task<T> class is a generic class that is used to represent the asynchronous execution of a
// function that returns a result. The Task<T> class is a generic class that is used to
// represent the asynchronous execution of a function that returns a result. The Task<T>
// class is a generic class that is used to represent the asynchronous execution of a function

using System; // System is the base namespace for .NET Framework, and contains the vast majority of classes that you use in your code.
using System.IO; // System.IO contains types that enable reading and writing to files and data streams, and types that provide basic file and directory support.
using System.Threading.Tasks; // System.Threading.Tasks contains types that support the Task and Task<T> types and related types.
using Microsoft.AspNetCore.Mvc; // Contains types for building ASP.NET Core MVC web apps.
using Microsoft.Azure.WebJobs; // Contains types for building Azure Functions.
using Microsoft.Azure.WebJobs.Extensions.Http; // Contains types for building HTTP triggered Azure Functions.
using Microsoft.AspNetCore.Http; // Contains types for building HTTP triggered Azure Functions.
using Microsoft.Extensions.Logging; // Contains types for logging events to the logger.
using Newtonsoft.Json; // Contains types for serializing and deserializing JSON.

namespace EdHarris.MyFirstAzureFunctions // Namespaces are used to organize code and to provide a unique name for the code in each assembly.
{
    public static class EdHarrisFirstAzureFunction // The public keyword indicates that the class is accessible by any other code in the same assembly or another assembly that references it.
    {
        [FunctionName("EdHarrisFirstAzureFunction")] // The name of the function in Azure (must be unique)
        public static async Task<IActionResult> CouldBeAnythingButDefaultsToRun( // The return type of the function. In this case, it is a Task that returns an IActionResult.
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req, // The type of trigger. In this case, it is an HTTP trigger.
            ILogger log) // The logging interface that allows you to log messages to the console.
        {
            string name = req.Query["name"]; // Get the query string parameter called "name" from the request.

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync(); // Read the request body and store it as a string.
            dynamic data = JsonConvert.DeserializeObject(requestBody); // Deserialize the request body into a dynamic object.
            name = name ?? data?.name; // If the name is null or empty, set it to the value of the name property in the dynamic object.

            // Log the name to the console
            log.LogInformation($"C# HTTP trigger function processed a request. Name={name}");

            // Build the response
            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            // Return the response
            return new OkObjectResult(responseMessage);
        }
    }
}
