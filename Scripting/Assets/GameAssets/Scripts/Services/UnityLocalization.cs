using UnityEngine.Localization.Settings;

namespace Scripting
{
    public class UnityLocalization : ILocalization
    {
        public string Translate(string key, params object[] args)
        {
            string localizedString =
                LocalizationSettings.StringDatabase.GetLocalizedString(LocalizationSettings.StringDatabase.DefaultTable,
                    key, args);

            return localizedString;
        }
    }
}