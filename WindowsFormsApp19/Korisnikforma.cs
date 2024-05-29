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
    public partial class Korisnikforma : Form
    {
        public Korisnikforma()
        {
            InitializeComponent();
        }
        List<Korisnik> listaCitaj;

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            }

        private void Korisnikforma_Load(object sender, EventArgs e)
        {
            if (File.Exists("korisnik.bin"))
            {
       

                using (Stream fileStream = File.OpenRead("korisnik.bin"))
                {
                    BinaryFormatter binform = new BinaryFormatter();
                    listaCitaj = (List<Korisnik>)binform.Deserialize(fileStream);

                }

                foreach (Korisnik p in listaCitaj)
                {

                    listBox1.Items.Add(p.Username);


                }


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string value = listBox1.GetItemText(listBox1.SelectedItem);

            if (value == null)
            {

                MessageBox.Show("Niste izabrali korisnika");
            }
            else
            {

                for (int i = 0; i < listaCitaj.Count; i++)
                {


                    if (listaCitaj[i].Username == value)
                    {

                        listaCitaj.RemoveAt(i);
                        break;
                    }


                }

                using (Stream stream = File.Open("korisnik.bin", FileMode.OpenOrCreate))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, listaCitaj);
                }
                MessageBox.Show("Korinsik je obrisan!!!!");
                Korisnikforma prilogForma = new Korisnikforma();
                prilogForma.Show();
                this.Close();


            }

            }
        }
    }

