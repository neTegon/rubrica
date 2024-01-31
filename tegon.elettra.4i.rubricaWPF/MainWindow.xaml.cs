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

            
            int idx = 0;
            try
            {

                List<Contatto> contattos = new List<Contatto>();
                List<Persone> persones = new List<Persone>();
                //file conttatti
                StreamReader sr = new("Contatti.csv");
                sr.ReadLine();
                string riga =string.Empty;

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
                    persones.Add(new Persone(rigaPers));
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
            
        }
    }
}
