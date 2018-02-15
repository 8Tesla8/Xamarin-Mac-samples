using System;
using AppKit;
using MacArchitecture.UiElements.Table.TableRow;

namespace MacArchitecture.UiElements.Table.ViewFactory {
    public interface IViewFactory {
        NSView CreateView(ITableRow tableItem, string title);
    }


    public enum TypeCell {
        TextField,
        TextView,

        Button,
        Checkbox,
        PopUp
    }
}

  

