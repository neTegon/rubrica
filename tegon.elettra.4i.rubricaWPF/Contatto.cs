using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tegon.elettra._4i.rubricaWPF
{
    public enum TipoContatto { nessuno, Email, web,Telefono, Instagram,Facebook }
    
    public class Contatto
    {
        public int idPersona {  get; set; }
        public string valore { get; set; }
        public TipoContatto tipo { get; set; }
        public int Numero {
            get
            {
                return _numero;
            }

            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentOutOfRangeException();

                _numero = value;
            }
        }

        private int _numero;

        public Contatto()
        {
            tipo = TipoContatto.nessuno;
        }

        public Contatto(string riga)
        {
            int id;
            TipoContatto c;
            string[] campi = riga.Split(';');
            if (campi.Count() != 3)
            {
                throw new Exception("Le righe devono essere di tre colonne");
            }
            int.TryParse(campi[0], out id);
            Enum.TryParse(campi[1], out c);
            tipo = c;
            idPersona = id;
            this.valore= campi[2];
        }
        public static Contatto MakeContatto(string riga)
        {
            
            string[] campi = riga.Split(';');

            TipoContatto c;
            Enum.TryParse(campi[1], out c);

            switch (c)
            {
                case TipoContatto.Email:
                    return new CEmail(riga);
                    

                case TipoContatto.Telefono:
                    return new CNumero(riga);
                   

                case TipoContatto.CWeb:
                    return new CWeb(riga);
                   

                case TipoContatto.Instagram:
                    return new CInstagram(riga);
                    

                case TipoContatto.Facebook:
                    return new CFacebook(riga);
                   

            }
            return new Contatto(riga);
        }
    }
    public class Contatti : List<Contatto>
    {
        public Contatti() { }

        public Contatti(string nomeFile)
        {
            StreamReader ts = new StreamReader("Contatti.csv");
            ts.ReadLine();

            while (!ts.EndOfStream)
            {
                base.Add(Contatto.MakeContatto(ts.ReadLine()));

                //dgContatti.ItemsSource = Contatti;
            }
        }

    }
    public class CEmail : Contatto
    {
        public CEmail() { }

        public CEmail(string riga)
            : base(riga)
        { }

    }

    public class CNumero : Contatto
    {
        public CNumero() { }

        public CNumero(string riga)
            : base(riga)
        {

        }
    }
    public class CWeb : Contatto
    {
        public CWeb() { }

        public CWeb(string riga)
            : base(riga)
        {

        }
    }

    public class CInstagram : Contatto
    {
        public CInstagram() { }

        public CInstagram(string riga)
            : base(riga)
        {

        }
    }

    public class CFacebook : Contatto
    {
        public CFacebook() { }

        public CFacebook(string riga)
            : base(riga)
        {

        }

    }
}