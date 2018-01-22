using System;
using Foundation;
using System.Collections.Generic;
using AppKit;

namespace MacArchitecture.UiElements.Button {
    [Register(nameof(StateButton))]
    internal class StateButton : BaseButton {
        public StateButton(IntPtr handle) : base(handle) {
            StateTooltips = new List<string>();
            StateTitles = new List<string>();
            StateImages = new List<string>();
        }

        public List<string> StateTooltips { get; private set; }
        public List<string> StateTitles { get; private set; }
        public List<string> StateImages { get; private set; }

        public void SetState(bool state) {
            Enabled = state;

            if (state) {
                if (StateTitles.Count > 0)
                    Title = StateTitles[1];

                if (StateTooltips.Count > 0)
                    ToolTip = StateTooltips[1];

                if (StateImages.Count > 0)
                    Image = new NSImage(StateImages[1]);
            }
            else {
                if (StateTitles.Count > 0) 
                    Title = StateTitles[0];

                if (StateTooltips.Count > 0) 
                    ToolTip = StateTooltips[0];             

                if (StateImages.Count > 0)
                    Image = new NSImage(StateImages[0]);
            }
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
        public void SetStateImages(string imageWhenDisabled, string imageWhenEnabled){
            StateImages.Clear();

            StateImages.Add(imageWhenDisabled);     //0
            StateImages.Add(imageWhenEnabled);      //1
        }
    }
}
