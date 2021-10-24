using Microsoft.Extensions.Logging;
using PresentationModels.VisitorDataApplication;
using TableStorage;

namespace VisitorDataApplication;

public class VDApp : IVisitorDataApplication
{
    private readonly ILogger<VDApp> _logger;
    private readonly IStorageVisitorData _visitorData;

    public VDApp(
        ILogger<VDApp> logger,
        IStorageVisitorData visitorData)
    {
        _logger = logger;
        _visitorData    = visitorData;
    }

    public async Task<VisitorData> NewVisitorAsync(VisitorProperties visitorProperties)
    {

        if (await _visitorData.Store(visitorProperties))
        {
            return await _visitorData.QueryData(visitorProperties);
        }
        _logger.LogError("Store failed");
        throw new VisitorApplicationException("Store failed");
    }
}
