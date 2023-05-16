using Android;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V4.App;
using Android.Webkit;
using Prism;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Xamarin.Forms;

namespace AppTempo.Droid
{
    [Activity(Theme = "@style/MainTheme",
              ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private static int MY_REQUEST_CODE = 100;

        protected override void OnCreate(Bundle savedInstanceState) 
        {
            try
            {
                var permissions = new List<String>();

                if (ActivityCompat.CheckSelfPermission(this, Manifest.Permission.AccessFineLocation) != Permission.Granted)
                {
                    permissions.Add(Manifest.Permission.AccessFineLocation);
                }
                if (ActivityCompat.CheckSelfPermission(this, Manifest.Permission.AccessCoarseLocation) != Permission.Granted)
                {
                    permissions.Add(Manifest.Permission.AccessCoarseLocation);
                }
                
                if (permissions.Count > 0)
                {
                    ActivityCompat.RequestPermissions(this, permissions.ToArray(), MY_REQUEST_CODE);
                }

  

                base.OnCreate(savedInstanceState);

                Xamarin.Essentials.Platform.Init(this, savedInstanceState);
                global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
                Xamarin.FormsMaps.Init(this, savedInstanceState);

                TabLayoutResource = Resource.Layout.Tabbar;
                ToolbarResource = Resource.Layout.Toolbar;

                LoadApplication(new App(new AndroidInitializer()));


            }
            catch (Exception ex)
            {
               throw;
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register any platform specific implementations
        }
    }
}

