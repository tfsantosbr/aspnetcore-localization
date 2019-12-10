using LocalizationTest.Domain;
using Microsoft.AspNetCore.Mvc;

namespace LocalizationTest.Api.Controllers
{
    [Route("about")]
    public class AboutController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(DomainResources.GetString("Username"));
        }
    }
}
