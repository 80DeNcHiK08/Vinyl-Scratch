using Android.OS;

namespace VinylScratch.Droid.Audio
{
    public class AudioServiceBinder : Binder
    {
        private AudioService _audioService;

        public AudioServiceBinder(AudioService audioService)
        {
            _audioService = audioService;
        }

        public AudioService GetAudioService()
        {
            return _audioService;
        }
    }
}