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
using Android.Graphics;

namespace NavigationDrawerLayout.src.Adapter
{
    [Activity(Label = "TermsConditionAdapter")]
    public class TermsConditionAdapter : BaseAdapter
    {

        MainActivity context;
        string[] web;
   public  TermsConditionAdapter(MainActivity context, string[] web)
        {
            this.context = context;
            this.web = web;
        }


        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            TermsConditionAdaptViewHolder holder = null;

            if (view != null)
                holder = view.Tag as TermsConditionAdaptViewHolder;

            if (holder == null)
            {
                holder = new TermsConditionAdaptViewHolder();
                var inflater = context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();
                //replace with your item and your holder items
                //comment back in
                view = inflater.Inflate(Resource.Layout.activity_term_itme, parent, false);
                holder.Title = view.FindViewById<TextView>(Resource.Id.tvTermandCondition);
                view.Tag = holder;
            }


            //fill in your items
            holder.Title.TextSize=14;
            holder.Title.SetTypeface(Typeface.DefaultBold,TypefaceStyle.Bold);
            holder.Title.Text = web[position];

            return view;
        }
        
        //Fill in cound here, currently 0
        public override int Count
        {
            get
            {
                return web.Length;
            }
        }

    }

    class TermsConditionAdaptViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use
        public TextView Title { get; set; }
    }
}