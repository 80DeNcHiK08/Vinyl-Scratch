using System;
using VinylScratch.ViewModels;
using VinylScratch.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VinylScratch
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //var a = MusicStateViewModel.Instance;

            MainPage = new RootPage();
        }

        /*protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }*/
    }
}
