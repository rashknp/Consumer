using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Webkit;
using Android.Graphics;

namespace NavigationDrawerLayout.src.Fragments
{

    public class BitCashFragment : Fragment,IBackButtonListener
    {
        TextView textView;
        WebView wvAbout;

        public void OnBackPressed()
        {
            FragmentManager fm = FragmentManager;
            fm.PopBackStack();
          
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.fragment_bitCash, container, false);
            wvAbout = view.FindViewById<WebView>(Resource.Id.LocalWebView);
            wvAbout.SetWebViewClient(new WebViewClient());
          // wvAbout.SetBackgroundResource(Resource.Drawable.listbox);
            wvAbout.SetBackgroundColor(new Color(0x00000000));
            // wvAbout.Settings.SetTextSize(WebSettings.TextSize.Smallest);
            //wvAbout.Settings.DomStorageEnabled = true;
            //wvAbout.Settings.JavaScriptEnabled=true;
            //wvAbout.Settings.BuiltInZoomControls=false;
            wvAbout.Settings.SetTextSize(WebSettings.TextSize.Normal);
            //wvAbout.Settings.SetLayoutAlgorithm(WebSettings.LayoutAlgorithm.SingleColumn);
            wvAbout.LoadUrl("file:///android_asset/Bitcash.html");
            return view;

        }
       
    }  
}  