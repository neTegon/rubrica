using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tegon.elettra._4i.rubricaWPF
{
    internal class Contatto
    {
        private int _PK;
        private int _numero;
        private string _nome;
        private string _cognome;
        private string _telefono;
        private string _Email;
        public int Numero
        {
            get
            {
                return _numero;
            }
            set
            {
                if (!(value < 0) && !(value > 100))
                    throw new ArgumentException();
                _numero = value;

            }
        }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Citta { get; set; }
        public string CAP { get; set; }
        public string Cognome { get => _cognome; set => _cognome = value; }
        public int PK { get => this._PK; set => _PK = value; }

        public Contatto() { }
        //prende dal file i dati
        public Contatto(string riga)
        {
            string[] campi = riga.Split(';');
            if (campi.Length >= 5)
            {
                if (int.TryParse(campi[0], out int res))
                {
                    this.PK = res;
                    this.Nome = campi[1];
                    this.Cognome = campi[2];
                    this.Telefono = campi[3];
                    this.Email = campi[4];
                }
                else
                {
                    //throw new ArgumentException($"L'argomento passato ({values[0]}) per il campo PK non è valido.");
                    this.PK = 0;
                }
            }

            /*public Contatto(string nom, string cog, int num, string e, string Tel)
            {
                Nome = nom;
                Cognome = cog;
                Numero = num;
                Email = e;
                Telefono = Tel;
            }*/
        }
    }
}
