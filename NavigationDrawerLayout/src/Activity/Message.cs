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
using ZXing.Mobile;
using Android.Content.PM;
using ZXing;

namespace NavigationDrawerLayout
{
    [Activity(Label = "Home")]
    class Message : Activity
    {
        MobileBarcodeScanner scanner;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            MobileBarcodeScanner.Initialize(Application);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.home);
            TextView textView = FindViewById<TextView>(Resource.Id.text);
            textView.Text = "Message";
            scanner = new MobileBarcodeScanner();
            textView.Click += (o, e) =>
            {
                scanner.UseCustomOverlay = false;

                //We can customize the top and bottom text of the default overlay
                scanner.TopText = "Hold the camera up to the barcode\nAbout 6 inches away";
                scanner.BottomText = "Wait for the barcode to automatically scan!";

                var opt = new MobileBarcodeScanningOptions();
                opt.DelayBetweenContinuousScans = 3000;

                //Start scanning
                scanner.ScanContinuously(opt, HandleScanResult);

              //  var intent = new Intent(this, typeof(BarCodeScanner));
                //intent.AddFlags(ActivityFlags.ClearTop);
                //intent.AddFlags(ActivityFlags.ClearTask);
                //intent.AddFlags(ActivityFlags.NewTask);
              //  StartActivity(intent);
                //Finish();
            };
        }

        void HandleScanResult(ZXing.Result result)
        {
            string msg = "";

            if (result != null && !string.IsNullOrEmpty(result.Text))
                msg = "Found Barcode: " + result.Text;
            else
                msg = "Scanning Canceled!";

            this.RunOnUiThread(() => Toast.MakeText(this, msg, ToastLength.Long).Show());
           
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        [Java.Interop.Export("UITestBackdoorScan")]
        public Java.Lang.String UITestBackdoorScan(string param)
        {
            var expectedFormat = BarcodeFormat.QR_CODE;
            Enum.TryParse(param, out expectedFormat);
            var opts = new MobileBarcodeScanningOptions
            {
                PossibleFormats = new List<BarcodeFormat> { expectedFormat }
            };
            var barcodeScanner = new MobileBarcodeScanner();

            Console.WriteLine("Scanning " + expectedFormat);

            //Start scanning
            barcodeScanner.Scan(opts).ContinueWith(t => {

                var result = t.Result;

                var format = result?.BarcodeFormat.ToString() ?? string.Empty;
                var value = result?.Text ?? string.Empty;

                RunOnUiThread(() => {

                    AlertDialog dialog = null;
                    dialog = new AlertDialog.Builder(this)
                                    .SetTitle("Barcode Result")
                                    .SetMessage(format + "|" + value)
                                    .SetNeutralButton("OK", (sender, e) => {
                                        dialog.Cancel();
                                    }).Create();
                    dialog.Show();
                });
            });

            return new Java.Lang.String();
        }
    }
}

