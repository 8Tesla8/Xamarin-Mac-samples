using System;
using Foundation;
using AppKit;

namespace MacArchitecture {
    public partial class ExceptionViewController : NSViewController {
        public ExceptionViewController(IntPtr handle) : base(handle) {
        }


        public override void ViewDidLoad() {
            base.ViewDidLoad();

            //go to the ErrorCatcher

            btn_exception.Activated += (sender, e) => {
                throw new System.Exception("Test Exception");
            };

            btn_nsException.Activated += (sender, e) => {
                var d = new NSException("NSException", "Test NSException", null);
  
            };
        }

        public void Hand(IntPtr tt){}

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
