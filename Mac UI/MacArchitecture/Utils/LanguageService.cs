using System;
using Foundation;

namespace MacArchitecture.Utils {
    public class LanguageService {
        public LanguageService() {
        }

        public string GetLocalizedString(string culture, string key) {
            //you must have culture resource folder 

            var path = NSBundle.MainBundle.PathForResource(culture, "lproj");
            var languageBundle = NSBundle.FromPath(path);

            return languageBundle.LocalizedString(key, string.Empty);
        }

    }
}
