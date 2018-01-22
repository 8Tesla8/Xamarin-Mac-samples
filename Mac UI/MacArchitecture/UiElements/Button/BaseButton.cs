using System;
using AppKit;

namespace MacArchitecture.UiElements.Button {
    abstract internal class BaseButton : NSButton {
        public BaseButton(IntPtr handle) : base(handle)  { }

        //этот класс создан для создание общей логики которую будет подерживать все классы наследники
    }
}
