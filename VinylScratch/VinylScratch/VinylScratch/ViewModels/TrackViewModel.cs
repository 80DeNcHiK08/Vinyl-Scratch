using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VinylScratch.Interfaces;
using VinylScratch.Models;
using Xamarin.Forms;

namespace VinylScratch.ViewModels
{
    public class TrackViewModel : BaseViewModel
    {
        public Playlist Playlist { get; set; }
        public Command AddSong { get; set; }
        private bool _isToggled;
        public bool IsToggled
        {
            get
            {
                return _isToggled;
            }
            set
            {
                _isToggled = value;
                OnPropertyChanged(nameof(CanAdd));
            }
        }
        public bool CanAdd
        {
            get
            {
                return Playlist.IsDynamic && _isToggled;
            }
        }
        public TrackViewModel(Playlist playlist)
        {
            Playlist = playlist;
            if (Playlist.IsDynamic)
            {
                AddSong = new Command(() =>
                {
                    Task.Run(async () =>
                    {
                        await DependencyService.Get<IPlaylistManager>().AddToPlaylist(
                            Playlist,
                            MusicStateViewModel.Instance.SelectedSong);
                        playlist.Tracks = await DependencyService.Get<IPlaylistManager>().GetPlaylistTracks(
                            playlist.Id);

                        if (PlaylistViewModel.Instance?.Id == playlist.Id)
                        {
                            PlaylistViewModel.Instance.Tracks = playlist.Tracks;
                        }
                    });
                });
            }
        }

        public TrackViewModel(Track track)
        {

        }
    }
}
