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
    public partial class PlayPauseControl : ContentView
    {
        public PlayPauseControl()
        {
            this.BindingContext = MusicStateViewModel.Instance;
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            ((Image)sender).Opacity = 0.6;
            ((Image)sender).FadeTo(1, 150);
        }
    }
}