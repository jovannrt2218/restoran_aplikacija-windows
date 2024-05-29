using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Collections;

namespace WindowsFormsApp19
{
    [Serializable]
    class Jelo : ISerializable
    {
        private int id;
        private string naziv;
        private int gramaza;
        private string opis;
        private int cena;
        private int idPrilog;
        private string dodaci;
        private int idRestoran;


        public Jelo(int id, string naziv, int gramaza, string opis, int cena, int idprilog, int idrestoran, ArrayList dodaci)
        {

            this.id = id;
            this.naziv = naziv;
            this.gramaza = gramaza;
            this.opis = opis;
            this.cena = cena;
            this.idPrilog = idprilog;
            this.idRestoran = idrestoran;
            // var strings = dodaci.Cast<string>().ToArray();
            var theString = string.Join(" ", dodaci.ToArray());
            this.dodaci = theString;


        }


        public Jelo(SerializationInfo info, StreamingContext context)
        {
            this.id = info.GetInt32("id");
            this.naziv = info.GetString("naziv");
            this.gramaza = info.GetInt32("gramaza");
            this.opis = info.GetString("opis");
            this.cena = info.GetInt32("cena");
            this.idPrilog = info.GetInt32("idprilog");
            this.idRestoran = info.GetInt32("idrestoran");
            this.dodaci = info.GetString("dodaci");



        }



        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("id", this.id);
            info.AddValue("naziv", this.naziv);
            info.AddValue("gramaza", this.gramaza);
            info.AddValue("opis", this.opis);
            info.AddValue("cena", this.cena);
            info.AddValue("idprilog", this.idPrilog);
            info.AddValue("idrestoran", this.idRestoran);
            info.AddValue("dodaci", this.dodaci);

        }

        public int Id
        {
            get { return this.id; }
        }


        public string Naziv
        {
            get { return this.naziv; }
            set { this.naziv = value; }
        }



        public int Gramaza
        {
            get { return this.gramaza; }
            set { this.gramaza = value; }
        }


        public string Opis
        {
            get { return this.opis; }
            set { this.opis = value; }
        }

        public int Cena
        {
            get { return this.cena; }
            set { this.cena = value; }
        }

        public int IdPrilog
        {
            get { return this.idPrilog; }
            set { this.idPrilog = value; }
        }

        public int IdRestoran
        {
            get { return this.idRestoran; }
            set { this.idRestoran = value; }
        }

        public string Dodaci
        {
            get { return this.dodaci; }
            set { this.dodaci = value; }
        }

    }

}