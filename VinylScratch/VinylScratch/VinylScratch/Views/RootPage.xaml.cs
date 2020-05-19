using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinylScratch.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.PlatformConfiguration;

namespace VinylScratch.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RootPage : Xamarin.Forms.TabbedPage
    {
        public RootPage()
        {
            InitializeComponent();

            NavigationPage homePage = new NavigationPage(new HomePage(this));
            homePage.IconImageSource = "home_icon.png";
            homePage.Title = "Home";
            NavigationPage libraryPage = new NavigationPage(new LibraryPage());
            libraryPage.IconImageSource = "library_icon.png";
            libraryPage.Title = "Library";
            NavigationPage settingsPage = new NavigationPage(new SettingsPage());
            settingsPage.IconImageSource = "settings_icon.png";
            settingsPage.Title = "Settings";

            Children.Add(homePage);
            Children.Add(libraryPage);
            Children.Add(settingsPage);

            On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);

            /*MenuPage.PlaylistList.ItemSelected += (s, e) =>
            {
                PlaylistItemViewModel item = e.SelectedItem as PlaylistItemViewModel;
                if (item != null)
                {
                    if (!item.Playlist.IsDynamic && item.Playlist.Title == "Home")
                    {
                        PlaylistViewModel.Instance = null;
                        Detail = new NavigationPage(new HomePage(this))
                        {
                            BarBackgroundColor = Color.FromHex("#2287CA"),
                            BarTextColor = Color.White
                        };
                    }
                    else
                    {
                        PlaylistPage page = new PlaylistPage(item);
                        Detail = new NavigationPage(page)
                        {
                            
                        };
                    }
                }
                IsPresented = false;
            };*/
            //UpdateSelected(MenuViewModel.Instance.PlaylistItems.First());
        }
        public void UpdateSelected(object item)
        {
            if (item != null)
            {
                //MenuPage.PlaylistList.SelectedItem = item;
            }
        }
    }
}