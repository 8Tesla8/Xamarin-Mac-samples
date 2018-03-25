using System;
using Foundation;
using AppKit;
using MacArchitecture.UiElements.Helpers;
using System.Collections.Generic;
using MacArchitecture.UiElements.TextField;
using MacArchitecture.UiElements.Window;

namespace MacArchitecture {
    public partial class TextFieldViewController : NSViewController {
        public TextFieldViewController(IntPtr handle) : base(handle) {
            _defaultText = "NSTextField.StringValue binded to TfText property";
            _tfText = _defaultText;
        }

        private string _defaultText;
        private AlertWindow _alertWindow = new AlertWindow();
        private TextFieldViemModel _viewModel = new TextFieldViemModel();

        private InputValueController _inputController;
        [Export(nameof(InputController))]
        public InputValueController InputController {
            get { return _inputController; }
            set { SetField(ref _inputController, value, nameof(InputController)); }
        }


        private string _tfText;
        [Export(nameof(TfText))]
        public string TfText {
            get { return _tfText; }
            set {
                if (string.IsNullOrEmpty(value))
                    value = _defaultText;
   
                SetField(ref _tfText, value, nameof(TfText)); 
            }
        }


        public override void ViewDidLoad() {
            base.ViewDidLoad();

            #region InputValueController

            lbl_inputController.StringValue =
@"Min, Max and Number are binded to InputValueController fields. InputValueController can change " +
@"increment field in NSSteper. Min, Max and Increment can be changed dinamicly, you can input " +
@"what you want but those NSTextFields accept only integer";

            InputController = new InputValueController(tf,
             (number) => _viewModel.MyProperty = number, () => _viewModel.MyProperty,
             0, 200, stp);

            InputController.Number = _viewModel.MyProperty;

            #endregion

            #region Formatter

            lbl_formatter.StringValue =
@"Min, Max and Increment NSTextFields accepts only integer. " +
@"NSNumberFormatter created programaticly";

            var numberFormatter = new NSNumberFormatter();
            numberFormatter.NumberStyle = NSNumberFormatterStyle.None;

            tf_min.Formatter = numberFormatter;
            tf_max.Formatter = numberFormatter;
            tf_increment.Formatter = numberFormatter;

            #endregion

            #region Delegate

            lbl_delegate.StringValue = 
@"For this NSTextFiled was created my own delegate, " +
@"change text or press Esc, Enter key and you will se how it work";

            var dlg = new TextFieldDelegate();
            dlg.PressedEscKey += (sender, e) =>
                _alertWindow.ShowAlert("Alert", "In NSTextField you pressed Esc key", "OK");

            dlg.PressedEnterKey += (sender, e) =>
                _alertWindow.ShowAlert("Alert", "In NSTextField you pressed Enter key", "OK");

            dlg.TextChanged += (sender, e) => {
                var textField = (NSTextField)sender;
                TfText = textField.StringValue;
            };


            tf_delegate.Delegate = dlg;

            #endregion

        }


        public override void ViewDidAppear() {
            base.ViewDidAppear();

            View.Window.Title = nameof(TextFieldViewController);
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
