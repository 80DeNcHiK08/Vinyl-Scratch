using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content;
using VinylScratch.Droid.Audio;

namespace VinylScratch.Droid
{
    [Activity(Label = "VinylScratch", Icon = "@drawable/default_icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static MainActivity Instance;
        public bool IsBound = false;
        public Intent AudioServiceIntent;
        public static AudioServiceBinder Binder;
        private AudioServiceConnection _connection;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            //Window.SetFlags(WindowManagerFlags.LayoutNoLimits, WindowManagerFlags.LayoutNoLimits);
            global::Xamarin.Forms.Forms.SetFlags("SwipeView_Experimental");
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            //// AudioService setup
            Instance = this;
            System.Threading.Tasks.Task.Run(() =>
            {
                AudioServiceIntent = new Intent(Droid.Audio.AudioService.ActionStart);
                ComponentName name = StartService(AudioServiceIntent);
                _connection = new AudioServiceConnection(this);
                bool binded = BindService(AudioServiceIntent, _connection, Bind.AutoCreate);
            });
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        protected override void OnDestroy()
        {
            //StartService(new Intent(Droid.Audio.AudioService.ActionTryKill));
            base.OnDestroy();
        }
    }
}