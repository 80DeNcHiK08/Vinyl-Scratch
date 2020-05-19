using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using VinylScratch.Droid.Audio;
using VinylScratch.Droid.Services;
using VinylScratch.Interfaces;
using VinylScratch.Models;
using Xamarin.Forms;

[assembly: Dependency(typeof(MusicManagerAndroid))]
namespace VinylScratch.Droid.Services
{
    public class MusicManagerAndroid : IMusicManager
    {
        private AudioService _audioService;
        private bool _isConnected = false;

        public void Init(Action<bool> IsPlaying, Action<double> GetSongPos, Action<int> GetQueuePos, Action<IList<Track>> GetQueue)
        {
            Task.Run(() =>
            {
                while (MainActivity.Binder == null)
                {
                    System.Threading.Thread.Sleep(100);
                }
                if (MainActivity.Binder != null)
                {
                    _audioService = MainActivity.Binder.GetAudioService();
                    _audioService.Init(IsPlaying, GetSongPos, GetQueuePos, GetQueue);
                    _isConnected = true;
                }
            });
        }

        public async void Next()
        {
            await Task.Run(() =>
            {
                if (_isConnected)
                {
                    _audioService?.Next();
                }
            });
        }

        public async void Pause()
        {
            await Task.Run(() =>
            {
                if (_isConnected)
                {
                    _audioService?.Pause();
                }
            });
        }

        public async void Play()
        {
            await Task.Run(() =>
            {
                if (_isConnected)
                {
                    _audioService?.Play();
                }
            });
        }

        public async void Prev()
        {
            await Task.Run(() =>
            {
                if (_isConnected)
                {
                    _audioService?.Prev();
                }
            });
        }

        public async void Seek(double position)
        {
            await Task.Run(() =>
            {
                if (_isConnected)
                {
                    _audioService?.Seek(position);
                }
            });
        }

        public async Task SetQueue(IList<Track> tracks)
        {
            await Task.Run(() =>
            {
                while (!_isConnected)
                {
                    System.Threading.Thread.Sleep(100);
                }
                if (_isConnected)
                {
                    _audioService?.SetQueue(tracks);
                    _audioService?.Prepare(0);
                }
            });
        }

        public async void StartQueue(IList<Track> tracks, int pos)
        {
            await Task.Run(() =>
            {
                if (_isConnected)
                {
                    _audioService?.SetQueue(tracks);
                    _audioService?.Start(pos);
                }
            });
        }

        public async void Shuffle()
        {
            await Task.Run(() =>
            {
                if (_isConnected)
                {
                    _audioService?.Shuffle();
                }
            });
        }

        public async void Start(int pos)
        {
            await Task.Run(() =>
            {
                if (_isConnected)
                {
                    _audioService?.Start(pos);
                }
            });
        }

        public async void ClearQueue()
        {
            await Task.Run(async () =>
            {
                if (_isConnected)
                {
                    await _audioService?.Stop();
                    Thread.Sleep(100);
                    _audioService?.SetQueue(null);
                }
            });
        }

        public void AddToEndOfQueue(IList<Track> tracks)
        {
            Task.Run(() =>
            {
                if (_isConnected)
                {
                    _audioService?.AddToEndOfQueue(tracks);
                }
            });
        }

        public void PlayNext(Track track)
        {
            Task.Run(() =>
            {
                if (_isConnected)
                {
                    _audioService?.PlayNext(track);
                }
            });
        }
    }
}