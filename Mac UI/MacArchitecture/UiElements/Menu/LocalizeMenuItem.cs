using System;
using AppKit;
using Foundation;
using System.Collections.Generic;

namespace MacArchitecture.UiElements.Menu {

    internal class LocalizeInfo {
        public LocalizeInfo() {
            Key = string.Empty;
            MapKey = new List<LocalizeInfo>();
        }

        public string Key { get; set; }
        public List<LocalizeInfo> MapKey { get; set; } 
    }

    //использовать для главных элементов меню
    [Register(nameof(LocalizeMenuItem))]
    internal class LocalizeMenuItem : BaseMenuItem {
        public LocalizeMenuItem(IntPtr handle) : base(handle) {

        }

        public LocalizeInfo LocalizeInfo { get; private set; }

        //todo ntst
        public void LocalizeMenu() {
            LocalizeMenu(LocalizeInfo, Submenu.ItemArray());
        }
        public void LocalizeMenu(LocalizeInfo localizeInfo, NSMenuItem[] menu){ //сделать как карту 
            for (int i = 0; i < menu.Length; i++) {

                if (string.IsNullOrEmpty(menu[i].Title)) //separator
                    continue;
                
                //menu[i].Title = GetLocalizeString(localizeInfo.MapKey[i]);

                if (menu[i].HasSubmenu)
                    LocalizeMenu(localizeInfo.MapKey[i], menu[i].Submenu.ItemArray());
            }
        }


        //todo ntst
        public void CreateMapLocalizeKey(){           
            CreateMapLocalizeKey(LocalizeInfo, Submenu.ItemArray());
        }
        public void CreateMapLocalizeKey(LocalizeInfo localizeInfo, NSMenuItem[] menu){

            for (int i = 0; i < menu.Length; i++) {
                var key = string.Concat(localizeInfo.Key, "_", menu[i].Title.Replace(" ", ""));

                localizeInfo.MapKey.Add(new LocalizeInfo{
                    Key = key,                   
                });

                if(menu[i].HasSubmenu)
                    CreateMapLocalizeKey(localizeInfo.MapKey[i], menu[i].Submenu.ItemArray());   
            }
        }
    }
}
