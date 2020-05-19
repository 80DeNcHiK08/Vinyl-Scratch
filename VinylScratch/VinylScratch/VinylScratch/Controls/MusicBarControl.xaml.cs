using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinylScratch.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VinylScratch.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MusicBarControl : ContentView
    {
        public MusicBarControl()
        {
            InitializeComponent();
            this.BindingContext = MusicStateViewModel.Instance;
            SongsCarousel.Position = MusicStateViewModel.Instance.QueuePos;
        }

        private void OpenNowPlayingPopup(object sender, EventArgs e)
        {
            //Navigation.PushPopupAsync(new NowPlayingPopup());
        }
    }
}