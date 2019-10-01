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
using System.Windows.Threading;

namespace Zegar
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DispatcherTimer timer = new DispatcherTimer();




        public MainWindow()
        {
            InitializeComponent();



            /*  timer = new DispatcherTimer(new TimeSpan(0,0,0,0,1),DispatcherPriority.Normal,delegate
              {
                  DateTime czas = DateTime.Now;

                   this.lbl2.Content = czas.ToString("HH:mm:ss");

               //   if (czas.Minute == 44)
                 //     MessageBox.Show("asdasd");

              },this.Dispatcher);

              */

            //timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            timer.Tick += delegate
            {
                DateTime czas = DateTime.Now;

                this.lbl2.Content = czas.ToString("HH:mm:ss");
                this.lbl.Content = czas.ToString("HH:mm:ss");
            };
                    
            timer.Start();


           

            
        }

        private void Btn_stop_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }

        private void Btn_start_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Page1 p1 = new Page1(timer);
            frame1.Content = p1;
            

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Budz b1 = new Budz(timer);
            frame1.Content = b1;
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Minutnik m1 = new Minutnik(timer);
            frame1.Content = m1;
        }
    }
}
