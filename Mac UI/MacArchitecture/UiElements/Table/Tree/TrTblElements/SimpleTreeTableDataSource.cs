using System;
using AppKit;
using System.Linq;
using System.Collections.Generic;
using MacArchitecture.UiElements.Table.Tree.TrTblItems;
using MacArchitecture.UiElements.Table.Tree.TrTblItems.OneColumn;

namespace MacArchitecture.UiElements.Table.Tree.TrTblElements {
    internal class SimpleTreeTableDataSource : BaseTreeTableDataSource<SimpleTreeTableItem> {

        private NSOutlineView _tbl;
        private List<SimpleTreeTableItem> _data;

        public SimpleTreeTableDataSource(NSOutlineView tbl) {
            _tbl = tbl;
            _data = new List<SimpleTreeTableItem>();
        }

        public override void ClearData() {
            _data = new List<SimpleTreeTableItem>();
            _tbl.ReloadData();
        }

        public override void SetData(ICollection<SimpleTreeTableItem> newData) {
            _data = newData.ToList();
            _tbl.ReloadData();
        }
        public override ICollection<SimpleTreeTableItem> GetData() {
            return _data;
        }

        public void SetDataAndExpandRows(ICollection<SimpleTreeTableItem> newData) {
            _data = newData.ToList();
            _tbl.ReloadData();

            //for (int i = 0; i < _tbl.RowCount; i++) {
            //    var treeTableItem = (SimpleTreeTableItem)_tbl.ItemAtRow(i);

            //    if (treeTableItem.NeedExpand)
            //        _tbl.ExpandItem(_tbl.ItemAtRow(i));
            //}
        }

        public override ITreeTableItem GetItem(nint childIndex) {
            return _data[(int)childIndex];
        }

        public override nint GetDataCount() {
            return _data.Count;
        }
    }
}

//todo work with SimpleDataSource
//#region Proxy
//            if (savedSettings.UseProxy) {
//                ProxyViewModel = Autofac.Injection.Resolve<ProxyScanSettingsViewModel>();
//                ProxyViewModel.Initialize(savedSettings.WebProxy);
//                var proxySetting = new SimpleTextFieldTreeTableItem() {
//					Title = Resources.Main_CrawlingInfo_TableItem_Proxy,
//					NeedExpand = true,
//				};
//proxySetting.Children = new List<ITreeTableItem>() {
//                    new SimpleTextFieldTreeTableItem() {
//	Title = string.Concat(
//		Resources.ScanSettings_Proxy_Label_Address,
//		": ",
//		ProxyViewModel.Address),
//                    },
//                    new SimpleTextFieldTreeTableItem() {
//	Title = string.Concat(
//		Resources.ScanSettings_Proxy_Label_Port,
//		": ",
//		ProxyViewModel.Port),
//                    },
//                    new SimpleTextFieldTreeTableItem() {
//	Title = string.Concat(
//		Resources.ScanSettings_Proxy_Label_Login,
//		": ",
//		ProxyViewModel.Login),
//                    },
//                };
//                dataAboutSetting.Add(proxySetting);
//            }
//            #endregion
//            var ds = new SimpleTreeTableDataSource(tbl_settingsInfo);
//tbl_settingsInfo.DataSource = ds;
//            tbl_settingsInfo.Delegate = new BaseTreeTableDelegate();
//ds.SetDataAndExpandRows(dataAboutSetting);


