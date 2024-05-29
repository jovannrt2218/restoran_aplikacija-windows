using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp19
{
    public partial class Form2 : Form
    {


        List<Korisnik> kor;


        public Form2()
        {
            InitializeComponent();

            if (!File.Exists("korisnik.bin"))
            {
                Korisnik k = new Korisnik();
                kor = new List<Korisnik>();
                kor.Add(k);
                using (Stream stream = File.Open("korisnik.bin", FileMode.OpenOrCreate))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, kor);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string ime = textBox3.Text;
            string prezime = textBox4.Text;
            string username = textBox1.Text;
            string pass = textBox2.Text;



            Korisnik korisnik = new Korisnik(ime, prezime, username, pass, "user");


            List<Korisnik> lista;



            using (Stream fileStream = File.OpenRead("korisnik.bin"))
            {
                BinaryFormatter binform = new BinaryFormatter();
                lista = (List<Korisnik>)binform.Deserialize(fileStream);
            }

            lista.Add(korisnik);
            using (Stream stream = File.Open("korisnik.bin", FileMode.OpenOrCreate))
            {
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(stream, lista);
            }
            MessageBox.Show("Korisnik je registrovan");
            Form1 f1 = new Form1();

            f1.Show();
            this.Close();

        }


    }
}