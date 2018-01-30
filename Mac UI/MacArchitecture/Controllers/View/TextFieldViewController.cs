using System;
using Foundation;
using AppKit;
using MacArchitecture.UiElements.Helpers;
using System.Collections.Generic;

namespace MacArchitecture {
    public partial class TextFieldViewController : NSViewController {
        public TextFieldViewController(IntPtr handle) : base(handle) {
        }

        private TextFieldViemModel _viewModel = new TextFieldViemModel();

        private InputValueController _inputController;
        [Export(nameof(InputController))]
        public InputValueController InputController {
            get { return _inputController; }
            set { SetField(ref _inputController, value, nameof(InputController)); }
        }

        public override void ViewDidLoad() {
            base.ViewDidLoad();

            #region InputValueController

            lbl_inputController.StringValue =
@"I used InputValueController and bind Max Min Number and increment in slider
min max and increment you can change dinamicly, you can input what you want but it takes only integer";

            InputController = new InputValueController(tf,
             (number) => _viewModel.MyProperty = number, () => _viewModel.MyProperty,
             0, 200, stp);

            InputController.Number = _viewModel.MyProperty;

            #endregion

            #region Formatter

            lbl_formatter.StringValue =
@"In Min, Max and Increment NSTextFields accepts only integer, 
NSNumberFormatter created programaticly";
            
            var numberFormatter = new NSNumberFormatter();
            numberFormatter.NumberStyle = NSNumberFormatterStyle.None;

            tf_min.Formatter = numberFormatter;
            tf_max.Formatter = numberFormatter;
            tf_increment.Formatter = numberFormatter;

            #endregion

            #region Delegate
            lbl_delegate.StringValue = "";

            #endregion

        }


        private void SetField<T>(ref T field, T value, string propertyName, Action<T> callback = null) {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return;

            WillChangeValue(propertyName);
            field = value;
            DidChangeValue(propertyName);

            callback?.Invoke(value);
        }
    }


    internal class TextFieldViemModel {

        private int _myProperty = 5;
        public int MyProperty {
            get { return _myProperty; }
            set {
                _myProperty = value;
                Console.WriteLine("MyProperty in ViewModel is changed, now it is - " + value);
            }
        }
    }
}
