using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Felipecsl.GifImageViewLibrary;

namespace NavigationDrawerLayout
{
    [Activity(Label = "Home", ScreenOrientation = ScreenOrientation.Portrait)]
    class Home :Activity, GifImageView.IOnFrameAvailableListener
    {
        GifImageView gifImageView;

        public Bitmap OnFrameAvailable(Bitmap bitmap)
        {
             GC.Collect();
            return bitmap;
        }

        protected override async  void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.home);
          TextView  textView = FindViewById<TextView>(Resource.Id.text);
            gifImageView = FindViewById<GifImageView>(Resource.Id.gifImageView);
            textView.Click += (o, e) => {
                //try
                //{
                //    ActionBar.Title = "Error downloading";
                //    using (var client = new HttpClient())
                //    {
                //        var bytes = await client.GetByteArrayAsync("http://dogoverflow.com/dRX5G8qK");
                //        gifImageView.SetBytes(bytes);
                //        gifImageView.StartAnimation();
                //    }
                //}
                //catch (Exception ex)
                //{
                //    ActionBar.Title = "Error downloading";
                //}
                var intent = new Intent(this, typeof(Friends));
                StartActivity(intent);
            };



        }
        }
    }