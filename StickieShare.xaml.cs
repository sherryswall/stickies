using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media.Imaging;
using System.Windows.Markup;
using System.Windows.Controls.Primitives;
using Coding4Fun.Toolkit.Controls;
using System.Windows.Data;
using System.Windows.Interop;
using System.IO;
using System.Windows.Media;
using Microsoft.Xna.Framework.Media.PhoneExtensions;
using Microsoft.Phone.Tasks;
using Microsoft.Xna.Framework.Media;
namespace Stickies
{
    public partial class StickieShare : PhoneApplicationPage
    {

        
        Image stickie;
        public StickieShare()
        {
            InitializeComponent();

            stickie = new Image();
            

        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {

            this.NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));

        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            pivotMsg.IsLocked = false;
            if (!string.IsNullOrEmpty(txtMsg.Text))
            {
                MessageBoxResult mbr = MessageBox.Show("Do you you want to discard the message?", "Message", MessageBoxButton.OKCancel);
                if (mbr == MessageBoxResult.OK)
                    txtMsg.Text = string.Empty;
            }
            
            pivotMsg.SelectedIndex = 0;
        }

        private void image_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            pivotMsg.IsLocked = false;
            pivotMsg.SelectedIndex = 1;


            stickie = (Image)sender;

            img.Source = stickie.Source;

            pivotMsg.IsLocked = true;

        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            WriteableBitmap wb = new WriteableBitmap(msgCanvas, new ScaleTransform());

            wb.Render(msgCanvas, new ScaleTransform());
            wb.Invalidate();


            //save the image
            using (var ms = new MemoryStream())
            {
                wb.SaveJpeg(ms, (int)msgCanvas.Width, (int)msgCanvas.Height, 0, 100);

                ms.Seek(0, SeekOrigin.Begin);
                var lib = new MediaLibrary();
                var picture = lib.SavePicture(string.Format("img.jpg"), ms);

                var toast = new ToastPrompt
                {
                    Title = "St!ck!es",
                    Message = "Image saved to Saved Pictures",
                    ImageSource = new BitmapImage(new Uri("..\\Ok.png", UriKind.RelativeOrAbsolute))
                };
                toast.Completed += toast_Completed;
                toast.Show();

                var task = new ShareMediaTask();

                task.FilePath = picture.GetPath();

                task.Show();
            }
        }

        void toast_Completed(object sender, PopUpEventArgs<string, PopUpResult> e)
        {
            
        }

    }
}