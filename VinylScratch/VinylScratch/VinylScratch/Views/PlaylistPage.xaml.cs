using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinylScratch.Interfaces;
using VinylScratch.Models;
using VinylScratch.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VinylScratch.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlaylistPage : ContentPage
    {
        private static INavigation _nav;
        private PlaylistViewModel _vm;
        public PlaylistPage(Playlist playlistItem)
        {
            _vm = new PlaylistViewModel(playlistItem);
            this.BindingContext = _vm;
            InitializeComponent();
            _nav = Navigation;
        }

        public PlaylistPage()
        {
            _vm = new PlaylistViewModel(new Playlist() {Title = "New Playlist" });
            this.BindingContext = _vm;
            InitializeComponent();
        }

        private void PlaylistListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            _vm.PlayCommand.Execute(e.Item);
            //PlaylistListView.SelectedItem = null;
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            //Navigation.PushPopupAsync(QueuePopup.Instance);
        }

        public static INavigation Nav
        {
            get
            {
                return _nav;
            }
        }

        private async void Shuffle_Button_Clicked(object sender, EventArgs e)
        {
            PlaylistViewModel vm = this.BindingContext as PlaylistViewModel;
            await DependencyService.Get<IMusicManager>().SetQueue(new ObservableCollection<Track>(
                vm.Tracks.Select(s => new Models.Track(s))));
            DependencyService.Get<IMusicManager>().Shuffle();
        }

        private void Add_Button_Clicked(object sender, EventArgs e)
        {
            PlaylistViewModel vm = this.BindingContext as PlaylistViewModel;
            DependencyService.Get<IMusicManager>().AddToEndOfQueue(new ObservableCollection<Track>(
                vm.Tracks.Select(s => new Models.Track(s))));
        }

        private void SongOptionsPopup(object sender, EventArgs e)
        {
            ((Image)sender).Opacity = 0.6;
            ((Image)sender).FadeTo(1);
            Track track = BindingContext as Track;
            //Nav?.PushPopupAsync(new SongOptionsPopup(song));
        }

        private void Toggle_To_Playlist(object sender, EventArgs e)
        {
            _vm.selectedTracks = new ObservableCollection<Track>();
            foreach(var track in _vm.Tracks)
            {
                
            }
        }
    }
}