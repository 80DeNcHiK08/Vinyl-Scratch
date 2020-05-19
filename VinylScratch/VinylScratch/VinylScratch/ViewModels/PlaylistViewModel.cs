using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using VinylScratch.Helpers;
using VinylScratch.Interfaces;
using VinylScratch.Models;
using Xamarin.Forms;

namespace VinylScratch.ViewModels
{
    public class PlaylistViewModel : BaseViewModel
    {
        public static PlaylistViewModel Instance { get; set; }
        public MusicStateViewModel MusicState { get { return MusicStateViewModel.Instance; } }
        public ObservableCollection<Track> selectedTracks { get; set; }
        public Command PlayCommand { get; set; }
        public ulong Id { get; set; }
        public string Title { get; set; }
        private IList<Track> _tracks;
        public IList<Track> Tracks
        {
            get { return _tracks; }
            set
            {
                _tracks = value;

                _playlist.Tracks = _tracks;
                OnPropertyChanged(nameof(Tracks));
                OnPropertyChanged(nameof(TrackCount));
                OnPropertyChanged(nameof(HasSongs));
            }
        }
        public bool HasSongs { get { return _tracks != null && _tracks.Count > 0; } }

        public string TrackCount
        {
            get
            {
                return _tracks != null ? _tracks.Count == 1 ? $"{_tracks.Count} Track" : $"{_tracks.Count} Tracks" : "0 Tracks";
            }
        }
        public bool TracksLoading { get; set; }

        private TrackComparer _comparer;
        private Playlist _playlist;
        public PlaylistViewModel(Playlist playlistItem)
        {
            Instance = this;
            _comparer = new TrackComparer();
            _playlist = playlistItem;
            Id = (ulong)_playlist?.Id;
            Title = playlistItem.Title;
            if (_playlist.Tracks == null || _playlist.Tracks.Count == 0)
            {
                Task.Run(async () =>
                {
                    TracksLoading = true;
                    OnPropertyChanged(nameof(TracksLoading));
                    Tracks = await DependencyService.Get<IPlaylistManager>().GetPlaylistTracks(playlistItem.Id);
                    TracksLoading = false;
                    OnPropertyChanged(nameof(TracksLoading));
                });
            }
            else
            {
                Tracks = _playlist.Tracks;
            }

            PlayCommand = new Command((item) =>
            {
                DependencyService.Get<IMusicManager>().StartQueue(new ObservableCollection<Track>(Tracks), Tracks.IndexOf(item as Track));
            });
        }
    }
}
