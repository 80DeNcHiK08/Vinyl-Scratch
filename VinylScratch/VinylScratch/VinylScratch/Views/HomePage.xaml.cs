using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VinylScratch.Interfaces;
using VinylScratch.Models;
using VinylScratch.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace VinylScratch.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        private RootPage _root;
        public HomePage()
        {
            InitializeComponent();
        }

        public HomePage(RootPage root)
        {
            _root = root;
            InitializeComponent();
            this.BindingContext = new HomeViewModel();
        }

        private async void Open_Playlist(object sender, EventArgs e)
        {
            NavigationPage pl_page = new NavigationPage(new PlaylistPage());
            await Navigation.PushAsync(pl_page, true);
        }

        private async void Create_Playlist(object sender, EventArgs e)
        {
            Playlist plview = new Playlist() { Title = "All tracks"};
            plview.Tracks = await DependencyService.Get<IPlaylistManager>().GetAllTracks();
            NavigationPage pl_page = new NavigationPage(new PlaylistPage(plview));
            await Navigation.PushAsync(pl_page, true);
        }

        private void Modify_Playlist(object sender, EventArgs e)
        {

        }

        private void Delete_Playlist(object sender, EventArgs e)
        {

        }

        // Because the Grid TapGesture wasn't registering on iOS
        private void TGR_PLImage(object sender, EventArgs e)
        {
            
        }

        private void SwipeStarted(object sender, EventArgs e)
        {
            _root.On<Xamarin.Forms.PlatformConfiguration.Android>().SetIsSwipePagingEnabled(false);
        }

        private async void SwipeEnded(object sender, EventArgs e)
        {
            await Task.Delay(3000);
            _root.On<Xamarin.Forms.PlatformConfiguration.Android>().SetIsSwipePagingEnabled(true);
        }
    }
}