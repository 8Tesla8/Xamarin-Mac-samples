using System;
using Foundation;
using AppKit;
using MacArchitecture.Utils;

namespace MacArchitecture {
    public partial class ExceptionViewController : NSViewController {
        public ExceptionViewController(IntPtr handle) : base(handle) {
        }


        public override void ViewDidLoad() {
            base.ViewDidLoad();

            //in your app you should run this func in  Main.cs
            ErrorCatcher.InitCathcer();

            ErrorCatcher.ErrorAction += (error) => {
                var alert = new NSAlert() {
                    MessageText = "Exception",
                    InformativeText = error,
                    AlertStyle = NSAlertStyle.Critical,
                };

                alert.RunModal();
            };

            btn_exception.Activated += (sender, e) => {
                throw new System.Exception("Test Exception");
            };

            btn_nsException.Activated += (sender, e) => {
                var d = new NSException("NSException", "Test NSException", null);
  
            };
        }


        public override void ViewDidAppear() {
            base.ViewDidAppear();

            View.Window.Title = nameof(ExceptionViewController);
        }

//https://developer.xamarin.com/guides/ios/advanced_topics/exception_marshaling/
//catch (Foundation.NSErrorException)
//{
////works
//System.Diagnostics.Debug.WriteLine("Caught ns Error exception");
//}
//    } catch (MonoTouchException ex) {
//thrownException = ex;
//}
    }
}
