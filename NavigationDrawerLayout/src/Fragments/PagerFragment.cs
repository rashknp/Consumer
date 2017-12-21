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
    class PagerFragment : Fragment
    {
        int IDIMG { get; set; }

        public PagerFragment(int id)
        {
            IDIMG = id;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.demoFragment, container, false);
            ((ImageView)view.FindViewById(Resource.Id.imageview_card)).SetImageResource(IDIMG);
            return view;
        }
    }
}