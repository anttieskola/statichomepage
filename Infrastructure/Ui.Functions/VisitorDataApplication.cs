using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Ui.Functions
{
    public static class VisitorDataApplication
    {
        [FunctionName("VisitorDataApplication")]
        public static async Task<IActionResult> Store(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "/api/visitordata/store")] HttpRequest req,
            ILogger log)
        {
            log.LogTrace("VisitorDataApplication: /api/visitordata/store");

            
            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }
    }
}

