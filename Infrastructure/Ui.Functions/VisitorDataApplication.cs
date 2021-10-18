using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PresentationModels.VisitorDataApplication;
using TableStorage;

namespace Ui.Functions
{
    public class VisitorDataApplication
    {
        private readonly IStorageVisitorData _storageVisitorData;

        public VisitorDataApplication(
            IStorageVisitorData storageVisitorData)
        {
            _storageVisitorData = storageVisitorData;
        }


        [FunctionName("VisitorDataApplication")]
        public async Task<IActionResult> Store(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "visitordata/navigatorproperties")] HttpRequest req,
            ILogger log)
        {
            log.LogTrace("VisitorDataApplication: post /api/visitordata/navigatorproperties");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var navigatorProps = JsonConvert.DeserializeObject<NavigatorProperties>(requestBody);
            await _storageVisitorData.Store(navigatorProps);

            return new OkResult();
        }
    }
}

