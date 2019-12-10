using Microsoft.Extensions.Localization;

namespace LocalizationTest.Domain
{
    public class DomainResources
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
