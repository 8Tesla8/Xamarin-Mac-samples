using System;
using Foundation;
using System.Collections.Generic;
using AppKit;

namespace MacArchitecture.UiElements.Button {
    [Register(nameof(StateButton))]
    internal class StateButton : BaseButton {
        public StateButton(IntPtr handle) : base(handle) {
            StateTitles = new List<string>();
            StateImages = new List<string>();
            StateTooltips = new List<string>();
        }

        public List<string> StateTooltips { get; private set; }
        public List<string> StateTitles { get; private set; }
        public List<string> StateImages { get; private set; }

        private bool _btnState;
        public bool BtnState {
            get {
                return _btnState;
            }
            set {
                _btnState = value;
                SetState(value);
            }
        }


        public void SetState(bool state) {
            _btnState = state;

            var index = 0;

            if (state)
                index = 1;

            if (StateTitles.Count > 0)
                Title = StateTitles[index];

            if (StateTooltips.Count > 0)
                ToolTip = StateTooltips[index];

            if (StateImages.Count > 0)
                Image = NSImage.ImageNamed(StateImages[index]);
        }


        public void SetStateTooltips(string tooltipWhenDisabled, string tooltipWhenEnabled) {
            StateTooltips.Clear();

            StateTooltips.Add(tooltipWhenDisabled);   //0
            StateTooltips.Add(tooltipWhenEnabled);    //1
        }


        public void SetStateTitles(string titleWhenDisabled, string titleWhenEnabled) {
            StateTitles.Clear();

            StateTitles.Add(titleWhenDisabled);  //0
            StateTitles.Add(titleWhenEnabled);   //1
        }


        public void SetStateImages(string imageWhenDisabled, string imageWhenEnabled) {
            StateImages.Clear();

            StateImages.Add(imageWhenDisabled);     //0
            StateImages.Add(imageWhenEnabled);      //1
        }
    }
}
