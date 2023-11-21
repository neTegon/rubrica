using System;
using System.Collections.Generic;
using System.IO;
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

namespace tegon.elettra._4i.rubricaWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loader(object sender, RoutedEventArgs e)
        {

            const int Max = 100;
            int idx = 0;
            try
            {
                
                Contatto[] Contatti = new Contatto[Max];

                StreamReader sr = new("Dati.csv");
                sr.ReadLine();
                string riga =string.Empty;

                while (!sr.EndOfStream && idx<Max)
                {
                    riga = sr.ReadLine();
                    Contatti[idx++] = new (riga);
                    idx++;
                }

                while(idx<Max)
                {
                    Contatti[idx++]=new();
                }

                idx = 0;
                dgDati.ItemsSource = Contatti;



            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\nErrore alla riga: {idx}!");
            }

            private void gdDati_LoadingRow(object sender, System.Windows.Controls.DataGridRowEventArgs e)
            {
                Contatto prova=e.Row.DataContext as Contatto;
                if(prova!=null && prova.PK==0)
                {
                    e.Row.Background = Brushes.Red;
                }
            }

            /*
            try
            {

                valore = c.Numero;
                

                c.Numero= 1;
                c.Nome = "Elettra";
                c.Cognome = "Tegon";
                c.Email = "elettra.tegon@studenti.ittsrimini.edu.it";
                c.Telefono = "3371532353";
                c.CAP = "47923";
                valore = c.Numero;

                Contatto c1= new Contatto {Numero=2, Nome="Riccardo", Cognome="Bianchi" };
                Contatti[1] = c1;
                

                Contatto c2 = new Contatto { Numero = 2, Nome = "Riccardo", Cognome = "Bianchi" };
                Contatti[2] = c2;

            }
            catch (Exception err)
            {
                MessageBox.Show("No"+ err.Message);
            }
            */

        }
    }
}
