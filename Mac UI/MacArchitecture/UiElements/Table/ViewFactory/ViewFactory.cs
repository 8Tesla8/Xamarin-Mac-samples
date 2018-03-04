using System;
using AppKit;
using CoreGraphics;
using MacArchitecture.UiElements.Table.TableRow;

namespace MacArchitecture.UiElements.Table.ViewFactory {
    public class ViewFactory : IViewFactory {

        public NSView CreateView(ITableRow tableRow, string columnIdentifier) {

            var cellValue = tableRow.GetValue(columnIdentifier);

            var cell = tableRow.GetCell(columnIdentifier);


            if (!string.IsNullOrEmpty(cell.Text))
                cellValue.Text = cell.Text;
            if (!string.IsNullOrEmpty(cell.Tooltip))
                cellValue.Tooltip = cell.Tooltip;

            switch (cell.TypeCell) {

                case TypeCell.TextField:

                    var tfCell = (ITextFieldCell)cell;

                    var tf = new NSTextField();
                    tf.BackgroundColor = NSColor.Clear;
                    tf.LineBreakMode = NSLineBreakMode.TruncatingTail;
                    tf.Bordered = false;

                    tf.Editable = tfCell.Editable;
                    tf.Selectable = tfCell.Selectable;

                    tf.StringValue = cellValue.Text;
                    tf.ToolTip = cellValue.Tooltip;

                    return tf;

                case TypeCell.TextView:
                    var txtvCell = (ITextViewCell)cell;

                    var txtv = new NSTextView();

                    txtv.BackgroundColor = NSColor.Clear;

                    txtv.Editable = txtvCell.Editable;
                    txtv.Selectable = txtvCell.Selectable;

                    txtv.Value = cellValue.Text;
                    txtv.ToolTip = cellValue.Tooltip;

                    return txtv;

                case TypeCell.Button:
                    var btnCell = (IButtonCell)cell;

                    //var btn = NSButton.CreateButton(btnCell.Text, btnCell.Activated);
                   
                    var btnView = new NSButton(new CGRect(0, 0, 80, 16));
                    btnView.SetButtonType(NSButtonType.MomentaryPushIn);
                    btnView.BezelStyle = NSBezelStyle.Rounded;
                    btnView.Bordered = true;

                    btnView.Title = btnCell.Text;
                    btnView.ToolTip = btnCell.Tooltip;
                    btnView.Enabled = btnCell.Enabled;
                    btnView.Activated += (sender, e) => 
                        btnCell.Activated();
       
                    //btnView.Image = 

                    return btnView;

                case TypeCell.PopUp:
                    var btnPCell = (IPopUpButtonCell)cell;

                    //var btnP = NSPopUpButton.CreateButton(btnPCell.Text, btnPCell.Activated);

                    var btnPView = new NSPopUpButton(new CGRect(0, 0, 80, 16), true);
                    btnPView.SetButtonType(NSButtonType.MomentaryPushIn);
                    btnPView.BezelStyle = NSBezelStyle.Rounded;
                    btnPView.PullsDown = false;
                    btnPView.ToolTip = btnPCell.Tooltip;
                    btnPView.Enabled = btnPCell.Enabled;

                    btnPView.Menu.RemoveAllItems();

                    foreach (var title in btnPCell.MenuTitles) 
                        btnPView.AddItem(title);

                    btnPView.Activated += (sender, e) => {
                        btnPCell.IndexOfSelectedItem = (int)btnPView.IndexOfSelectedItem;

                        if (btnPCell.SelectItem != null)
                            btnPCell.SelectItem((int)btnPView.IndexOfSelectedItem);
                        else
                            btnPCell.Activated();
                    };

                    return btnPView;

                case TypeCell.Checkbox:
                    var ckbCell = (ICheckboxCell)cell;

                    var tblCellView = new NSTableCellView();

                    tblCellView.TextField = new NSTextField(new CGRect(20, 0, 400, 16));
                    //tblCellView.Identifier = CellIdentifier;
                    tblCellView.TextField.BackgroundColor = NSColor.Clear;
                    tblCellView.TextField.Bordered = false;

                    tblCellView.TextField.Editable = false;
                    tblCellView.TextField.Selectable = false;

                    tblCellView.TextField.StringValue = cellValue.Text;
                    tblCellView.TextField.ToolTip = cellValue.Tooltip;

                    tblCellView.AddSubview(tblCellView.TextField);

                    var checkBox = new NSButton(new CGRect(5, 0, 16, 16));
                    checkBox.SetButtonType(NSButtonType.Switch);
                    checkBox.Enabled = ckbCell.Enabled;

                    checkBox.AllowsMixedState = ckbCell.AllowMixedState;

                    if (ckbCell.State == null)
                        checkBox.State = NSCellStateValue.Mixed;
                    else if (ckbCell.State == true)
                        checkBox.State = NSCellStateValue.On;
                    else if (ckbCell.State == false)
                        checkBox.State = NSCellStateValue.Off;

                    checkBox.Enabled = ckbCell.Enabled;

                    checkBox.Activated += (sender, e) => {
                        var ckb = (NSButton)sender;
                        bool? state = null;

                        if (ckb.State == NSCellStateValue.Mixed)
                            state = null;
                        else if (ckb.State == NSCellStateValue.On)
                            state = true;
                        else if (ckb.State == NSCellStateValue.Off)
                            state = false;

                        ckbCell.State = state;

                        if (ckbCell.StateChanged != null)
                            ckbCell.StateChanged(state);
                        else
                            ckbCell.Activated();
                    };

                    tblCellView.AddSubview(checkBox);

                    return tblCellView;
            }


            throw new System.NotImplementedException("Do not have implementation");
        }
    }
}
