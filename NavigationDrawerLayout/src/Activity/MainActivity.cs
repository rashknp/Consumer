using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.Design.Widget;
using SupportFragment = Android.Support.V4.App.Fragment;
using NavigationDrawerLayout.src;
using Android.Content.PM;

namespace NavigationDrawerLayout
{
    [Activity(Label = "Consumer", Theme = "@style/Theme.DesignDemo", MainLauncher = true, Icon = "@drawable/icon", ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : AppCompatActivity
    {

        DrawerLayout drawerLayout;
        NavigationView navigationView;
      
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);


            // Create ActionBarDrawerToggle button and add it to the toolbar
            var toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);


            var drawerToggle = new ActionBarDrawerToggle(this, drawerLayout, toolbar, Resource.String.drawer_open, Resource.String.drawer_close);
            drawerLayout.SetDrawerListener(drawerToggle);
            drawerToggle.SyncState();
            

            navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            SetupDrawerContent(navigationView);
            drawerLayout.CloseDrawers();
            FragmentTransaction transcation = FragmentManager.BeginTransaction();
            src.Fragments.HomeFragment signup = new src.Fragments.HomeFragment();
            transcation.Add(Resource.Id.container, signup);
            transcation.Commit();

        }
        void SetupDrawerContent(NavigationView navigationView)
        {
           
            navigationView.NavigationItemSelected += (sender, e) =>
            {
                var menuItem = e.MenuItem;
                switch (menuItem.ItemId)

                {

                    case Resource.Id.product_catalogue:
                        //var NAVAcceuil = new Intent(this, typeof(Home));
                        //StartActivity(NAVAcceuil);
                       drawerLayout.CloseDrawers();
                        FragmentTransaction transcation = FragmentManager.BeginTransaction();
                        src.Fragments.HomeFragment login = new src.Fragments.HomeFragment();
                        transcation.Add(Resource.Id.container, login);
                        transcation.Commit();
                        Toast.MakeText(Application.Context, "Home selected", ToastLength.Long).Show();
                        break;

                    case Resource.Id.bit_cash:
                       drawerLayout.CloseDrawers();
                        FragmentTransaction transcation1 = FragmentManager.BeginTransaction();
                        src.Fragments.BitCashFragment bitCashFragment = new src.Fragments.BitCashFragment();
                        transcation1.Replace(Resource.Id.container, bitCashFragment, "Bit");
                        transcation1.AddToBackStack("Bit");
                        transcation1.Commit();
                        break;
                    case Resource.Id.contact_us:
                        drawerLayout.CloseDrawers();
                        FragmentTransaction transcation3 = FragmentManager.BeginTransaction();
                        src.Fragments.ContactUsFragment contactUsFragment = new src.Fragments.ContactUsFragment();
                        transcation3.Replace(Resource.Id.container, contactUsFragment, "Contact");
                        transcation3.AddToBackStack("Contact");
                        transcation3.Commit();
                        break;
                    case Resource.Id.social_media:
                        drawerLayout.CloseDrawers();
                        FragmentTransaction transcation4 = FragmentManager.BeginTransaction();
                        src.Fragments.SocialMediaFragment socialMediaFragment = new src.Fragments.SocialMediaFragment(this);
                        transcation4.Replace(Resource.Id.container, socialMediaFragment, "Social");
                        transcation4.AddToBackStack("Social");
                        transcation4.Commit();
                        //Toast.MakeText(Application.Context, "Shop selected", ToastLength.Long).Show();

                        break;
                    case Resource.Id.tell_friend:
                        drawerLayout.CloseDrawers();
                        //FragmentTransaction transcation3 = FragmentManager.BeginTransaction();
                        //src.Fragments.Fragment3 fragment3 = new src.Fragments.Fragment3();
                        //transcation3.Replace(Resource.Id.container, fragment3);
                        //transcation3.Commit();
                        //Toast.MakeText(Application.Context, "Shop selected", ToastLength.Long).Show();

                        break;
                   

                    case Resource.Id.terms:
                        //drawerLayout.CloseDrawers();
                        //FragmentTransaction transcation3 = FragmentManager.BeginTransaction();
                        //src.Fragments.Fragment3 fragment3 = new src.Fragments.Fragment3();
                        //transcation3.Replace(Resource.Id.container, fragment3);
                        //transcation3.Commit();
                        Toast.MakeText(Application.Context, "Shop selected", ToastLength.Long).Show();

                        break;

                    default:

                        Toast.MakeText(Application.Context, "Something Wrong", ToastLength.Long).Show();

                        break;

                }
              
                // drawerLayout.CloseDrawers();
            };
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {

            navigationView.InflateMenu(Resource.Menu.nav_menu);
         
            return base.OnCreateOptionsMenu(menu);

        }
        public override void OnBackPressed()
        {
            var currentFragment = FragmentManager.FindFragmentById(Resource.Id.container);
            var listener = currentFragment as IBackButtonListener;
            if (listener != null)
            {
                listener.OnBackPressed();
                return;
            }
            base.OnBackPressed();
        }

        //public override bool OnOptionsItemSelected(IMenuItem item)
        //{
        //    int id = item.ItemId;
        //    switch (id)
        //    {

        //        case Resource.Id.nav_home:
        //            {
        //                Toast.MakeText(this, "Home", ToastLength.Long).Show();
        //                //var NAVAcceuil = new Intent(this, typeof(Home));
        //                //StartActivity(NAVAcceuil);
        //                break;
        //            }
        //        default:
        //            break;
        //    }

        //    return base.OnOptionsItemSelected(item);

        //}


    }
}


