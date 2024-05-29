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
    public partial class Restoranforma : Form
    {
        int idH;
        List<Restoran> listaCitaj;//dohatanje liste Restorana
        public Restoranforma()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string naziv = textBox1.Text;
            string adresa = textBox2.Text;
            string kontakt = textBox3.Text;

            List<Restoran> lista;

            if (!File.Exists("restoran.bin"))
            {
                List<Restoran> lista2;
                using (Stream stream = File.Open("restoran.bin", FileMode.OpenOrCreate))
                {
                    lista2 = new List<Restoran>();
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, lista2);
                }
                int idNew = 1;
                Restoran p1 = new Restoran(idNew, naziv, adresa, kontakt);
                lista2.Add(p1);
                using (Stream stream = File.Open("restoran.bin", FileMode.OpenOrCreate))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, lista2);
                }
                MessageBox.Show("restoran je  dodat");
                Restoranforma restoranforma = new Restoranforma();
                restoranforma.Show();
                this.Close();

            }
            else
            {
                using (Stream fileStream = File.OpenRead("restoran.bin"))
                {
                    BinaryFormatter binform = new BinaryFormatter();
                    lista = (List<Restoran>)binform.Deserialize(fileStream);

                }

                int id = lista.Count + 1;
                Restoran p = new Restoran(id, naziv, adresa, kontakt);
                lista.Add(p);

                using (Stream stream = File.Open("restoran.bin", FileMode.OpenOrCreate))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, lista);
                }
                MessageBox.Show("restoran je  dodat");

                Restoranforma restoranforma = new Restoranforma();
                restoranforma.Show();
                this.Close();
            }
        }

        private void Restoranforma_Load(object sender, EventArgs e)
        {
            if (File.Exists("restoran.bin"))
            {
                List<Restoran> lista;

                using (Stream fileStream = File.OpenRead("restoran.bin"))
                {
                    BinaryFormatter binform = new BinaryFormatter();
                    lista = (List<Restoran>)binform.Deserialize(fileStream);

                }

                foreach (Restoran p in lista)
                {

                    listBox1.Items.Add(p.naziv);


                }
                listaCitaj = lista;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string naziv = textBox1.Text;
            string adresa = textBox2.Text;
            string kontakt = textBox3.Text;



            foreach (Restoran a in listaCitaj)
            {
                if (a.Id == idH)
                {

                    a.naziv = naziv;
                    a.adresa = adresa;
                    a.kontakttelefon = kontakt;

                }

            }
            using (Stream stream = File.Open("resotran.bin", FileMode.OpenOrCreate))
            {
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(stream, listaCitaj);
            }
            MessageBox.Show("restoran je  AZURIRAN!!!");

            Restoranforma restoranforma = new Restoranforma();
            restoranforma.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string value = listBox1.GetItemText(listBox1.SelectedItem);

            if (value == null)
            {

                MessageBox.Show("Niste izabrali restoran");
            }
            else
            {

                for (int i = 0; i < listaCitaj.Count; i++)
                {


                    if (listaCitaj[i].naziv == value)
                    {

                        listaCitaj.RemoveAt(i);
                        break;
                    }


                }

                using (Stream stream = File.Open("restoran.bin", FileMode.OpenOrCreate))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, listaCitaj);
                }
                MessageBox.Show("element je obrisan!!!!");

                Restoranforma restoranforma = new Restoranforma();
                restoranforma.Show();
                this.Close();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            string value = listBox1.GetItemText(listBox1.SelectedItem);



            using (Stream fileStream = File.OpenRead("restoran.bin"))
            {
                BinaryFormatter binform = new BinaryFormatter();
                listaCitaj = (List<Restoran>)binform.Deserialize(fileStream);

            }


            foreach (Restoran a in listaCitaj)
            {

                if (a.naziv == value)
                {

                    textBox1.Text = a.naziv;
                    textBox2.Text = a.adresa;
                    textBox3.Text = a.kontakttelefon;


                    idH = a.Id;
                }
            }
        }
    }
}


