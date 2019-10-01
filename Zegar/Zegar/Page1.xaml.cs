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
    /// Logika interakcji dla klasy Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        DispatcherTimer time;
        DateTime start;
        TimeSpan czas;
        Boolean liczyc = true;
        int iloscm = 0;
        int raz = 1;
        TimeSpan pauza = new TimeSpan();
        Boolean czypauza = false,czystop=false;
        TimeSpan temp = new TimeSpan();



        public Page1()
        {
            InitializeComponent();
        }

        public Page1(DispatcherTimer time)
        {
            InitializeComponent();
            this.time = time;

            lbl_time.Content = "00:00:00.0000000";
        }


        private void Btn_start_Click(object sender, RoutedEventArgs e)
        {
            int ile=listbox_miedzy.Items.Count;
            
            raz = 1;
            if (czypauza == false)
            {
                for (int i = 0; i < ile; i++)
                {
                    listbox_miedzy.Items.RemoveAt(0);
                }
                iloscm = 0;
            }
            liczyc = true;
            


           // TimeSpan ponowne = new TimeSpan();

            if (czypauza==true)
            {
                DateTime temp ;
                temp = DateTime.Now;

                start = temp - pauza;

                czypauza = false;
            }
            else
            {

                start = DateTime.Now;
            }

            if(czystop==true)
            {
                start = DateTime.Now;
                czystop = false;

            }
           
            

            time.Interval = new TimeSpan(0, 0, 0,0, 1);
              time.Tick += delegate
              {
                  DateTime teraz =DateTime.Now;
                   czas = teraz - start;
                  // MessageBox.Show("czas1 "+czas.ToString());




                  if (liczyc == true)
                  {
                      lbl_time.Content = czas.Hours.ToString() + "h " + czas.Minutes.ToString() + "min " + czas.Seconds.ToString() + "s " + czas.Milliseconds.ToString();

                      temp = czas;
                  }
              };
              time.Start();
              
          

        }

        
        private void Btn_stop_Click(object sender, RoutedEventArgs e)
        {
            czystop = true;
            liczyc = false;

            if (raz == 1)
            {
                ++iloscm;
                listbox_miedzy.Items.Add(iloscm + ": " + temp.ToString());
            }
            raz++;
            // time.Stop();
            //stop = DateTime.Now;
            // TimeSpan c = stop - start;
            //lbl_time.Content = czas.ToString();
            //  MessageBox.Show(  czas.ToString());

        }

        
        private void Btn_miedzyczas_Click(object sender, RoutedEventArgs e)
        {
            if (raz == 1 && czypauza==false)
            {
                ++iloscm;
                listbox_miedzy.Items.Add(iloscm + ": " + temp.ToString());
                
            }
        }

        
        private void Btn_pauza_Click(object sender, RoutedEventArgs e)
        {
            //t = start;
            pauza = czas;
            czypauza = true;
            
            liczyc = false;


            if (raz == 1)
            {
                
                    ++iloscm;
                    listbox_miedzy.Items.Add(iloscm + ": " + temp.ToString());
                
            }
            raz++;
        }
    }
}
