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
using System.Windows.Media.Imaging;
using System.IO;
using System.IO.IsolatedStorage;
using System.Windows.Resources;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;


namespace Stickies
{
    public partial class MainPage : PhoneApplicationPage
    {
      
        // Constructor
        public MainPage()
        {
            InitializeComponent();

        }
        
        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Draw.xaml", UriKind.Relative));
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/ViewStickies.xaml", UriKind.Relative));
        }

        
        private void btnHowTo_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/HowTo.xaml", UriKind.Relative));
        }
        private void btnMsg_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/StickieShare.xaml", UriKind.Relative));
        }
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
            {
                while (NavigationService.RemoveBackEntry() != null)
                {
                    NavigationService.RemoveBackEntry();
                }
            }

        }
        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            while (this.NavigationService.BackStack.Any())
            {
                this.NavigationService.RemoveBackEntry();
            }

        }
    }
}