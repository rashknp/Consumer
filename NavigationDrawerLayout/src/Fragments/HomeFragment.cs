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
using System.Timers;
using Java.Lang;
using System.Threading.Tasks;



using System.Net;
using System.IO;
namespace NavigationDrawerLayout.src.Fragments
{

    public class HomeFragment : Fragment,IBackButtonListener
    {
        TextView login, promotion, contact, bitcash, website;
        LinearLayout Product_cataloguee;
        public static int[] mThumbIds = {
            Resource.Drawable.slide1,  Resource.Drawable.slide2,  Resource.Drawable.slide3,  Resource.Drawable.slide4, Resource.Drawable.slide5, Resource.Drawable.slide6,
            Resource.Drawable.slide8, Resource.Drawable.slide9};
        private LinearLayout layout;
        Thread th;
        //public void run()
        //{
        //    for (int i = 0; i < mThumbIds.Length; i++)
        //    {
        //        layout.SetBackgroundResource(mThumbIds[i]);

        //        try
        //        {
        //            Thread.Sleep(1000);
        //        }
        //        catch (System.Exception e)
        //        {

        //        }
        //   
        //}
        //public void create()
        //{

        //    Thread th = new Thread();
        //    th.Start();
        //    try
        //    {
        //        Thread.Sleep(1000);
        //    }
        //    catch (System.Exception e)
        //    {
        //        //System.out.println(e);
        //    }
        //}

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.fragment, container, false);
            login = view.FindViewById<TextView>(Resource.Id.Login);
            Product_cataloguee = view.FindViewById<LinearLayout>(Resource.Id.Product_cataloguee);
            promotion = view.FindViewById<TextView>(Resource.Id.Promotions);
            contact = view.FindViewById<TextView>(Resource.Id.Contact_us);
            bitcash = view.FindViewById<TextView>(Resource.Id.Bit_cash);
            website = view.FindViewById<TextView>(Resource.Id.Website);
         
            layout = view.FindViewById<LinearLayout>(Resource.Id.layout);
            // textView.Text = "Fragment1";
            TaskScheduler uiContext = TaskScheduler.FromCurrentSynchronizationContext();
            Console.WriteLine("timer started");
            Task.Delay(1000).ContinueWith((task) =>
            {
                //Do UI stuff
                for (int i = 0; i < mThumbIds.Length; i++)
                {
                    layout.SetBackgroundResource(mThumbIds[i]);
                    Task.Delay(1000);
                }
                Console.WriteLine("timer stopped");
            }, uiContext);

            //async Task Run()
            //{
            //    Console.WriteLine("timer started");
            //    await Task.Delay(1000);
            //    //Do UI stuff
            //    for (int i = 0; i < mThumbIds.Length; i++)
            //    {
            //        layout.SetBackgroundResource(mThumbIds[i]);

            //        try
            //        {
            //            Thread.Sleep(1000);
            //        }
            //        catch (System.Exception e)
            //        {

            //        }
            //        Console.WriteLine("timer stopped");
            //}
            //create();

            contact.Click += (o, e) =>
            {
                
                FragmentTransaction transcation1 = FragmentManager.BeginTransaction();
                src.Fragments.ContactUsFragment contactUsFragment = new src.Fragments.ContactUsFragment();
                transcation1.Replace(Resource.Id.container, contactUsFragment, "Contact");
                transcation1.AddToBackStack("Contact");
                transcation1.Commit();

            };
            website.Click += (o, e) =>
            {
                FragmentManager.PopBackStackImmediate();
                var uri = Android.Net.Uri.Parse("http://www.masafi.com/");
                var intent = new Intent(Intent.ActionView, uri);
                StartActivity(intent);
            };
            bitcash.Click += (o, e) =>
            {
                
                FragmentTransaction transcation1 = FragmentManager.BeginTransaction();
                src.Fragments.BitCashFragment bitCashFragment = new src.Fragments.BitCashFragment();
                transcation1.Replace(Resource.Id.container, bitCashFragment, "Bit");
                transcation1.AddToBackStack("Bit");
                transcation1.Commit();
            };
            login.Click += (o, e) =>
            {

                FragmentTransaction transcation1 = FragmentManager.BeginTransaction();
                src.Fragments.LoginFragment loginFragment = new src.Fragments.LoginFragment();
                transcation1.Replace(Resource.Id.container, loginFragment, "Login");
                transcation1.AddToBackStack("Login");
                transcation1.Commit();

                
            };
            Product_cataloguee.Click += (o, e) =>
            {

                FragmentTransaction transcation1 = FragmentManager.BeginTransaction();
                src.Fragments.ProductCatalogFragment loginFragment = new src.Fragments.ProductCatalogFragment();
                transcation1.Replace(Resource.Id.container, loginFragment, "Product");
                transcation1.AddToBackStack("Product");
                transcation1.Commit();
            };
            promotion.Click += (o, e) =>
            {

                FragmentTransaction transcation1 = FragmentManager.BeginTransaction();
                src.Fragments.PromotionFragment promotionFragment = new src.Fragments.PromotionFragment();
                transcation1.Replace(Resource.Id.container, promotionFragment, "Promotion");
                transcation1.AddToBackStack("Promotion");
                transcation1.Commit();
            };
            return view;

        }

        public void OnBackPressed()
        {
            FragmentManager fm = FragmentManager;
            fm.PopBackStack();
        }
    }
}