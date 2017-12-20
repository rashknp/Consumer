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
using Android.Support.V4.Content;
using Android.Content.PM;

namespace NavigationDrawerLayout.src.Fragments
{
  
    public class ContactUsFragment:Fragment,IBackButtonListener  
    {
        TextView tvEmail, tvCallUs;
      
        public void OnBackPressed()
        {
            FragmentManager fm = FragmentManager;
            fm.PopBackStack();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
        base.OnCreateView(inflater, container, savedInstanceState);
        var view = inflater.Inflate(Resource.Layout.fragment_contact, container, false);
            tvEmail = view.FindViewById<TextView>(Resource.Id.tvEmail);
            tvCallUs = view.FindViewById<TextView>(Resource.Id.tvCallUs);

            tvEmail.Click += (o, e) =>
            {
                Intent sharingIntent = new Intent(Intent.ActionSend);
                sharingIntent.SetType("message/rfc822");
                sharingIntent.PutExtra(Intent.ExtraEmail, new String[] { "customersupport@masafi.com" });

                StartActivity(Intent.CreateChooser(sharingIntent, "Chose an Email client:"));


            };
            tvCallUs.Click += (o, e) =>
            {
              
                //int hasPermission = ContextCompat.CheckSelfPermission(AppContext, Android.Manifest.Permission.ReadPhoneState);
                //if (hasPermission == (int)Permission.Granted)
                //{
                    var uri = Android.Net.Uri.Parse("tel:600525256");
                    var intent = new Intent(Intent.ActionDial, uri);
                    StartActivity(intent);
                //}

            };
            return view;

    }
}  
}