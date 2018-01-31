using System;
namespace MacArchitecture.UiElements {
    public class Notice {
        public Notice() {
        }

        //todo tst
        //how to make my xamarin Mac application open on my primary Monitor
        //https://forums.xamarin.com/discussion/106548/how-to-make-my-xamarin-mac-application-open-on-my-primary-monitor#latest



        //todo ipv +++
        //создать UML диаграмму классов чтобы оценить ситуацию глобально
        //изменить название папки Utils на что-то более подходящие

        //mac system images
        //http://hetima.github.io/fucking_nsimage_syntax/

        /*  
        snippets
        https://alexdunn.org/2017/05/25/xamarin-tip-mvvmlight-code-snippets-for-visual-studio-for-mac/

        in studio
            prop
            propg 
            for
            forr
            //with selected
            ctor
            region
            cw - Console.WriteLine( $selected$ );
            if
            else
            switch
            lock
            itar - foreach
            itarr

        obj-c constructor
        ctorc
        $modifier$$classname$ (IntPtr handle) : base(handle)    
        {
            $end$
        }

        obj-c prop
        propc
        private $type$ _$name1$;
        [Export(nameof($name$))]
        public $type$ $name$  {
            get { return _$name1$; }
            set { 
                WillChangeValue(nameof($name$));
                _$name1$ = value;
                DidChangeValue(nameof($name$));
            }
        }

        register my class in obj-c
        reg
        [Register (nameof($classname$))] 
        //write inside class

        create class with registration in obj-c
        clsc        
        [Register (nameof($name$))]
        internal class $name$ : $type$
        {
            public $name$ (IntPtr handle) : base(handle)
            {
                
            }
            $selected$$end$
        }

        method
        mtdc
        [Action($name1$ ":")]
        public void $name$(NSObject sender){
        }

        pmtd
        public $type$ $name$(){

        }   

        prmtd
        public $type$ $name$(){

        }

        emp
        string.Empty;
        */
    }
}
