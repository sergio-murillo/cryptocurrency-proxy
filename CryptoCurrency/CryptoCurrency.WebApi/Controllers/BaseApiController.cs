using Microsoft.AspNetCore.Mvc;

namespace CryptoCurrency.WebApi.Controllers
{
    /// <summary>
    /// Base controller class
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class BaseApiController : ControllerBase
    {

    }
}