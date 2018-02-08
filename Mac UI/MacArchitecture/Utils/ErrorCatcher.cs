using System;
using AppKit;
using Foundation;
using MacArchitecture.UiElements.Window;
using ObjCRuntime;

namespace MacArchitecture.Utils {
    public static class ErrorCatcher {

        public static event Action<string> ErrorAction;

        //in Main.cs run this function 
        public static void InitCathcer(){

            AppDomain.CurrentDomain.UnhandledException += ErrorCatcher.CurrentDomainUnhandledException;
            Runtime.MarshalManagedException += (object sender, MarshalManagedExceptionEventArgs args) =>
                ErrorCatcher.Error(args.Exception);
            Runtime.MarshalObjectiveCException += (object sender, MarshalObjectiveCExceptionEventArgs args) =>
                ErrorCatcher.Error(args.Exception);
        }


        public static void CurrentDomainUnhandledException(object sender, UnhandledExceptionEventArgs e) {
            Error(e.ExceptionObject as Exception);
        }


        public static void Error(NSException exception) {
            if (exception != null) 
                ErrorAction?.Invoke(exception.ToString());
        }


        public static void Error(Exception exception) {
            if (exception != null) 
                ErrorAction?.Invoke(exception.ToString());
        }
    }
}
