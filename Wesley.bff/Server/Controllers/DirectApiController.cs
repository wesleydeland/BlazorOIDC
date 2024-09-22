using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Wesley.bff.Server.Controllers;

[ValidateAntiForgeryToken]
[Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
[ApiController]
[Route("api/[controller]")]
public class DirectApiController : ControllerBase
{
    [HttpGet]
    public IEnumerable<string> Get() => new List<string> { $"{this.User?.Identity?.Name}", "more data", "loads of data" };
}
