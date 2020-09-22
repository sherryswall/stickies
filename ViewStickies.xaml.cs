using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Xna.Framework.Media;
using System.IO.IsolatedStorage;
using System.Windows.Media.Imaging;
using System.Windows.Controls.Primitives;

namespace Stickies
{
    public partial class ViewStickies : PhoneApplicationPage

    {
        Popup pop = new Popup();
        public ViewStickies()
        {
            InitializeComponent();
            LoadImages();
        }
        private void LoadImages()
        {
            MediaLibrary ml = new MediaLibrary();
            List<Picture> pc=ml.Pictures.Where(x => x.Name.Contains("_stickie")).ToList<Picture>();

            foreach (var item in pc)
            {
                Image img = new Image();
                BitmapImage bi = new BitmapImage();
                bi.SetSource(item.GetImage());
                img.Source = bi;
                img.Name = Guid.NewGuid().ToString();
                img.Width = bi.PixelWidth;
                img.Height = bi.PixelHeight;

                PanoramaItem pi = new PanoramaItem() { Content = img };
                pi.Tap += pi_Tap;
                panorama1.Items.Add(pi);
            }

            
            
        }

        void pi_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var temp = (PanoramaItem)sender;
            var x = (Image)temp.Content;

            
            pop.Width = 400;
            pop.Height = 400;
            pop.Name = "Popup";

            ShowStickie ss = new ShowStickie();
            ss.imgStickie.Source = x.Source;
            pop.Child = ss;
            pop.IsOpen = true;

            ss.btnBack.Click += (s, args) =>
               {
                   pop.IsOpen = false;
               };
            ss.btnHome.Click += (s, args) =>
            {
                pop.IsOpen = false;
                this.NavigationService.Navigate(new Uri("/MainPage.xaml",UriKind.Relative));
            };

        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {

            if (pop.IsOpen)
            {
                pop.IsOpen = false;
                e.Cancel = true;
            }
        }
        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            pop.IsOpen = false;
            this.NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

       
    }
}