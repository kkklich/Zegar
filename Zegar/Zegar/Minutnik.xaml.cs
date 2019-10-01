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
    /// Logika interakcji dla klasy Minutnik.xaml
    /// </summary>
    public partial class Minutnik : Page
    {
        DispatcherTimer time;

        public Minutnik()
        {
            InitializeComponent();
        }

        public Minutnik(DispatcherTimer time)
        {
            InitializeComponent();
            this.time = time;


            for(int i=0;i<60;i++)
            {
                cmb_minuty.Items.Add(i);
            }

        }

        Boolean czykoniec = false;

        private void Btn_licz_Click(object sender, RoutedEventArgs e)
        {
            DateTime teraz = DateTime.Now;
            DateTime t;
            if (cmb_minuty.SelectedIndex>0)
            {
                int min = int.Parse( cmb_minuty.SelectedItem.ToString());

               // MessageBox.Show(min.ToString());
               teraz= teraz.AddMinutes(min);
                TimeSpan temp = new TimeSpan(0, 0, 0, 0, 0);
                

                time.Interval = new TimeSpan(0, 0, 0, 0, 1);
                time.Tick += delegate
                {
                    t = DateTime.Now;
                    TimeSpan roznica = teraz-t;

                    if(czykoniec==false)
                    lbl_czas.Content = roznica.ToString();

                    if( roznica.Minutes==0 && roznica.Seconds==0 )
                    {
                        lbl_czas.Content = "Koniec czasu";
                        czykoniec = true;
                    }

                };



            }

        }
    }
}
