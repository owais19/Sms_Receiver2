using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;
using Android.Telephony;
using Android.Provider;
using Android.Util;
using Java.Lang;
using System.Text.RegularExpressions;
using Xamarin.Essentials;
using System;


namespace Sms_Receiver2
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        public Receiver1 _receiver = new Receiver1();              // Receiver class 
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            TextView translatedPhoneWord = FindViewById<TextView>(Resource.Id.TranslatedPhoneword);
            Button translateButton = FindViewById<Button>(Resource.Id.TranslateButton);


            translateButton.Click += (s, e) =>
            {

                translatedPhoneWord.Text = _receiver.message;
                // Toast.MakeText(ApplicationContext, _receiver.address + ", " + _receiver.message, ToastLength.Short).Show();     //showing a Toast again 

            };


        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }


        protected override void OnResume()
        {
            base.OnResume();
            RegisterReceiver(_receiver, new IntentFilter("android.provider.Telephony.SMS_RECEIVED"));
        }

        protected override void OnPause()
        {
            base.OnPause();


        }

    }
}