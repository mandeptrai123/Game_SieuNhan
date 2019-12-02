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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
   
    public partial class MainWindow : Window
    {
     
        System.Windows.Threading.DispatcherTimer dispatcherTimer;
        int angleImg = 0;
        public MainWindow()
        {
            InitializeComponent();
            
           
            CardCustom card1 = new CardCustom();
            CardCustom card2 = new CardCustom();
            CardCustom card3 = new CardCustom();
            CardCustom card4 = new CardCustom();

            card1.add_item += ThemItemVaoDoiHinh;
            card2.add_item += ThemItemVaoDoiHinh;
            card3.add_item += ThemItemVaoDoiHinh;
            card4.add_item += ThemItemVaoDoiHinh;

            Item_DoiHinh item1 = new Item_DoiHinh();
            Item_DoiHinh item2 = new Item_DoiHinh();
            Item_DoiHinh item3 = new Item_DoiHinh();

            item1.delete_Item += DeleteDoiHinh;
            item2.delete_Item += DeleteDoiHinh;
            item3.delete_Item += DeleteDoiHinh;


            StackShow.Children.Add(card1);
            StackShow.Children.Add(card2);
            StackShow.Children.Add(card3);

            Stack_DoiHinh.Children.Add(item1);
            Stack_DoiHinh.Children.Add(item2);
            Stack_DoiHinh.Children.Add(item3);
            
            

            
        }


       private void ThemItemVaoDoiHinh( int position)
        {
            Dispatcher.Invoke(() =>
            {
                Item_DoiHinh item_New = new Item_DoiHinh();
                item_New.setSource(position);
                item_New.delete_Item += DeleteDoiHinh;
                Stack_DoiHinh.Children.Add(item_New);

            });
           

        }
        private void DeleteDoiHinh()
        {
            Stack_DoiHinh.Children.RemoveAt(Stack_DoiHinh.Children.Count-1);
        }
        private void HideBG()
        {
            bg_batman.Visibility = Visibility.Hidden;
            bg_iron.Visibility = Visibility.Hidden;
            bg_spider.Visibility = Visibility.Hidden;
            bg_super.Visibility = Visibility.Hidden;
        }
        private void But_Spider(object e , RoutedEventArgs arg)
        {
            HideBG();
            bg_spider.Visibility = Visibility.Visible;
        }
        private void But_Super(object e, RoutedEventArgs arg)
        {
            HideBG();
            bg_super.Visibility = Visibility.Visible;
        }

        private void But_Iron(object e, RoutedEventArgs arg)
        {
            HideBG();
            bg_iron.Visibility = Visibility.Visible;
        }
        private void But_Bat(object e, RoutedEventArgs arg)
        {
            HideBG();
            bg_batman.Visibility = Visibility.Visible;
        }
    }
}
