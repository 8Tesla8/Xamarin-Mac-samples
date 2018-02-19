using System;
namespace MacArchitecture.UiElements {
    public class Convention {
        public Convention() {
        }


        /*
          
* CODE_RULES         
    старатся не делать больше 3-4 вложеностей в папки(если больше необходимо сделать легкую понятную иерархию), 
    не больше 3 вложеностей в условиях и в вызовах функций(спагети код), 
    не создавать папки, классы с похожими или созвучными названиями
    сначала делать условие для true а не false
    if(true) else if(false) а не if(!true) else if(!false)
    создать один return, создать его первым

    разрабока через тестирование TDD, позволяет экономить время на дальнейшей отладке и увидеть архитектурные ошибки, 
    простые методы которые легко тестировать и проверять все возможные варианты

    в классе делать по 2 отступа между методами, порядок методов сначала publid в алфавитном порядке потом private в алфавитном порядке 

suffixes
* UI
    BUTTONS
	    btn_        - button
	    btnR_       - radio button
	    btnI_       - image button
        btnP_       - pop up btn
        btnH_       - help button

    OTHER
	    bx_     - box
        cb_     - combo box
	    ln_     - line
	    tlb_    - toolbar item
	    stp_    - stepper
	    sgm_    - segment control
	    ckb_    - check box
	    sld_    - slider 
        prog_   - progress indicator

    TEXT_FIELD
        tf_         - text field
        sf_         - search field
	    lbl_        - label(tfl)

    MENU
	    mn_         - menu
	    mnI_        - menu item

    TABLE
	    tbl_        - tableView
	    tblT_       - outlineTableView(TreeTable)
	    tblL_       - sourceList like outlineTableView ???
	    tblS_       - tableView(SimpleTableView) ???

    OTHER VIEW 
	    cv_         - customView
	    tbv_        - tabView
        dp_         - dataPicker
	    txtv_       - textView
        scrv_       - scrollView
	    stcv_       - stackView
        splv_       - split view

VIEW ITEMS
    CONTROLLER
        wc_         - window controller  //cntrlV_
        vc_         - view controller    //cntrlWin_
        tc_         - tree controller    //cntrlTr_
	    ac_         - array controller   //cntrlAr_

    OTHER
        ds_         - data source 
        dlg_        - delegate 

* variables
    st_             - static variable
    vm_             - view model

* comments in code
    //todo
    //todo impl  //todo Implement   - создать реализацию
    //todo impr  //todo Improve     - улучшить код  
    //todo plt   //todo Platform    - зависимость от платформы которой не должно быть
    //todo rpl   //todo Replace     - заменить когда появятся ресурсы
    //todo win   //todo Windows     - реализовать в винде
    //todo tst   //todo Test        - тестовая реализация
    //todo ntst  //todo NeedTest    - нужно протестировать 
    //todo nn    //todo NotNeed

* snippet for comments
  //short 
    tst   
    impl    
    impr  
    rpl   
    nn    
    win

    td - //todo $name$

* my snippets (abbreviate)
    clsc   - obj-c class
    ctorc  - obj-c ctor
    propc  - obj-c property
    reg    - obj-c register class 
    act    - obj-c action 
    exp    - obj-c export  
    mtdc   - obj-c methot 

    regi   - #region
    end    - #endregion

    pr     - obj-c prop with SetField
    prg    - obj-c propg with SetField

    mtd    - public method
    mtdg   - private method
    cnct   - string.Concat();
    emp    - string.Empty;
    excp   - throw new Exception("name");
    excpni - throw new NotImplementedException("name");
*/

    }
}
