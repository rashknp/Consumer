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

namespace NavigationDrawerLayout
{
    [Activity(Label = "Home")]
    class Friends : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.home);
            TextView textView = FindViewById<TextView>(Resource.Id.text);
            textView.Text="Friends";
            textView.Click += (o, e) => {

                var intent = new Intent(this, typeof(Message));
                StartActivity(intent);
            };
        }
    }
}