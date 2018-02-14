using System;
using AppKit;
using MacArchitecture.UiElements.Table.Ordinary;

namespace MacArchitecture.UiElements.Table.ViewFactory {
    public interface IViewFactory {

        NSView CreateView(ITableItem tableItem, string title);
    }

    public enum TypeCellView {
        Checkbox,
        TextField,
        TextView,

        //do not have
        //Button,
        //PopUp
    }
}
