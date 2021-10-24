using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using PresentationModels.VisitorDataApplication;
using VisitorDataApplication;

namespace Ui.Functions
{
    public class VisitorDataApi
    {
        private IVisitorDataApplication _app;

        public VisitorDataApi(IVisitorDataApplication app)
        {
            _app = app;
        }

        [FunctionName("whoami")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "visitordata/whoami")] HttpRequest req,
            ILogger log)
        {
            log.LogTrace("VisitorDataApplication: get visitordata/whoami");

            var connectionInfo = req.HttpContext.Connection;

            var visitorProperties = new VisitorProperties(
                connectionInfo.Id,
                connectionInfo.RemoteIpAddress.ToString(),
                connectionInfo.RemotePort);

            var visitor = await _app.NewVisitorAsync(visitorProperties);
            return new OkObjectResult(visitor);
        }


        //[FunctionName("navigatorproperties")]
        //public async Task<IActionResult> Store(
        //    [HttpTrigger(AuthorizationLevel.Function, "post", Route = "visitordata/navigatorproperties")] HttpRequest req,
        //    ILogger log)
        //{
        //    log.LogTrace("VisitorDataApplication: post /api/visitordata/navigatorproperties");

        //    string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        //    var navigatorProps = JsonConvert.DeserializeObject<NavigatorProperties>(requestBody);
        //    await _storageVisitorData.Store(navigatorProps);

        //    return new OkResult();
        //}
    }
}

