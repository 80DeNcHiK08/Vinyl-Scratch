using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinylScratch.Interfaces;
using VinylScratch.Models;
using Xamarin.Forms;

namespace VinylScratch.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private IList<PlaylistViewModel> _playlists;
        public IList<PlaylistViewModel> Playlists
        {
            get
            {
                return _playlists ?? new ObservableCollection<PlaylistViewModel>();
            }
            set
            {
                _playlists = value;
                OnPropertyChanged(nameof(Playlists));
            }
        }

        private bool _isLoading;

        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        public HomeViewModel()
        {
            Playlists = new ObservableCollection<PlaylistViewModel>();
            Playlists.Add(new PlaylistViewModel(new Playlist() { Title = "New Playlist", Tracks = new ObservableCollection<Track>() { new Track() { Title = "Track1"} } }));
            IsLoading = false;
            /*Task.Run(async () =>
            {
                var pls = DependencyService.Get<IPlaylistManager>().GetPlaylists().OrderByDescending(p => p.ModifiedAt).ToList();
                foreach (var pl in pls)
                {
                    pl.Tracks = await DependencyService.Get<IPlaylistManager>().GetPlaylistTracks(pl.Id);
                    if (pl.Tracks?.Count > 0)
                    {
                        foreach (var track in pl.Tracks)
                        {
                            if (track.HasImage)
                            {
                                pl.Image = track.Image;
                                break;
                            }
                        }
                    }
                }
                IsLoading = false;
                Playlists = pls;

                
            });*/
        }
    }
}
