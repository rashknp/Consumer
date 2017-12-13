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

    public class PromotionFragment : Fragment,IBackButtonListener
    {
       

        public void OnBackPressed()
        {
            FragmentManager fm = FragmentManager;
            fm.PopBackStack();
          
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.fragment_promotion, container, false);
           
            return view;

        }
       
    }  
}