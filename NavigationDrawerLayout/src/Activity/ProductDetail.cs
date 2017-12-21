using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Android;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;
using NavigationDrawerLayout.src.Fragments;

namespace NavigationDrawerLayout
{
    [Activity(Label = "DemoConsumer")]
    public class ProductDetail : Activity, ViewPager.IOnPageChangeListener
    {
        private ViewPager mCardsViewPager;
        private ImageView left, right, grid,list;
        private EditText etCase, etPeice;
        private TextView tvTotal, tvTotalCase, tvTotalPeice;
        private FrameLayout list_container, grid_container;
        FragmentTransaction transcation;
        src.Fragments.ProductDetailListFragment listFragment;
        private Bitmap GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;

            using (var webClient = new WebClient())
            {
                var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }

            return imageBitmap;
        }
        public void OnPageScrollStateChanged(int state)
        {

        }
        public void OnPageScrolled(int position, float positionOffset, int positionOffsetPixels)
        {

        }
        public void OnPageSelected(int position)
        {
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);


            SetContentView(Resource.Layout.layoutProductDetail);


            list_container = FindViewById<FrameLayout>(Resource.Id.list_container);
            grid_container = FindViewById<FrameLayout>(Resource.Id.grid_container);
            grid = FindViewById<ImageView>(Resource.Id.grid);
            list = FindViewById<ImageView>(Resource.Id.list);

            list.Click += (sender, e) =>
            {
                grid_container.Visibility = Android.Views.ViewStates.Invisible;
                transcation = FragmentManager.BeginTransaction();
                listFragment = new src.Fragments.ProductDetailListFragment();
                transcation.Add(Resource.Id.list_container, listFragment);
                transcation.Commit();
             
            };

            grid.Click += (sender, e) =>
            {
                grid_container.Visibility = Android.Views.ViewStates.Visible;

                var fragment = this.FragmentManager.FindFragmentById(Resource.Id.list_container);
                if (fragment != null)
                    transcation.Remove(fragment);

            };

            left = FindViewById<ImageView>(Resource.Id.leftArrow);
            right = FindViewById<ImageView>(Resource.Id.rightArrow);
            mCardsViewPager = FindViewById<ViewPager>(Resource.Id.pager);
            tvTotal = FindViewById<TextView>(Resource.Id.tvTotal);
            tvTotalPeice = FindViewById<TextView>(Resource.Id.tvTotalPeice);
            tvTotalCase = FindViewById<TextView>(Resource.Id.tvTotalCase);
            etCase = FindViewById<EditText>(Resource.Id.etCase);
            etPeice = FindViewById<EditText>(Resource.Id.etPeice);
            mCardsViewPager.Adapter = new CardsPagerAdapter(this.FragmentManager);

            mCardsViewPager.SetPageTransformer(true, new FadeTransformer());




           

            etCase.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {
                if (e.Text.ToString().Equals(""))
                {
                    tvTotalCase.Text = CalculatePrice("0");
                    tvTotal.Text = CalculateAmount(tvTotalCase.Text, tvTotalPeice.Text);
                }
                else
                {
                    tvTotalCase.Text = CalculatePrice(e.Text.ToString());
                    tvTotal.Text = CalculateAmount(tvTotalCase.Text, tvTotalPeice.Text);
                }
                tvTotal.Text = CalculateAmount(tvTotalCase.Text, tvTotalPeice.Text);

            };
            etPeice.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {
                if (e.Text.ToString().Equals(""))
                {
                    tvTotalPeice.Text = CalculatePrice("0");
                    tvTotal.Text = CalculateAmount(tvTotalCase.Text, tvTotalPeice.Text);
                }
                else
                {
                    tvTotalPeice.Text = CalculatePrice(e.Text.ToString());
                    tvTotal.Text = CalculateAmount(tvTotalCase.Text, tvTotalPeice.Text);
                }
             

            };



            left.Click += (sender, e) =>
            {
                mCardsViewPager.Adapter.GetItemPosition(mCardsViewPager);

                /*  int tab = mCardsViewPager
                  if (tab > 0)
                  {
                      tab--;
                      mCardsViewPager.setCurrentItem(tab);
                  }
                  else if (tab == 0)
                  {
                      mCardsViewPager.setCurrentItem(tab);
                  }
                  */
                // mCardsViewPager.Adapter.

            };
            right.Click += (sender, e) =>
            {
                mCardsViewPager.ArrowScroll(mCardsViewPager.NextFocusRightId);

            };



        }
        private String CalculatePrice(String peice)
        {
            int p = Int32.Parse(peice);

            int mul = p * 15;
            return Convert.ToString(mul);

        }
        private String CalculateAmount(String peice, String cas)
        {
            int p = Int32.Parse(peice);
            int c = Int32.Parse(cas);
            int sum = p + c;
            return Convert.ToString(sum);

        }
    }





    public class CardsPagerAdapter : Android.Support.V13.App.FragmentStatePagerAdapter
    {

        private int[] mCards = {
            Resource.Drawable.product,
            Resource.Drawable.product,
            Resource.Drawable.product,
            Resource.Drawable.product,
            Resource.Drawable.product,
            Resource.Drawable.product,
            Resource.Drawable.product,
            Resource.Drawable.product,
            Resource.Drawable.product,
            Resource.Drawable.product
            ,Resource.Drawable.product
        };

        private List<Fragment> CardsFragments { get; set; }

        public CardsPagerAdapter(FragmentManager fm) : base(fm)
        {

            CardsFragments = new List<Fragment>{

                new PagerFragment(mCards[0]),
                new PagerFragment(mCards[1]),
                new PagerFragment(mCards[2]),
                new PagerFragment(mCards[3]),
                new PagerFragment(mCards[4]),
                new PagerFragment(mCards[5]),
                new PagerFragment(mCards[6]),
                new PagerFragment(mCards[7]),
                new PagerFragment(mCards[8]),
                new PagerFragment(mCards[9]),
                new PagerFragment(mCards[10])
            };
        }

        #region implemented abstract members of PagerAdapter

        public override int Count
        {
            get
            {
                return CardsFragments.Count;
            }
        }

        #endregion

        #region implemented abstract members of FragmentStatePagerAdapter

        public override Fragment GetItem(int position)
        {
            return CardsFragments[position];
        }

        #endregion
    }

    public class FadeTransformer : Java.Lang.Object, ViewPager.IPageTransformer
    {
        private const float MaxAngle = 30F;
        public void TransformPage(View view, float position)
        {
            if (position < -1 || position > 1)
            {
                view.Alpha = 0; // The view is offscreen.
            }
            else
            {
                view.Alpha = 1;

                view.PivotY = view.Height / 2; // The Y Pivot is halfway down the view.

                // The X pivots need to be on adjacent sides.
                if (position < 0)
                {
                    view.PivotX = view.Width;
                }
                else
                {
                    view.PivotX = 0;
                }

                view.RotationY = MaxAngle * position; // Rotate the view.
            }
        }
    }
}