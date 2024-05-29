using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WindowsFormsApp19
{
    [Serializable]
    class Restoran :ISerializable
    {
        public int ID;
        public string naziv;
        public string adresa;
        public string kontakttelefon;
        

        public Restoran(int id, string naziv,string adresa,string kontakt)
        {
            this.ID = id;
            this.naziv = naziv;
            this.adresa = adresa;
            this.kontakttelefon = kontakt;

        }

        public Restoran(SerializationInfo info, StreamingContext context){
            this.ID = info.GetInt32("id");
            this.naziv = info.GetString("naziv");
            this.adresa = info.GetString("adresa");
            this.kontakttelefon = info.GetString("kontakt");

        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {

            info.AddValue("id", this.ID);
            info.AddValue("naziv", this.naziv);
            info.AddValue("adresa", this.adresa);
            info.AddValue("kontakt", this.kontakttelefon);


        }

        public override string ToString()
        {
            return "";
        }

        public int Id
        {
            get { return this.ID; }
        }
    }
}
