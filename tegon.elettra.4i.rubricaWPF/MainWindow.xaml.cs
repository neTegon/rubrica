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
        Persone person = new Persone();
        private void Window_Loader(object sender, RoutedEventArgs e)
        {


            int idx = 0;
            try
            {

                List<Contatto> contattos = new List<Contatto>();
                List<Persona> persones = new List<Persona>();
                //file conttatti
                StreamReader sr = new("Contatti.csv");
                sr.ReadLine();
                string riga = string.Empty;

                while (!sr.EndOfStream)
                {
                    riga = sr.ReadLine();
                    contattos.Add(new Contatto(riga));
                    idx++;
                }
                idx = 0;
                dgContatti.ItemsSource = contattos;

                StreamReader pers = new("Persona.csv");
                pers.ReadLine();
                string rigaPers = string.Empty;

                while (!pers.EndOfStream)
                {
                    rigaPers = sr.ReadLine();
                    persones.Add(new Persona(rigaPers));
                    idx++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\nErrore alla riga: {idx}!");
            }

        }

        private void dgDati_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Persona p = e.AddedItems[0] as Persona;
            StatusBar.Text = $"{p.cognome}";

            List<Contatto> ContattiFiiltrati = new List<Contatto>();
            foreach (var item in Contatto)
            {
                if (item.idPersona == p.idPersona)
                {
                    ContattiFiiltrati.Add(item);

                    dgContatti.ItemsSource = ContattiFiiltrati;

                }
            }
        }
    }
}
