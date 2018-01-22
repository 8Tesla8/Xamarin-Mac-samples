using System;
using System.Collections.Generic;
using Foundation;

namespace MacArchitecture.UiElements.Toolbar {
    [Register(nameof(StateToolbarItem))]
    internal class StateToolbarItem : BaseToolbarItem {
        public StateToolbarItem(IntPtr handle) : base(handle) {
            StateTooltips = new List<string>();
            StateTitles = new List<string>();
        }

        public List<string> StateTooltips { get; private set; }
        public List<string> StateTitles { get; private set; }

        public void SetState(bool state) {
            Enabled = state;

            if (state) {
                if (StateTitles.Count > 0)
                    Label = StateTitles[1];

                if (StateTooltips.Count > 0)
                    ToolTip = StateTooltips[1];
            }
            else {
                if (StateTitles.Count > 0)
                    Label = StateTitles[0];

                if (StateTooltips.Count > 0)
                    ToolTip = StateTooltips[0];
            }
        }

        public void SetStateTooltips(string tooltipWhenEnabled, string tooltipWhenDisabled) {
            StateTooltips.Clear();

            StateTooltips.Add(tooltipWhenDisabled);   //0
            StateTooltips.Add(tooltipWhenEnabled);    //1
        }
        public void SetStateTitles(string titleWhenEnabled, string titleWhenDisabled) {
            StateTitles.Clear();

            StateTitles.Add(titleWhenDisabled);  //0
            StateTitles.Add(titleWhenEnabled);   //1
        }
    }
}
