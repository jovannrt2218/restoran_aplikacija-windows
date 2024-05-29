using System;
using System.Collections;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp19
{
    public partial class rezervacijaforma : Form
    {
  
        List<Rezervacija> listaCitaj;//dohatanje liste Rezervacija
        List<Restoran> listRestoran;

        public rezervacijaforma()
        {
            InitializeComponent();
        }

        private void rezervacijaforma_Load(object sender, EventArgs e)
        {
            if (File.Exists("rezervacija.bin"))
            {


                using (Stream fileStream = File.OpenRead("rezervacija.bin"))
                {
                    BinaryFormatter binform = new BinaryFormatter();
                    listaCitaj = (List<Rezervacija>)binform.Deserialize(fileStream);

                }

                string ispis = "";



                foreach (Rezervacija p in listaCitaj)
                {

                    ispis += p.Id + "   , Korisnik: " + p.IdKorisnik + " Datum:"+p.Datum+ " Jela: ";


                    List<string> nameList = new List<string>(p.Porucenajela.Split(' '));

                    for (int i = 0; i < nameList.Count; i++)
                    {
                        ispis += nameList[i] + ", ";

                    }


                    ispis += " Ukupna cena: " + p.Ukupnacena;
                    listBox2.Items.Add(ispis);


                }
                textBox1.Enabled = false;
            }
            else
            {
                listBox2.Items.Add("nema rezervacija");
            }

            if (File.Exists("restoran.bin"))
            {

                using (Stream fileStream = File.OpenRead("restoran.bin"))
                {
                    BinaryFormatter binform = new BinaryFormatter();
                    listRestoran = (List<Restoran>)binform.Deserialize(fileStream);

                }

                foreach (Restoran a in listRestoran)
                {

                    comboBox1.Items.Add(a.Id + " " + a.naziv);


                }

            }

        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        textBox1.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            {
                string value = textBox1.Text;

                if (value == "")
                {

                    MessageBox.Show("Niste izabrali rezervaciju za brisanje");
                }
                else
                {

                    for (int i = 0; i < listaCitaj.Count; i++)
                    {


                        if (Convert.ToInt32(listaCitaj[i].Id) == Convert.ToInt32(value))
                        {

                            listaCitaj.RemoveAt(i);
                            break;
                        }

                    }
                    using (Stream stream = File.Open("rezervacija.bin", FileMode.OpenOrCreate))
                    {
                        BinaryFormatter bin = new BinaryFormatter();
                        bin.Serialize(stream, listaCitaj);
                    }

                    MessageBox.Show("Rezervacija obrisana!");
                    rezervacijaforma restoranforma = new rezervacijaforma();
                    restoranforma.Show();
                    this.Close();
                }
            }

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(listBox2.GetItemText(listBox2.SelectedItem).Substring(0,3).Trim());

            textBox1.Text = id.ToString();
        }

  

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }

}