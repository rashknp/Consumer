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
using Java.Lang;
using NavigationDrawerLayout.src.Activity;
using Xamarin.Facebook;
using Xamarin.Facebook.Login.Widget;

namespace NavigationDrawerLayout
{
    [Activity(Label = "Facebook")]
    class FacebookActivity:Activity, IFacebookCallback
    {
        private ICallbackManager mFBCallManager;
        private TextView TxtFirstName;
        private TextView TxtLastName;
        private TextView TxtName;
        private ProfilePictureView mprofile;
        LoginButton BtnFBLogin;
        private MyProfileTracker mprofileTracker;

        public void OnCancel()
        {
            throw new NotImplementedException();
        }

        public void OnError(FacebookException p0)
        {
            throw new NotImplementedException();
        }

        public void OnSuccess(Java.Lang.Object p0)
        {
            throw new NotImplementedException();
        }


        void mProfileTracker_mOnProfileChanged(object sender, OnProfileChangedEventArgs e)
        {
            if (e.mProfile != null)
            {
                try
                {
                    TxtFirstName.Text = e.mProfile.FirstName;
                    TxtLastName.Text = e.mProfile.LastName;
                   TxtName.Text = e.mProfile.Name;
                mprofile.ProfileId = e.mProfile.Id;
                }
                catch (Java.Lang.Exception ex) { }
            }
            else
            {
                TxtFirstName.Text = "First Name";
                TxtLastName.Text = "Last Name";
                TxtName.Text = "Name";
                mprofile.ProfileId = null;
            }
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Android.Content.Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            mFBCallManager.OnActivityResult(requestCode, (int)resultCode, data);
        }
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            FacebookSdk.SdkInitialize(this.ApplicationContext);
            mprofileTracker = new MyProfileTracker();
            mprofileTracker.mOnProfileChanged += mProfileTracker_mOnProfileChanged;
            mprofileTracker.StartTracking();

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.layoutFacebook);
           
            BtnFBLogin = FindViewById<LoginButton>(Resource.Id.fblogin);
            TxtFirstName = FindViewById<TextView>(Resource.Id.TxtFirstname);
            TxtLastName = FindViewById<TextView>(Resource.Id.TxtLastName);
            TxtName = FindViewById<TextView>(Resource.Id.TxtName);
            mprofile = FindViewById<ProfilePictureView>(Resource.Id.ImgPro);
            BtnFBLogin.SetReadPermissions(new List<string> {
        "user_friends",
        "public_profile"
    });
            mFBCallManager = CallbackManagerFactory.Create();
            BtnFBLogin.RegisterCallback(mFBCallManager, this);



        }

    }
}