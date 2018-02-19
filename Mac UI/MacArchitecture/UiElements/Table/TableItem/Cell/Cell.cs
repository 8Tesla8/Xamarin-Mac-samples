using System;
using MacArchitecture.UiElements.Table.TableRow;
using MacArchitecture.UiElements.Table.ViewFactory;

namespace MacArchitecture.UiElements.Table.TableItem.Cell {
    public class TextFieldCell : ITextFieldCell {
        public TextFieldCell() {
            TypeCell = TypeCell.TextField;
        }

        public bool Selectable { get; set; }
        public bool Editable { get; set; }

        public TypeCell TypeCell { get; set; }

        public string Text { get; set; }
        public string Tooltip { get; set; }
    }


    public class TextViewCell : ITextViewCell {
        public TextViewCell() {
            TypeCell = TypeCell.TextView;
        }

        public bool Selectable { get; set; }
        public bool Editable { get; set; }

        public TypeCell TypeCell { get; set; }

        public string Text { get; set; }
        public string Tooltip { get; set; }
    }


    public class ButtonCell : IButtonCell {
        public ButtonCell() {
            TypeCell = TypeCell.Button;
        }

        public bool Enabled { get; set; }
        public Action Activated { get; set; }
      
        public TypeCell TypeCell { get; set; }

        public string Text { get; set; }
        public string Tooltip { get; set; }
    }


    public class Checkbox : ICheckboxCell {
        public Checkbox() {
            TypeCell = TypeCell.Checkbox;
        }

        public bool? State { get; set; }
        public bool AllowMixedState { get; set; }
        public bool Enabled { get; set; }

        public Action Activated { get; set; }
        public Action<bool?> StateChanged { get; set; }

        public TypeCell TypeCell { get; set; }
       
        public string Text { get; set; }
        public string Tooltip { get; set; }
    }


    public class PopUpButtonCell : IPopUpButtonCell {
        public PopUpButtonCell() {
            TypeCell = TypeCell.PopUp;
        }

        public Action<int> SelectItem { get; set; }
        public string[] MenuTitles { get; set; }

        public bool Enabled { get; set; }
        public Action Activated { get; set; }

        public TypeCell TypeCell { get; set; }

        public string Text { get; set; }
        public string Tooltip { get; set; }
    }
}
