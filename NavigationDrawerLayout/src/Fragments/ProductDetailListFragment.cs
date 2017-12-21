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
using Android.Support.V7.Widget;
using NavigationDrawerLayout.src.Activity;
using NavigationDrawerLayout.src.Interface;

namespace NavigationDrawerLayout.src.Fragments
{
   
    public class ProductDetailListFragment : Fragment,IBackButtonListener,RowClick
    {
        private RecyclerView mRecyclerView;
        RowClick rowClick;
        RecyclerView.LayoutManager mLayoutManager;
        ProductListAdapter adapter;
        Boolean clicked;
        String[] imgArray = {
               "http://blase.masafi.com/360/Data/ConsumerImage/3.png",
               "http://blase.masafi.com/360/Data/ConsumerImage/1.png",
               "http://blase.masafi.com/360/Data/ConsumerImage//2.png",
                "http://blase.masafi.com/360/Data/ConsumerImage//2.png",
                              };
        String[] prodImgArray = {
               "http://blase.masafi.com/360/Data/ConsumerImage/12.png",
               "http://blase.masafi.com/360/Data/ConsumerImage/13.png",
               "http://blase.masafi.com/360/Data/ConsumerImage/14.png",
                "http://blase.masafi.com/360/Data/ConsumerImage/15.png",
                 "http://blase.masafi.com/360/Data/ConsumerImage/17.png",
                  "http://blase.masafi.com/360/Data/ConsumerImage/10.png",
                   "http://blase.masafi.com/360/Data/ConsumerImage/13.png",
                              };

        public void clickListner(int position)
        {
            adapter = new ProductListAdapter(Context, prodImgArray);
            adapter.NotifyDataSetChanged();
        }

        public void OnBackPressed()
        {
            FragmentManager fm = FragmentManager;
            fm.PopBackStack();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.product_catalog, container, false);
            mRecyclerView = view.FindViewById<RecyclerView>(Resource.Id.recyclerView);
            //dummy data



            // Plug in the linear layout manager:
            mLayoutManager = new LinearLayoutManager(this.Activity);
            mRecyclerView.SetLayoutManager(mLayoutManager);

            // Plug in my adapter:

           
            adapter = new ProductListAdapter(Context, imgArray);
            mRecyclerView.SetAdapter(adapter);
            return view;
        }
       
    }  
}