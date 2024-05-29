using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WindowsFormsApp19
{
    [Serializable]
    class Prilog : ISerializable
    {
        private int id;
        private string nazivpriloga;
        private int cena;



        public Prilog(int id, string nazivpriloga, int cena)
        {
            this.id = id;
            this.nazivpriloga = nazivpriloga;
            this.cena = cena;



        }


        public Prilog(SerializationInfo info, StreamingContext context)
        {
            this.id = info.GetInt32("id");
            this.nazivpriloga = info.GetString("nazivpriloga");
            this.cena = info.GetInt32("cena");


        }



        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("id", this.id);
            info.AddValue("nazivpriloga", this.nazivpriloga);
            info.AddValue("cena", this.cena);

        }

        public int Id
        {
            get { return this.id; }
        }


        public string Nazivpriloga
        {
            get { return nazivpriloga; }
            set { nazivpriloga = value;}
        }



        public int Cena { 
            get { return cena; }
            set { cena = value; }
        }
    }
}