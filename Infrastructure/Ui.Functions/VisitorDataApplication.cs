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
            // TODO
            return new OkResult();
        }
    }
}

