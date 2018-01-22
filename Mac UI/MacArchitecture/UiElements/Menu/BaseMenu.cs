using System;
using AppKit;
using Foundation;

namespace MacArchitecture.UiElements.Menu  {
    //todo ipv
    //cоздать поля для улучшения локализации(feild localizeKey)
    //создать метод который будет локализовывать все меню

    internal abstract class BaseMenuItem : NSMenuItem {
        public BaseMenuItem(IntPtr handle) : base(handle) {

        }
    }
}

