using Android;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V4.App;
using Prism;
using Prism.Ioc;
using System;
using System.Collections.Generic;

namespace AppTempo.Droid
{
    [Activity(Theme = "@style/MainTheme",
              ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private static int MY_REQUEST_CODE = 100;
        private bool loadApplication = false;

        protected override void OnCreate(Bundle savedInstanceState)
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
                loadApplication = true;
                ActivityCompat.RequestPermissions(this, permissions.ToArray(), MY_REQUEST_CODE);
            }


            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);


            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            Xamarin.FormsMaps.Init(this, savedInstanceState);

            if (permissions.Count == 0)
                LoadApplication(new App(new AndroidInitializer()));
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            if (loadApplication)
            {
                LoadApplication(new App(new AndroidInitializer()));
                loadApplication = false;
            }
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

