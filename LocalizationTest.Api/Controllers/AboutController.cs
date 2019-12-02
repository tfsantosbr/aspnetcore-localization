using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocalizationTest.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace LocalizationTest.Api.Controllers
{
    [Route("about")]
    public class AboutController : Controller
    {
        private readonly IStringLocalizer<ApiResources> _apiLocalizer;
        private readonly IStringLocalizer<DomainResources> _domainLocalizer;

        public AboutController(IStringLocalizer<ApiResources> apiLocalizer, IStringLocalizer<DomainResources> domainLocalizer)
        {
            _apiLocalizer = apiLocalizer;
            _domainLocalizer = domainLocalizer;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                Api = _apiLocalizer["Welcome"],
                Domain = _domainLocalizer.GetString("Username")
            });
        }
    }
}
