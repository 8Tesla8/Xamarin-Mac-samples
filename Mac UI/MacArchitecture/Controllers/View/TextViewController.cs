using System;
using Foundation;
using AppKit;

namespace MacArchitecture {
    public partial class TextViewController : NSViewController {
        public TextViewController(IntPtr handle) : base(handle) {
        }

        [Export(nameof(ReturnTrue))]
        public bool ReturnTrue => true;

        public override void ViewDidLoad() {
            base.ViewDidLoad();

            txtv_base.Value =
@"This TextView have only 3 MenuItem: Cut, Copy and Paste";
            
            var htmlText = "<br>This TextView accept Html text <br> <a href='https://www.google.com/'>Go to google</a>";
            txtv_html.SetHtmlString(htmlText);

            txtv_editable.Value = 
@"This TextView controll NSUndoManager (Cmd + Z), after type here you can press key Cmd+Z and do undo, 
but if you will press 'Clear undo' button NSUndoManager will be cleared and you can do Undo action.";

            btn_clear.Activated += (sender, e) => 
                txtv_editable.ClearUndoManager();

            btn_show.Activated += (sender, e) => {
                var actionSender = new NSMenuItem();
                var tag = ((long)NSTextFinderAction.ShowFindInterface);
                actionSender.Tag = (nint)tag;

                txtv_editable.PerformFindPanelAction(actionSender);
            };

            btn_hide.Activated += (sender, e) => {
                var actionSender = new NSMenuItem();
                var tag = ((long)NSTextFinderAction.HideFindInterface);
                actionSender.Tag = (nint)tag;

                txtv_editable.PerformFindPanelAction(actionSender);
            };
        }

        public override void ViewDidAppear() {
            base.ViewDidAppear();

            View.Window.Title = nameof(TextViewController);
        }
    }
}
