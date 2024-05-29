using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace WindowsFormsApp19
{

    
    [Serializable]
    class Korisnik :ISerializable
    {
 
        private int id;
        private string ime;
        private string prezime;
        private string username;
        private string password;
        private string vrstaKorisnika;


        public Korisnik()
        {
            this.id = 1;
            this.ime = "admin";
            this.prezime = "admin";
            this.username = "admin";
            this.password = "admin";
            this.vrstaKorisnika = "admin";
        }

        public Korisnik(string ime, string prezime, string username, string password, string vrstaKorisnika)
        {

            this.id = pronadjiID();
            this.ime = ime;
            this.prezime = prezime;
            this.username = username;
            this.password = password;
            this.vrstaKorisnika = vrstaKorisnika;
         

        }


        public Korisnik(SerializationInfo info, StreamingContext context)
        {
            this.id = info.GetInt32("id");
            this.ime = info.GetString("ime");
            this.prezime = info.GetString("prezime");
            this.username = info.GetString("username");
            this.password=info.GetString("password");
            this.vrstaKorisnika = info.GetString("vrstaK");
        }
    


        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("id", this.id);
            info.AddValue("ime", this.ime);
            info.AddValue("prezime", this.prezime);
            info.AddValue("username", this.username);
            info.AddValue("password", this.password);
            info.AddValue("vrstaK", this.vrstaKorisnika);
        }

        private int pronadjiID()
        {

            List<Korisnik> lista;

            using(Stream fileStream=File.OpenRead("korisnik.bin"))
            {
                BinaryFormatter binform = new BinaryFormatter();
                lista = (List<Korisnik>)binform.Deserialize(fileStream);
            }

            int id = lista.LastOrDefault().id + 1;


            return id;
            
        }

        public string Username
        {
            get => this.username;
            set => this.username = value;
        }


        public string Password
        {
            get => this.password;
            set => this.password = value;
        }

        public int Id
        {
            get { return this.id; }
        }
        public string VrstaKorisnika
        {

            get { return this.vrstaKorisnika; }
        }
    }
}
