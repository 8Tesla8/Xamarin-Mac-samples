using System;
using AppKit;
using Foundation;

namespace MacArchitecture.UiElements.Helpers {
    //in X-code Steper and Slider need to bind to Max, Min and Number values  
    //TextField and Slider must be added in ViewController

    public class InputValueController : BindingObject {
        private readonly NSTextField _tf;
        private readonly NSStepper _stp;

        private readonly Action<int> _setValue;
        private readonly Func<int> _getValue;

        public InputValueController(NSTextField tf,
                                    Action<int> setValue,
                                    Func<int> getValue,
                                    int min, int max,
                                    NSStepper stp = null,
                                    double increment = 1) {
            _tf = tf;

            _setValue = setValue;
            _getValue = getValue;

            Min = min;
            Max = max;

            _tf.Changed += (sender, e) => {
                if (int.TryParse(_tf.StringValue, out int number)) {
                    if (number >= Min && number <= Max)
                        Number = number;
                }
            };


            if (stp != null)
                _stp = stp;

            Increment = increment;
        }

        private double _increment;
        [Export(nameof(Increment))]
        public double Increment {
            get { return _increment; }
            set {
                SetField(ref _increment, value, nameof(Increment));
                //_increment = value;
                if (_stp != null) {
                    _stp.Increment = value;
                    _stp.ToolTip += string.Concat("+/- ", value.ToString());
                }
            }
        }

        private int _max;
        [Export(nameof(Max))]
        public int Max {
            get { return _max; }
            set { SetField(ref _max, value, nameof(Max)); }
        }

        private int _min;
        [Export(nameof(Min))]
        public int Min {
            get { return _min; }
            set { SetField(ref _min, value, nameof(Min)); }
        }

        [Export(nameof(Number))]
        public int Number {
            get { return _getValue(); }
            set {
                WillChangeValue(nameof(Number));
                _setValue(value);
                DidChangeValue(nameof(Number));

                _tf.StringValue = value.ToString();
            }
        }
    }
}
