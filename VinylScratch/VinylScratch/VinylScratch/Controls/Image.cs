using FFImageLoading.Forms;
using FFImageLoading.Svg.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace VinylScratch.Controls
{
    class DisplayedImage : CachedImage
    {
        public static readonly BindableProperty ImageProperty = BindableProperty.Create<DisplayedImage, object>(p => p.Image, false);
        public object Image
        {
            get { return (object)GetValue(ImageProperty); }
            set
            {
                SetValue(ImageProperty, value);
            }
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            switch (propertyName)
            {
                case "Imagee":
                    System.Diagnostics.Debug.WriteLine("Artwork Changed Started");
                    System.Diagnostics.Debug.WriteLine("Artwork = " + Image);
                    if (!string.IsNullOrEmpty(Image?.ToString()) && !Image.ToString().Equals("False"))
                    {
                        if (Device.RuntimePlatform == Device.iOS)
                        {
                            double width = WidthRequest, height = HeightRequest;
                            if (WidthRequest == -1)
                            {
                                System.Diagnostics.Debug.WriteLine("WidthRequest = -1");
                                width = 400;
                                height = 400;
                            }

                            //System.IO.Stream stream = ((MPMediaItemArtwork)Artwork).ImageWithSize(new CoreGraphics.CGSize(width, height)).AsPNG().AsStream();
                            //Source = ImageSource.FromStream(() => stream);
                        }
                        else if (Device.RuntimePlatform == Device.Android)
                        {
                            Source = ImageSource.FromFile(Image.ToString());
                        }
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("Null");
                        Source = null;
                    }
                    System.Diagnostics.Debug.WriteLine("Artwork Finished");
                    break;
            }
        }
    }
}
