using Microsoft.Extensions.Caching.Hybrid;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Wesley.bff.Server.Controllers;

[ValidateAntiForgeryToken]
[Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
[ApiController]
[Route("api/[controller]")]
public class DirectApiController : ControllerBase
{
    private readonly HybridCache _cache;

    public DirectApiController(HybridCache cache)
    {
        _cache = cache;
    }
    [HttpGet]
    public async Task<IEnumerable<string>> Get(CancellationToken token = default)
    {
        return await _cache.GetOrCreateAsync(
            key: $"{this.User?.Identity?.Name}-{DateTimeOffset.UtcNow.ToString("yyyy-MM-dd")}",
            async ct => await GetData(),
            cancellationToken: token);
        
    }

    private async Task<IEnumerable<string>> GetData()
    {
        
        var result = new List<string> { $"{this.User?.Identity?.Name}", "more data", "loads of data" };
        Thread.Sleep(10000);
        return result;
    }
}
