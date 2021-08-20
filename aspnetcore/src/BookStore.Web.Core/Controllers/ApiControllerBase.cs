using Microsoft.AspNetCore.Mvc;

namespace BookStore.Web.Core.Controllers
{
    /// <summary>
    /// Base API controller for all API controllers.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiControllerBase : ControllerBase
    {
    }
}
