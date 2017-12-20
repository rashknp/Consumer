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

    public class LoginFragment : Fragment, IBackButtonListener
    {
        private EditText etUsername, etPassword;
        private Button login;
        private TextView facebookLogin;
        public void OnBackPressed()
        {
            FragmentManager fm = FragmentManager;
            fm.PopBackStack();

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.fragment_login, container, false);

            etUsername = view.FindViewById<EditText>(Resource.Id.etUsername);
            etPassword = view.FindViewById<EditText>(Resource.Id.etPassword);
            login = view.FindViewById<Button>(Resource.Id.login);

         

            facebookLogin = view.FindViewById<TextView>(Resource.Id.facebookLogin);
            facebookLogin.Click += (sender, e) =>
              {

                  var intent = new Intent(this.Activity, typeof(FacebookActivity));
                   StartActivity(intent);


              };
         login.Click += (sender, e) =>
      {
          FragmentManager fm = FragmentManager;
          fm.PopBackStack();

          // Perform action on click
          /*  ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
            ISharedPreferencesEditor editor = prefs.Edit();
            editor.PutString("user", etUsername.Text);
            editor.PutString("password", etPassword.Text);
            // editor.Commit();    // applies changes synchronously on older APIs
            editor.Apply();
            */
          // var intent = new Intent(this, typeof(Categories));
          // StartActivity(intent);




          //Soap Api Consume
          // CallWebService();



          // Rest service consume sample

          /*   string paramData = "Hello World";
             string paramlocal = string.Format("http://174.142.61.234:9002/api/Countries", "GetData", paramData);


             HttpClient client = new HttpClient();
             HttpResponseMessage wcfResponse = client.GetAsync(paramlocal).Result;
             HttpContent stream = wcfResponse.Content;
             var data = stream.ReadAsStringAsync();
             string result = data.Result.ToString();
             Log.Info("Data",result);
             */


      };
            return view;

        }
    }
}