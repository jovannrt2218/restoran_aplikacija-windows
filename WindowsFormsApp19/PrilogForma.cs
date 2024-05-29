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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp19
{
    public partial class PrilogForma : Form
    {

        int idH;
        List<Prilog> listaCitaj;//dohatanje liste priloga
        public PrilogForma()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string value = listBox1.GetItemText(listBox1.SelectedItem);

            if (value == null)
            {

                MessageBox.Show("Niste izabrali prilog");
            }
            else
            {

                for (int i = 0; i < listaCitaj.Count; i++)
                {


                    if (listaCitaj[i].Nazivpriloga == value)
                    {

                        listaCitaj.RemoveAt(i);
                        break;
                    }


                }

                using (Stream stream = File.Open("prilog.bin", FileMode.OpenOrCreate))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, listaCitaj);
                }
                MessageBox.Show("element je obrisan!!!!");

                PrilogForma prilogForma = new PrilogForma();
                prilogForma.Show();
                this.Close();




            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string naziv = textBox2.Text;
            int cena = Convert.ToInt32(textBox3.Text);


            List<Prilog> lista;

            if (!File.Exists("prilog.bin"))
            {
                List<Prilog> lista2;
                using (Stream stream = File.Open("prilog.bin", FileMode.OpenOrCreate))
                {
                    lista2 = new List<Prilog>();
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, lista2);
                }
                int idNew = 1;
                Prilog p1 = new Prilog(idNew, naziv, cena);
                lista2.Add(p1);
                using (Stream stream = File.Open("prilog.bin", FileMode.OpenOrCreate))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, lista2);
                }
                MessageBox.Show("prilog je  dodat");
                PrilogForma prilogForma = new PrilogForma();
                prilogForma.Show();
                this.Close();

            }
            else
            {
                using (Stream fileStream = File.OpenRead("prilog.bin"))
                {
                    BinaryFormatter binform = new BinaryFormatter();
                    lista = (List<Prilog>)binform.Deserialize(fileStream);

                }

                int id = lista.Count + 1;
                Prilog p = new Prilog(id, naziv, cena);
                lista.Add(p);

                using (Stream stream = File.Open("prilog.bin", FileMode.OpenOrCreate))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, lista);
                }
                MessageBox.Show("Prilog je  dodat");

                PrilogForma prilogForma = new PrilogForma();
                prilogForma.Show();
                this.Close();
            }
        }

        private void PrilogForma_Load(object sender, EventArgs e)
        {
            if (File.Exists("prilog.bin"))
            {
                List<Prilog> lista;

                using (Stream fileStream = File.OpenRead("prilog.bin"))
                {
                    BinaryFormatter binform = new BinaryFormatter();
                    lista = (List<Prilog>)binform.Deserialize(fileStream);

                }

                foreach (Prilog p in lista)
                {

                    listBox1.Items.Add(p.Nazivpriloga);


                }
                listaCitaj = lista;

            }
        }

    

        private void button2_Click(object sender, EventArgs e)
        {
            string naziv = textBox2.Text;
            int cena = Convert.ToInt32(textBox3.Text);
            


            foreach (Prilog a in listaCitaj)
            {
                if (a.Id == idH)
                {

                    a.Nazivpriloga = naziv;
                    a.Cena = cena;
                   
                }

            }
            using (Stream stream = File.Open("prilog.bin", FileMode.OpenOrCreate))
            {
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(stream, listaCitaj);
            }
            MessageBox.Show("Prilog je  AZURIRAN!!!");

            PrilogForma prilogForma = new PrilogForma();
            prilogForma.Show();
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

       
            textBox2.Text = "";
            textBox3.Text = "";
            string value = listBox1.GetItemText(listBox1.SelectedItem);



            using (Stream fileStream = File.OpenRead("prilog.bin"))
            {
                BinaryFormatter binform = new BinaryFormatter();
                listaCitaj = (List<Prilog>)binform.Deserialize(fileStream);

            }


            foreach (Prilog a in listaCitaj)
            {

                if (a.Nazivpriloga == value)
                {

                    textBox2.Text = a.Nazivpriloga;
                    textBox3.Text = a.Cena.ToString();


                    idH = a.Id;
                }


            }

        }
    }
    }

