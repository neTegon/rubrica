using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tegon.elettra._4i.rubricaWPF
{
    public class Persone
    {
        public int idPersona { get; set; }
        public TipoContatto Tipo { get; set; }
        public string Valore { get; set; }

        public Persone(string riga)
        {
            string[] campi = riga.Split(';');

            TipoContatto c;
            int id = 0;
            int.TryParse(campi[0], out id);
            idPersona = id;
            Enum.TryParse(campi[1], out c);
            Tipo = c;

            this.Valore = campi[2];

        }
    }
}
