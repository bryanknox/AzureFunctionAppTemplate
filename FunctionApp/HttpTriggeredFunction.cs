using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Service.Hello;

namespace FunctionApp
{
    public class HttpTriggeredFunction
    {
        private readonly IHelloService _helloService;

        public HttpTriggeredFunction(IHelloService helloService)
        {
            _helloService = helloService;
        }

        [FunctionName(nameof(HttpTriggeredFunction))]
        public async Task<IActionResult> Run(
            [HttpTrigger(
                AuthorizationLevel.Anonymous,
                "get",
                "post",
                Route = null
            )] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function received a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);

            string name = (string)req.Query["name"] ?? data?.name;

            if (!string.IsNullOrWhiteSpace(name))
            {
                string helloMessage = _helloService.SayHelloTo(name);

                string responseMessage = $"{helloMessage} This HTTP triggered function executed successfully.";

                log.LogInformation(responseMessage);

                return new OkObjectResult(responseMessage);
            }

            string nameMissingResponseMessage = "This HTTP triggered function executed successfully."
                + " Pass a name in the query string or in the request body for a personalized response.";

            log.LogWarning(nameMissingResponseMessage);

            return new OkObjectResult(nameMissingResponseMessage);
        }
    }
}
