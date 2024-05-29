

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Collections;
using System.Web;

namespace WindowsFormsApp19
{
    [Serializable]
    class Rezervacija : ISerializable
    {
        private int id;
        private int idkorisnik;
        private int ukupnacena;
        private string porucenajela;
        private DateTime datum;



        public Rezervacija(int id, int idkorisnik, int ukupnacena, ArrayList porucenajela, DateTime datum)
        {

            this.id = id;
            this.idkorisnik = idkorisnik;
            this.ukupnacena = ukupnacena;
            var theString = string.Join(" ", porucenajela.ToArray());
            this.porucenajela = theString;
            this.datum = datum;
         }


        public Rezervacija(SerializationInfo info, StreamingContext context)
        {
            this.id = info.GetInt32("id");
            this.idkorisnik = info.GetInt32("idkorisnik");
            this.ukupnacena = info.GetInt32("ukupnacena");
            this.porucenajela = info.GetString("porucenajela");
            this.datum = info.GetDateTime("datum");
        }



        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("id", this.id);
            info.AddValue("idkorisnik", this.idkorisnik);
            info.AddValue("ukupnacena", this.ukupnacena);
            info.AddValue("porucenajela", this.porucenajela);
            info.AddValue("datum",this.datum);
        }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }


        }

        public int IdKorisnik
        {
            get { return this.idkorisnik; }


            set { this.idkorisnik = value; }





        }

        public int Ukupnacena
        {
            get { return this.ukupnacena; }
            set { this.ukupnacena = value; }


        }
        public string Porucenajela
        {
            get { return this.porucenajela; }
            set { this.porucenajela = value; }





        }

        public DateTime Datum {
        
        get { return this.datum; } set {  this.datum = value; }
        
        }   

    }
}