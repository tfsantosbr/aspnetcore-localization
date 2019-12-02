using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocalizationTest.Domain;
using LocalizationTest.Domain.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

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
            return Ok(StringLocalizer.GetString("Username"));
        }
    }
}
