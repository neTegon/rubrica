using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tegon.elettra._4i.rubricaWPF
{
    public enum TipoContatto { nessuno, Email, web,Telefono }
    public class Contatto
    {
        public int idPersona {  get; set; }
        public string valore { get; set; }
        public TipoContatto tipo { get; set; }

        public Contatto() { }
        
        public Contatto(string riga)
        {
            int id;
            TipoContatto c;
            string[] campi = riga.Split(',');
            int.TryParse(campi[0], out id);
            Enum.TryParse(campi[1], out c);
            tipo = c;
            idPersona = id;
            this.valore= campi[2];
        }
    }
}