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
using NavigationDrawerLayout.src.Adapter;

namespace NavigationDrawerLayout.src.Fragments
{

    public class TermsFragment : Fragment,IBackButtonListener
    {
         MainActivity mainActivity;
        BaseAdapter adapter;
        String[] web = {
            "Terms and Conditions",
            "Privacy Policy",
            "Disclaimers",
            "Refund & Cancellation Policy",
            "Delivery Information",
    };
        ListView list;
        public void OnBackPressed()
        {
            FragmentManager fm = FragmentManager;
            fm.PopBackStack();
          
        }
        public TermsFragment(MainActivity mainActivity)
        {
            this.mainActivity = mainActivity;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.fragment_terms, container, false);
            list = view.FindViewById<ListView>(Resource.Id.lvCustomList);
            var termsConditonAdapter = new TermsConditionAdapter(mainActivity,web);
            list.Adapter = termsConditonAdapter;
            // adapter = new TermsConditonAdapter(this, web);
            // list.SetAdapter(adapter);
            list.ItemClick += (o, e) =>
            {

                FragmentTransaction transcation1 = FragmentManager.BeginTransaction();
                src.Fragments.Terms2Fragment promotionFragment = new src.Fragments.Terms2Fragment(mainActivity,e.Position);
                transcation1.Replace(Resource.Id.container, promotionFragment, "Terms2");
                transcation1.AddToBackStack("Terms2");
                Bundle bundle = new Bundle();
                bundle.PutInt("position", e.Position);
                transcation1.Commit();
            };
            return view;

        }
       
    }  
}