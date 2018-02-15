using System;
using MacArchitecture.UiElements.Table.ViewFactory;

namespace MacArchitecture.UiElements.Table.TableRow {
    public interface ICell {
        TypeCell TypeCell { get; set; }

        string Text { get; set; }
        string Tooltip { get; set; }
    }


    public interface ITextFieldCell : ICell {
        bool Selectable { get; set; }
        bool Editable { get; set; }
    }


    public interface ITextViewCell : ITextFieldCell{
        
    }


    public interface IButtonCell : ICell{
        bool Enabled { get; set; }
        Action Activated { get; set; }
    }


    public interface ICheckBoxButtonCell : IButtonCell{
        bool? State { get; set; } 
        bool AllowMixedState { get; set; }
        Action<bool?> StateChanged { get; set; }
    }


    public interface IPopUpButtonCell : ICell{
        Action<int> SelectItem { get; set; }
        string[] MenuTitles { get; set; }
    }
}
