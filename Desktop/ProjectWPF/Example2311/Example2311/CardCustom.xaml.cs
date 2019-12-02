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
    /// Interaction logic for Card.xaml
    /// </summary>
    /// // Đăng Ký Sự Kiện Khi Click Chọn
    public delegate void Event_Choose(int position);
   
    public partial class CardCustom: UserControl
    {
        public int isPosition = 0;
        int angleSkew = 0;
        int time_effect = 0;
        bool right = false;
        int position_imgRoll = 0;
        int positionEffect = 600;
        public event Event_Choose add_item;
        System.Windows.Threading.DispatcherTimer dispatcherTimer;
        System.Windows.Threading.DispatcherTimer timerAnimation;
        System.Windows.Threading.DispatcherTimer timer_UI;
        SkewTransform skewAnimation;
        TranslateTransform translatePosition;
        int TimerMilisecond = 0;
        ScaleTransform scaleSize;
        Random random;
        public CardCustom()
        {
            InitializeComponent();
            // Skew Animation
            //AnimationItem();
            img_body.Visibility = Visibility.Hidden;
              random = new Random();
            // Set up Transform 
            translatePosition = new TranslateTransform();
            translatePosition.Y = 600;

          

            But_Chon.Click += ThemItem;
            
            Stack_OptionSkill.Visibility = Visibility.Hidden;
            Grid_Expend.Width = 200;


            Grid_Expend.Visibility = Visibility.Hidden;
            Grid_Body.Visibility = Visibility.Visible;


            Item_Skill itemS1 = new Item_Skill();
            Item_Skill itemS2 = new Item_Skill();
            itemS1.cliked_changed += ShowOptionSkill;
            itemS2.cliked_changed += ShowOptionSkill;
            // Default 2 Item Skill
            Item_Header.Children.Add(itemS1);
            Item_Header.Children.Add(itemS2);

        }
        private void ThemItem(object e, RoutedEventArgs arg)
        {
            // event Tới Main
            add_item(isPosition);
        }
        private void ShowOptionSkill()
        {
            Grid_Expend.Width = 600;
            Grid_Expend.Visibility = Visibility.Visible;
            Grid_Body.Visibility = Visibility.Hidden;
           
            

        }

        // Timer Count Every 500 Miliseconds
        private void UpdateUI(object e, EventArgs arg)
        {
            time_effect += 200;
            if (time_effect>1000)
            {
               
                Dispatcher.Invoke(() =>
                {
                    img_item.Visibility = Visibility.Visible;
                    img_body.Visibility = Visibility.Hidden;
                       img_body.CancelAnimation();
                    
                });
               
                time_effect = 0;
                timer_UI.Stop();
                return;

            }
              


        }

        // Sự Kiện Nâng Cấp Item
        private void UplevelItem(object e, RoutedEventArgs arg)
        {
            timer_UI = new System.Windows.Threading.DispatcherTimer();
            timer_UI.Tick += UpdateUI;
            timer_UI.Interval += TimeSpan.FromMilliseconds(1000);
            time_effect = 0;

            // Chạy Timer 
          //  timer_UI.Start();

            // Ẩn Image Item
            img_item.Visibility = Visibility.Hidden;

            //  Hiện Lottie Và Chạy Lottie
            img_body.Visibility = Visibility.Visible;
            Dispatcher.Invoke(() =>
            {
                img_body.RepeatCount = 3;
                img_body.PlayAnimation();

            });
        }


        private void AnimationItem()
        {
            skewAnimation = new SkewTransform();
            skewAnimation.CenterX = Item_Body.ActualWidth / 2;
            skewAnimation.CenterY = Item_Body.ActualHeight / 2;
            Item_Header.RenderTransform = skewAnimation;
            Item_Body.RenderTransform = skewAnimation;
          
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += UpdateSkew;
            dispatcherTimer.Interval += TimeSpan.FromMilliseconds(30);
            dispatcherTimer.Start();

            


        }
        private void Back_StackDoiHinh(object e, RoutedEventArgs arg)
        {
            Grid_Expend.Width = 200;
            Grid_Expend.Visibility = Visibility.Hidden;
            Grid_Body.Visibility = Visibility.Visible;
        }
        private void UpdateSkew(object e, EventArgs g)
        {

            skewAnimation.AngleX = angleSkew;
            if (angleSkew==40)
            {
                right = true;
            }
            if(angleSkew == 0 && right)
            {
                dispatcherTimer.Stop();
                skewAnimation.AngleX = 0;
            }
            if(right)
            {
                angleSkew -= 10;
            }
            else
            {
                angleSkew += 10;
                
            }
         


        }

        private void But_Chon_Click(object sender, RoutedEventArgs e)
        {

        }
        private void But_Roll(object sender, RoutedEventArgs e)
        {
              timerAnimation = new System.Windows.Threading.DispatcherTimer();
              timerAnimation.Tick += AnimationChanged;
              timerAnimation.Interval += TimeSpan.FromMilliseconds(20);
              timerAnimation.Start();
              Random random = new Random();
              isPosition = random.Next(0, Data.Images.Length);
              
         //   timerEffect = new System.Windows.Threading.DispatcherTimer();
           

        }

      
        private void AnimationChanged(object e, EventArgs arg)
        {
            TimerMilisecond += 100;
            if (TimerMilisecond == 3000)
            {
                TimerMilisecond = 0;
                img_item.Source = new BitmapImage(
                                      new Uri(Data.Images[isPosition]));
                timerAnimation.Stop();
                return;
            }

            Dispatcher.Invoke(() =>
            {
                img_item.Source = new BitmapImage(
                                       new Uri(Data.Images[position_imgRoll]));
            });

            position_imgRoll++;
            if (position_imgRoll == Data.Images.Length)
                position_imgRoll = 0;
        }

    }
}
