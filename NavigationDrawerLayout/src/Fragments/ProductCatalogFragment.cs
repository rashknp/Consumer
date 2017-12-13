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

namespace NavigationDrawerLayout.src.Fragments
{

    public class ProductCatalogFragment : Fragment,IBackButtonListener
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
            wvAbout.SetBackgroundResource(Resource.Drawable.listbox);
            wvAbout.LoadUrl("file:///android_asset/Bitcash.html");
            return view;

        }
       
    }  
}