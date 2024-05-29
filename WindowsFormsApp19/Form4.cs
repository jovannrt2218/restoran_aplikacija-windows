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
    public partial class Form4 : Form
    {
        int ID;
        public Form4(int id)
        {
            InitializeComponent();
            ID = id;    
        }
        List<Rezervacija> rezervacije;

        private List<Rezervacija> GetRezervacije()
        {
            return rezervacije;
        }

 

        private void button1_Click(object sender, EventArgs e)
        {
            Dodavanje d = new Dodavanje(ID);
            d.Show();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            if (File.Exists("rezervacija.bin"))
            {


                using (Stream fileStream = File.OpenRead("rezervacija.bin"))
                {
                    BinaryFormatter binform = new BinaryFormatter();
                    rezervacije = (List<Rezervacija>)binform.Deserialize(fileStream);
                }

                var l = this.rezervacije;
                dataGridView1.DataSource = l;
            


            }
            else
            {
                MessageBox.Show("Nema rezervacije!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            rezervacijaforma pr = new rezervacijaforma();
            pr.Show();
            this.Close();
        }
    }
}
