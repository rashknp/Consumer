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
    [Activity(Label = "Terms2Fragment")]
    public class Terms2Fragment : Fragment, IBackButtonListener
    {
        MainActivity mainActivity;
        private String filePath = "http://www.masafi.com/corporate/contact-us";
        WebView wvAbout;
        private TextView tvCallUs, tvEmail;
        private int type = 0;
        public void OnBackPressed()
        {
            FragmentManager fm = FragmentManager;
            fm.PopBackStack();

        }
        public Terms2Fragment(MainActivity mainActivity,int pos)
        {
            this.mainActivity = mainActivity;
            this.type = pos;
        }


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.fragment_bitCash, container, false);
            //String myTag = getTag();
            //Bundle bundle = Arguments;
            //type = bundle.GetInt("position", 0);
            // type = Arguments.GetInt("position",0);
            //String value = mainActivity.ArgetString("YourKey");
           // type= mainActivity.Intent.GetIntExtra("position", 0);
            wvAbout = view.FindViewById<WebView>(Resource.Id.LocalWebView);
            wvAbout.SetWebViewClient(new WebViewClient());
            // wvAbout.SetBackgroundResource(Resource.Drawable.listbox);
            wvAbout.SetBackgroundColor(new Color(0x00000000));
            wvAbout.Settings.SetTextSize(WebSettings.TextSize.Normal);

            if (type == 0)
            {
              //  tvHeaderTitle.setText("Terms and Conditions");
              //  tvHeaderTitle.setTextSize(getResources().getDimension(Resource.Dimension.headersizelarge));
                filePath = "file:///android_asset/TermCondition.html";
            }
            else if (type == 1)
            {
              //  tvHeaderTitle.setText("Privacy Policy");
               // tvHeaderTitle.setTextSize(getResources().getDimension(Resource.Dimension.headersizelarge));
                filePath = "file:///android_asset/Privacy_Policy.html";
            }
            else if (type == 2)
            {
              //  tvHeaderTitle.setText("Disclaimers");
              //  tvHeaderTitle.setTextSize(getResources().getDimension(Resource.Dimension.headersizelarge));
                filePath = "file:///android_asset/Disclaimers.html";
            }
            else if (type == 3)
            {
               // tvHeaderTitle.setText("Refund & Cancellation Policy");
               // tvHeaderTitle.setTextSize(getResources().getDimension(Resource.Dimension.headersize));
                filePath = "file:///android_asset/Refund_And_Cancellation.html";
            }
            else if (type == 4)
            {
               // tvHeaderTitle.setText("Delivery Information");
               // tvHeaderTitle.setTextSize(getResources().getDimension(Resource.Dimension.headersizelarge));
                filePath = "file:///android_asset/DeliveryPolicy.html";
            }
            wvAbout.LoadUrl(filePath);
            return view;

        }

    }
}