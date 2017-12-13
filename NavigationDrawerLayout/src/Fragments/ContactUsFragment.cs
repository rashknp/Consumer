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

namespace NavigationDrawerLayout.src.Fragments
{
  
    public class ContactUsFragment:Fragment,IBackButtonListener  
    {
        TextView textView;
        IBackButtonListener local;

        public void OnBackPressed()
        {
          
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
        base.OnCreateView(inflater, container, savedInstanceState);
        var view = inflater.Inflate(Resource.Layout.fragment_contact, container, false);
          //textView = view.FindViewById<TextView>(Resource.Id.textView1);
           // textView.Text = "Fragment2";
            //textView.Click += (o, e) => {

            //    FragmentTransaction transcation1 = FragmentManager.BeginTransaction();
            //    src.Fragments.Fragment2 fragment2 = new src.Fragments.Fragment2();
            //    transcation1.Replace(Resource.Id.container, fragment2);
            //    transcation1.Commit();

            //};
            return view;

    }
}  
}