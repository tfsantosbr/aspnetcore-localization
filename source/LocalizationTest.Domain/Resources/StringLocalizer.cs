using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace LocalizationTest.Domain.Resources
{
    public class StringLocalizer
    {
        private static IEnumerable<LocalizedString> _localizatedStrings;

        public static void LoadStrings(IEnumerable<LocalizedString> localizatedStrings)
        {
            _localizatedStrings = localizatedStrings;
        }

        public static LocalizedString GetString(string name)
        {
            var translation = _localizatedStrings.FirstOrDefault(x => x.Name == name)?.Value;

            return new LocalizedString(name, translation ?? name, translation != null);
        }

        public static LocalizedString GetString(string name, params object[] arguments)
        {
            var translation = _localizatedStrings.FirstOrDefault(x => x.Name == name)?.Value;

            if (translation != null)
            {
                translation = string.Format(translation, arguments);
            }

            return new LocalizedString(name, translation ?? name, translation != null);
        }
    }
}
