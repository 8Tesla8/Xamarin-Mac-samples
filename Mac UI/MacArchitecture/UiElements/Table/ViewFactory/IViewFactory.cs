using System;
using AppKit;
using MacArchitecture.UiElements.Table.TableRow;

namespace MacArchitecture.UiElements.Table.ViewFactory {
    public interface IViewFactory {
        NSView CreateView(ITableRow tableItem, string title);
    }


    public enum TypeCell {
        TextField = 0,
        TextView = 1,

        Button = 2,
        Checkbox = 3,
        PopUp = 4,
    }
}



