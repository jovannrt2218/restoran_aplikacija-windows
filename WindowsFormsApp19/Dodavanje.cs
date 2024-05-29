using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp19
{
    public partial class Dodavanje : Form
    {
        int ID;
        List<string> listaNarucenih=new List<string>();
        public Dodavanje(int id)
        {
            InitializeComponent();
            ID = id;

        }
        List<Jelo> lista;
        private void Dodavanje_Load(object sender, EventArgs e)
        {
            if (File.Exists("jelo.bin"))
            {


                using (Stream fileStream = File.OpenRead("jelo.bin"))
                {
                    BinaryFormatter binform = new BinaryFormatter();
                    lista = (List<Jelo>)binform.Deserialize(fileStream);

                }

                foreach (Jelo p in lista)
                {

                    listBox1.Items.Add(p.Naziv + " " + p.Cena);


                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {


            int index = listBox1.SelectedIndex;

            Jelo j = lista.ElementAt(index);




            for (int i = 0; i < listaNarucenih.Count; i++)
            {

                if (Convert.ToInt32(listaNarucenih[i]) == j.Id)
                {
                    MessageBox.Show("Jelo je vec dodato ne moze 2 put");

                    return;
                }


            }

            if (j.Naziv == "pasta")
            {


                DialogResult dialogResult = MessageBox.Show("Da li zelite pene testeninu?", "Some Title", MessageBoxButtons.YesNo);


                if (dialogResult == DialogResult.Yes)
                {

                    listaNarucenih.Add(j.Id.ToString());


                    label3.Text = label3.Text+ " pene " + " \n " + j.Naziv + " " + j.Cena + " RSD";

                    azurirajUkupno(j.Cena);

                }else
                {

                    listaNarucenih.Add(j.Id.ToString());


                    label3.Text = label3.Text + " makarona " + " \n " + j.Naziv + " " + j.Cena + " RSD";

                    azurirajUkupno(j.Cena);

                }

            }

        }

        int suma = 0;

        private void azurirajUkupno(int cena)
        {
            suma = suma + cena;
            label5.Text = suma.ToString();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
      

            if (!File.Exists("rezervacija.bin"))
            {
                List<Rezervacija> lista2;
                using (Stream stream = File.Open("rezervacija.bin", FileMode.OpenOrCreate))
                {
                    lista2 = new List<Rezervacija>();
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, lista2);
                }
                int idNew = 1;

                var listaA = new ArrayList(listaNarucenih);

                Rezervacija p1 = new Rezervacija(idNew, ID, suma, listaA, DateTime.Today) ;
                lista2.Add(p1);
                using (Stream stream = File.Open("rezervacija.bin", FileMode.OpenOrCreate))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, lista2);
                }
                MessageBox.Show("Rezervacija je  dodata");
                rezervacijaforma pr = new rezervacijaforma();
                pr.Show();
                this.Close();
            }
            else
            {
                List<Rezervacija> lista;
                using (Stream fileStream = File.OpenRead("rezervacija.bin"))
                {
                    BinaryFormatter binform = new BinaryFormatter();
                    lista = (List<Rezervacija>)binform.Deserialize(fileStream);

                }

                int id = lista.Count + 1;
                Rezervacija r=new Rezervacija(id, ID, suma,new ArrayList(listaNarucenih), DateTime.Today) ;
                lista.Add(r);

                using (Stream stream = File.Open("rezervacija.bin", FileMode.OpenOrCreate))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, lista);
                }
                MessageBox.Show("Rezervacija je  dodata");

                rezervacijaforma pr = new rezervacijaforma();
                pr.Show();
                this.Close();
            }
        }
        }
    }

