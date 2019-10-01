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
using System.Media;

namespace Zegar
{
    /// <summary>
    /// Logika interakcji dla klasy Budz.xaml
    /// </summary>
    public partial class Budz : Page
    {
        DispatcherTimer time;
        SoundPlayer player = new System.Media.SoundPlayer(@"D:\Pobrane\02 Come With Me Now (online-audio-converter.com) (1).wav");
        int dodaj;

        public Budz()
        {
            InitializeComponent();

        }


        public Budz(DispatcherTimer f)
        {
            

            InitializeComponent();

            time = f;
            player.Load();

            for (int i = 0; i < 24; i++)
            {
                comboBox.Items.Add(i);
            }

            for (int i = 0; i < 60; i++)
            {
                comboBox_Copy.Items.Add(i);
            }

            //odliczanie();
            btn_off.IsEnabled = false;

        }

        

        private void odliczanie(int dodaj,string hour,string minute)
        {
            int i = 0;

            string h=hour, m=minute;
            

            DateTime teraz = DateTime.Now;
            int rok = teraz.Year;
            int miesiac = teraz.Month;
            int dzien = teraz.Day;
            int sekunda = teraz.Second;

            
            DateTime pobudka = new DateTime();

            if (comboBox.SelectedIndex > 0 && comboBox_Copy.SelectedIndex > 0)
            {
                pobudka = new DateTime(rok, miesiac, dzien, int.Parse(h), int.Parse(m), 0);



                 pobudka = pobudka.AddMinutes(dodaj);
               // TimeSpan ts = new TimeSpan(0, dodaj, 0);
                 h = pobudka.Hour.ToString();
                m = pobudka.Minute.ToString();

               // MessageBox.Show(pobudka + "   dodaj:" + dodaj);

                time.Interval = new TimeSpan(0, 0, 1);
                time.Tick += delegate
                {
                    DateTime t = DateTime.Now;
                    TimeSpan duration;
                    TimeSpan temp = new TimeSpan(1, 0, 0, 0);

                   
                        duration = pobudka - t;
                    

                    if (pobudka < t)
                    {
                      duration =duration.Add(temp);
                    }


                    
                    if (i == 0)
                    {//lblzegar.Content = pobudka.ToString();
                    lblzegar.Content = duration.ToString("%d")+"d "+ duration.ToString("%h")+"h "+ duration.ToString("%m") + " min " + duration.ToString("%s") + " s";
                     
                    }

                    if (h == t.Hour.ToString() && i == 0 && m == t.Minute.ToString())
                    {
                        btn_off.IsEnabled = true;

                        player.Play();


                        lblzegar.Content = "Pobudka";
                        i++;


                    }

                };
                time.Start();

            }
        }


       
        private void Budzik_Click(object sender, RoutedEventArgs e)
        {
            // DateTime czas1=new DateTime();

            string h = comboBox.SelectedItem.ToString();
            string m = comboBox_Copy.SelectedItem.ToString();
            btn_later.IsEnabled = true;
            dodaj = 0;
            odliczanie(0,h,m);
        }

        private void Btn_off_Click(object sender, RoutedEventArgs e)
        {
            player.Stop();
            btn_later.IsEnabled = false;

        }

        Boolean czydodac = false;
        int i = 5;
        private void Btn_later_Click(object sender, RoutedEventArgs e)
        {
            
            string h = comboBox.SelectedItem.ToString();
            string m = comboBox_Copy.SelectedItem.ToString();
            player.Stop();
            dodaj = 5;
            czydodac = true;
            odliczanie(i,h,m);
            i+=5;
        }
    }
}
