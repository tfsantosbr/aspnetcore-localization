using LocalizationTest.Domain;
using LocalizationTest.Domain.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace LocalizationTest.Api.Controllers
{
    [Route("about")]
    public class AboutController : Controller
    {
        private readonly IStringLocalizer<DomainResources> _domainLocalizer;

        public AboutController(IStringLocalizer<DomainResources> domainLocalizer)
        {
            _domainLocalizer = domainLocalizer;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(ResourceLocalizer.GetString("Username"));
        }
    }
}
