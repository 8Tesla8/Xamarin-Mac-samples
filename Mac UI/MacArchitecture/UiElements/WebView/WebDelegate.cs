using System;
using WebKit;

namespace MacArchitecture.UiElements.WebView {

    //work with webView
    //webView.LoadRequest(new NSUrlRequest(
        //new NSUrl("https://developer.xamarin.com/guides/mac/user-interface/working-with-menus/")));

    public class WebDelegate : WKNavigationDelegate {

        public override void DecidePolicy(WKWebView webView, WKNavigationAction navigationAction,
                                          Action<WKNavigationActionPolicy> decisionHandler) {
            decisionHandler.Invoke(WKNavigationActionPolicy.Allow);
        }

        public override void DecidePolicy(WKWebView webView, WKNavigationResponse navigationResponse,
                                          Action<WKNavigationResponsePolicy> decisionHandler) {
            decisionHandler.Invoke(WKNavigationResponsePolicy.Allow);
        }


        public override void DidStartProvisionalNavigation(WKWebView webView, WKNavigation navigation){
            //start
        }


        public override void DidCommitNavigation(WKWebView webView, WKNavigation navigation) {
            //get html 
        }


        public override void DidFinishNavigation(WKWebView webView, WKNavigation navigation){
            //finish
        }


        public override void DidReceiveServerRedirectForProvisionalNavigation(WKWebView webView, WKNavigation navigation){
            //redirect
        }
    }
}
