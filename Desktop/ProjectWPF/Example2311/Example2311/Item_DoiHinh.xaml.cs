using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Example2311
{
    /// <summary>
    /// Interaction logic for Item_DoiHinh.xaml
    /// </summary>
    public delegate void Delete_Item();
    public partial class Item_DoiHinh : UserControl
    {
        System.Windows.Threading.DispatcherTimer timer;
        public Delete_Item delete_Item;
        int valueY=200;
        TranslateTransform translate;
        public Item_DoiHinh()
        {
            InitializeComponent();


            delete_ItemDoiHinh.Click += (s, e) =>
             {
                 delete_Item();
             };


            translate = new TranslateTransform();
            translate.Y = valueY;
            Stack_OptionItemDoiHinh.RenderTransform = translate;
            timer = new System.Windows.Threading.DispatcherTimer();
            


        }
        private void Show_Option_Event(object e, RoutedEventArgs arg)
        {
            Stack_OptionItemDoiHinh.Visibility = Visibility.Visible;
            valueY = 200;
            translate.Y = 200;
            Stack_OptionItemDoiHinh.RenderTransform = translate;
            timer.Tick += Update_Position;
            timer.Interval += TimeSpan.FromMilliseconds(40);
            timer.Start();
        }
        private void Update_Position(object e , EventArgs arg)
        {
            Dispatcher.Invoke(() =>
            {
                Stack_OptionItemDoiHinh.RenderTransform = translate;
            });

            if (valueY == 0)
            {
                timer.Stop();
                return;
            }
            valueY -= 50;
            translate.Y = valueY;
        }
        public void setSource(int position)
        {
            Img_ItemDoiHinh.Source = new BitmapImage(new Uri(Data.Images_Icon[position]));
        }
    }
}
