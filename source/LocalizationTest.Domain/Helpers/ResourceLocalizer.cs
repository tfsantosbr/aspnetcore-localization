using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace LocalizationTest.Domain.Helpers
{
    public class ResourceLocalizer
    {
        private static IStringLocalizer<DomainResources> _localizer;

        public static void SetLocalizer(IStringLocalizer<DomainResources> localizer)
        {
            _localizer = localizer;
        }

        public static LocalizedString GetString(string name) => 
            _localizer.GetString(name);

        public static LocalizedString GetString(string name, params object[] arguments) =>
            _localizer.GetString(name, arguments);
    }
}
