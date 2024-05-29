using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WindowsFormsApp19
{
    [Serializable]
    class Dodatak : ISerializable
    {
        private int id;
        private string nazivdodatka;
        private int cena;
        private int gramaza;



        public Dodatak(int id, string nazivdodatka, int cena, int gramaza)
        {
            this.id = id;
            this.nazivdodatka = nazivdodatka;
            this.cena = cena;
            this.gramaza = gramaza;



        }


        public Dodatak(SerializationInfo info, StreamingContext context)
        {
            this.id = info.GetInt32("id");
            this.nazivdodatka = info.GetString("nazivdodatka");
            this.cena = info.GetInt32("cena");
            this.gramaza = info.GetInt32("gramaza");



        }



        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("id", this.id);
            info.AddValue("nazivdodatka", this.nazivdodatka);
            info.AddValue("cena", this.cena);
            info.AddValue("gramaza", this.gramaza);


        }

      public int Id
        {
            get { return this.id; } 
       
        }

        public string Nazivdodatka
        {
            get { return this.nazivdodatka; }
            set { this.nazivdodatka = value; }
        }
 public int Cena
        {
            get { return this.cena; }
            set { this.cena = value; }
        }
        public int Gramaza
        {
            get { return this.gramaza; }
                set { this.gramaza = value;}
        }
    
    }
}


