using System;
using AppKit;
using CoreGraphics;
using MacArchitecture.UiElements.Table.TableRow;

namespace MacArchitecture.UiElements.Table.ViewFactory {
    public class ViewFactory : IViewFactory {

        public NSView CreateView(ITableRow tableRow, string columnIdentifier) {

            var cellValue = tableRow.GetValue(columnIdentifier);

            var cell = tableRow.GetCell(columnIdentifier);


            if(!string.IsNullOrEmpty(cell.Text))
                cellValue.Text = cell.Text;
            if(string.IsNullOrEmpty(cell.Tooltip))
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
                    //todo impl 
                    //look at xamarin how make button
                    throw new System.NotImplementedException("name");

                case TypeCell.PopUp:
                    //todo impl
                    throw new System.NotImplementedException("name");


                case TypeCell.Checkbox:
                    var ckbCell = (ICheckBoxButtonCell)cell;

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

                    checkBox.AllowsMixedState = ckbCell.AllowMixedState;

                    if (ckbCell.State == null)
                        checkBox.State = NSCellStateValue.Mixed;
                    else if (ckbCell.State == true) 
                        checkBox.State = NSCellStateValue.On;
                    else if(ckbCell.State == false)
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

                        ckbCell.StateChanged(state);
                    };

                    tblCellView.AddSubview(checkBox);

                    return tblCellView;

           
            }


            throw new System.NotImplementedException("Do not have implementation");
        }
    }
}
