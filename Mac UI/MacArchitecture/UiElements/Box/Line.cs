using System;
using AppKit;
using CoreGraphics;

namespace MacArchitecture.UiElements.Box {
    public class Line {
        public Line() {
        }


        public NSView CreateLine() {
            var line = new NSBox();
            line.BoxType = NSBoxType.NSBoxSeparator;
            line.Frame = new CGRect(0.0, 20.0, 300.0, 0.0);

            return line;

            //add view to StackView
            //stackView.AddView(line, NSStackViewGravity.Top);
        }


    }
}
