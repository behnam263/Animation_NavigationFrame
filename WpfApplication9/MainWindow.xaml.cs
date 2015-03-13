using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApplication9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            animation.Completed += animation_Completed;
        }  
        public NavigatingCancelEventArgs _navArgs { get; set; }
        bool _allowDirectNavigation = false;
        public double _oldHeight { get; set; }


        private void Frame_Navigating(object sender, NavigatingCancelEventArgs e)
        {

           if (e.NavigationMode == NavigationMode.Back)
            {
                MessageBox.Show("Back");

            }
        }
    
        private void Button_MouseDown(object sender, MouseButtonEventArgs e)
        {
            pload = new Page1();
            frame1.BeginAnimation(OpacityProperty, animation);
        }  

         DoubleAnimation animation = new DoubleAnimation(1,0,new TimeSpan(0, 0, 0, 1, 500));
         Page pload = null;
        private void Button_MouseDown2(object sender, MouseButtonEventArgs e)
         {
             pload = new Page2();
            frame1.BeginAnimation(OpacityProperty, animation);
        }

        void animation_Completed(object sender, EventArgs e)
        {
            frame1.Navigate(pload);
        }
        private void Button_MouseDown3(object sender, MouseButtonEventArgs e)
        {
            frame1.GoBack();
        }

        private void frame1_Navigated(object sender, NavigationEventArgs e)
        {
            DoubleAnimation animation = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = new Duration(new TimeSpan(0, 0, 0, 5, 500))
            };
            frame1.BeginAnimation(OpacityProperty, animation); 
        }



       
    }
}
