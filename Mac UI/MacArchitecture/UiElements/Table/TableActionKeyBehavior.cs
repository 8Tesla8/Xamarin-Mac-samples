using System;
namespace MacArchitecture.UiElements.Table {
    [Flags]
    internal enum TableActionKeyBehavior {
        None = 0,
        Ecs = 1,
        Enter = 2,
        Space = 4,
        //???
        //CmdC = 8,
        //CmdV = 16,
    }
}
