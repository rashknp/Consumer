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
using Android.Views.Animations;
using Java.Lang;

namespace NavigationDrawerLayout.src.Fragments
{

    public class SocialMediaFragment : Fragment,IBackButtonListener
    {
        TextView btnTwiter, btnFacebook, btnInstagram;
        private MainActivity mainActivity;

        public SocialMediaFragment(MainActivity mainActivity)
        {
            this.mainActivity = mainActivity;
        }

       
        public void OnBackPressed()
        {
            FragmentManager fm = FragmentManager;
            fm.PopBackStack();
          
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.fragment_social_media, container, false);
            Animation animation1 = AnimationUtils.LoadAnimation(mainActivity, Resource.Animation.slide_in_left);
            Animation animation2 = AnimationUtils.LoadAnimation(mainActivity, Resource.Animation.slide_in_right);
            Animation animation3 = AnimationUtils.LoadAnimation(mainActivity, Resource.Animation.slide_in_bottomtwo);
            btnFacebook = view.FindViewById<TextView>(Resource.Id.btnFacebook);
            btnTwiter = view.FindViewById<TextView>(Resource.Id.btnTwiter);
            btnInstagram = view.FindViewById<TextView>(Resource.Id.btnInstaGram);

            btnFacebook.StartAnimation(animation1);
            btnTwiter.StartAnimation(animation2);
            btnInstagram.StartAnimation(animation3);

            return view;

        }
       
    }  
}