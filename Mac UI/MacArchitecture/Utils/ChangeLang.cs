using System;
using Foundation;

namespace MacArchitecture.Utils {
    public class ChangeLang {
        public ChangeLang() {
        }

        public string GetLocalizedString(string key) {
            //you must have in resources folder ru 

            var path = NSBundle.MainBundle.PathForResource("ru", "lproj");
            var languageBundle = NSBundle.FromPath(path);

            return languageBundle.LocalizedString(key, string.Empty);
        }

    }
}
