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
    /// Interaction logic for Item_Skill.xaml
    /// </summary>
    public delegate void Cliked_OptionSkill();
    public partial class Item_Skill : UserControl
    {
        public event Cliked_OptionSkill cliked_changed;
        public Item_Skill()
        {
            InitializeComponent();

        }
        private void ClickedImage(object e , RoutedEventArgs arg)
        {
            cliked_changed();
        }
    }
}
