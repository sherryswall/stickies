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
using System.Windows.Markup;
using System.Windows.Controls.Primitives;
using System.Windows.Media.Imaging;
using System.Windows.Data;
using System.IO.IsolatedStorage;
using Microsoft.Xna.Framework.Media;
using System.IO;
using Microsoft.Phone.Tasks;
using Microsoft.Xna.Framework.Media.PhoneExtensions;
using System.Xml;
using Microsoft.Devices;
using Coding4Fun.Toolkit.Controls;


namespace Stickies
{
    public partial class Draw : PhoneApplicationPage
    {
        bool drawConnector = false;
        private Point currentPoint;
        private Point oldPoint;
        Popup pop = new Popup();

        public Draw()
        {
            InitializeComponent();
        }
        public void LoadCallout()
        {

        }

        private void image_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            drawConnector = false;
            Image img = (Image)sender;

            //get source of the image to bitmap for uri.
            BitmapImage bi = new BitmapImage();
            bi = (BitmapImage)img.Source;

            //create thumb so it can dragged around
            var drag = new Thumb();
            drag.Name = "thumb" + Guid.NewGuid().ToString();
            drag.DragDelta += new DragDeltaEventHandler(drag_DragDelta);

            drag.Width = 100;
            drag.Height = 180;

            //create template for the thumb            
            string template = "<ControlTemplate xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" " +
                "xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\" " +
                "x:Key=\"template1\">" +
                        "<Image Source=\"" + bi.UriSource.ToString() + "\" />" +
                "</ControlTemplate>";

            //parse template and assign to thumb template. 
            drag.Template = (ControlTemplate)XamlReader.Load(template);

            //add thumb to canvas
            canvas1.Children.Add(drag);

        }

        void drag_DragDelta(object sender, DragDeltaEventArgs e)
        {

            drawConnector = false;
            Thumb thumb = (Thumb)sender;
            double xPoint = Canvas.GetLeft(thumb) + e.HorizontalChange;
            double yPoint = Canvas.GetTop(thumb) + e.VerticalChange;

            if (xPoint > 355.0 && yPoint > 349.0)
            {
                canvas1.Children.Remove(thumb);
            }
            else
            {
                Canvas.SetLeft(thumb, Canvas.GetLeft(thumb) + e.HorizontalChange);
                Canvas.SetTop(thumb, Canvas.GetTop(thumb) + e.VerticalChange);
            }

        }

        private void callOutImg1_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Image img = (Image)sender;
            if (img.Name == "callOutConnector")
            {
                drawConnector = true;
            }
            else if (img.Name == "callOutConnectorDel")
            {
                drawConnector = false;

                List<int> indices = new List<int>();

                foreach (var item in canvas1.Children.OfType<Line>())
                {
                    indices.Add(canvas1.Children.IndexOf(item));
                }
                /* foreach (var i in indices)
                 {
                    if(canvas1.Children[i]!=null)
                        canvas1.Children.RemoveAt(i);                    
                 }*/
            }
            else if (img.Name == "callOutText")
            {
                drawConnector = false;
                TextBlock txtCallout = new TextBlock();

                txtCallout.Foreground = new SolidColorBrush(Colors.Black);
                Image m = (Image)sender;

                
                pop.Width = 400;
                pop.Height = 400;
                pop.Name = "Popup";

                CalloutInput ci = new CalloutInput();
                pop.Child = ci;
                pop.IsOpen = true;
                

                ci.btnDone.Click += (s, args) =>
                {
                    txtCallout.Text = ci.txtCallout.Text;

                    //create thumb so it can dragged around                
                    var name = "thumb" + Guid.NewGuid().ToString();
                    var drag = new Thumb();
                    drag.Name = name;

                    //drag aorund the element
                    drag.DragDelta += new DragDeltaEventHandler(drag_DragDelta);
                    //create template for the thumb            
                    string template = "<ControlTemplate xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" " +
                        "xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\" " +

                        "x:Key=\"template1\" x:Name=\"tst\">" +
                            "<StackPanel x:Name=\"imgGrid\" Orientation=\"Vertical\" Width=\"200\">" +
                                "<TextBlock xml:space=\"preserve\" TextWrapping=\"Wrap\" Foreground=\"Black\" Text=\"" + HttpUtility.HtmlEncode(txtCallout.Text) + "\" />" +
                             "</StackPanel>" +
                        "</ControlTemplate>";

                    //parse template and assign to thumb template. 
                    drag.Template = (ControlTemplate)XamlReader.Load(template);
                    //drag.Width = "{Binding BindsDirectlyToSource=True}";

                    //to make the textblock flexible.
                    Binding b1 = new Binding();
                    b1.Path = new PropertyPath("Height");
                    b1.BindsDirectlyToSource = true;

                    Binding b2 = new Binding();
                    b2.Path = new PropertyPath("Width");
                    b2.BindsDirectlyToSource = true;

                    drag.SetBinding(HeightProperty, b1);
                    drag.SetBinding(WidthProperty, b2);

                    drag.ApplyTemplate();


                    // drag.Width = 200;
                    //add thumb to canvas
                    canvas1.Children.Add(drag);

                    pop.IsOpen = false;

                };
                ci.btnNopes.Click += (s, args) =>
                {
                    pop.IsOpen = false;
                };
            }
            else if (img.Name == "calloutCancelAll")
            {
                Image imgBin = (Image)canvas1.FindName("dustbin");
                canvas1.Children.Clear();
                canvas1.Children.Add(imgBin);

            }
            else
            {
                //do nothing.
            }


        }

        void btnSave_Click(object sender, RoutedEventArgs e)
        {

            drawConnector = false;


            Image imgBin = (Image)canvas1.FindName("dustbin");
            imgBin.Visibility = Visibility.Collapsed;
            string filePath = string.Empty;

            WriteableBitmap wb = new WriteableBitmap(canvas1, new ScaleTransform());

            wb.Render(canvas1, new ScaleTransform());
            wb.Invalidate();

                        
            //save the image
            using (var ms = new MemoryStream())
            {
                wb.SaveJpeg(ms, (int)canvas1.Width, (int)canvas1.Height, 0, 100);

                ms.Seek(0, SeekOrigin.Begin);
                var lib = new MediaLibrary();
                var picture = lib.SavePicture(string.Format("img.jpg"), ms);

             
            }
            var toast = new ToastPrompt
            {
                Title = "St!ck!es",
                Message = "Image saved to Saved Pictures",
                ImageSource = new BitmapImage(new Uri("..\\Ok.png", UriKind.RelativeOrAbsolute))
            };
            
            toast.Show();

            imgBin.Visibility = Visibility.Visible;

          
        }


        private void canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (drawConnector)
            {
                currentPoint = e.GetPosition(canvas1);
                oldPoint = currentPoint;
            }
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {

            if (drawConnector)
            {
                currentPoint = e.GetPosition(canvas1);

                Line line = new Line() { X1 = currentPoint.X, Y1 = currentPoint.Y, X2 = oldPoint.X, Y2 = oldPoint.Y };
                line.Stroke = new SolidColorBrush(Colors.LightGray);
                line.StrokeThickness = 2;
                line.HorizontalAlignment = HorizontalAlignment.Left;
                line.VerticalAlignment = VerticalAlignment.Center;
                this.canvas1.Children.Add(line);
                oldPoint = currentPoint;
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            canvas1.Children.Clear();
            this.NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            
            if (pop.IsOpen)
            {
                pop.IsOpen = false;
                e.Cancel = true;
            }
        }

    }
}