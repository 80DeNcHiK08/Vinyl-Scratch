using Android.Content;
using Android.OS;

namespace VinylScratch.Droid.Audio
{
    public class AudioServiceConnection : Java.Lang.Object, IServiceConnection
    {
        private MainActivity _activity;

        public AudioServiceConnection(MainActivity activity)
        {
            _activity = activity;
        }

        public void OnServiceConnected(ComponentName name, IBinder service)
        {
            if (service != null)
            {
                var binder = (AudioServiceBinder)service;
                MainActivity.Binder = binder;
                _activity.IsBound = true;
            }
        }

        public void OnServiceDisconnected(ComponentName name)
        {
            _activity.IsBound = false;
        }
    }
}