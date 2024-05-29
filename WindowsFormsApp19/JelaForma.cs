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

namespace WindowsFormsApp19
{
    public partial class JelaForma : Form
    {
        public JelaForma()
        {
            InitializeComponent();
        }

        List<Prilog> listPriloga;
        List<Dodatak> listDodatak;
        List<Restoran> listRestoran;
        ArrayList dodaci=new ArrayList();
        List<Jelo> listaCitaj;

        int idH;
        

        private void button1_Click(object sender, EventArgs e)
        {



            List<int> dodaci = new List<int>();


               
                
            

            string naziv = textBox1.Text;
            int cena = Convert.ToInt32(textBox4.Text);
            int gramza = Convert.ToInt32(textBox2.Text);
             string  opis= textBox3.Text; 
            int idPriloga=Convert.ToInt32(comboBox1.GetItemText(comboBox1.SelectedItem).Substring(0,1));
            int idRestorana = Convert.ToInt32(comboBox2.GetItemText(comboBox2.SelectedItem).Substring(0, 1)) ;

            foreach(var item in listBox2.Items)
            {
                dodaci.Add(Convert.ToInt32(item.ToString().Substring(0, 1)));
            }


            List<Jelo> lista;

            if (!File.Exists("jelo.bin"))
            {
                List<Jelo> lista2;
                using (Stream stream = File.Open("jelo.bin", FileMode.OpenOrCreate))
                {
                    lista2 = new List<Jelo>();
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, lista2);
                }
                int idNew = 1;
                Jelo jelo1 = new Jelo(idNew, naziv, gramza, opis, cena,idPriloga,idRestorana, new ArrayList(dodaci));

                lista2.Add(jelo1);
                using (Stream stream = File.Open("jelo.bin", FileMode.OpenOrCreate))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, lista2);
                }
                MessageBox.Show("Jelo je  dodato");


            }
            else
            {
                using (Stream fileStream = File.OpenRead("jelo.bin"))
                {
                    BinaryFormatter binform = new BinaryFormatter();
                    lista = (List<Jelo>)binform.Deserialize(fileStream);

                }

                int id = lista.Count + 1;
                Jelo jelo1 = new Jelo(id, naziv, gramza, opis, cena, idPriloga, idRestorana, new ArrayList(dodaci));
                lista.Add(jelo1);

                using (Stream stream = File.Open("jelo.bin", FileMode.OpenOrCreate))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, lista);
                }
                MessageBox.Show("Jelo je  dodato");
               JelaForma  pForma = new JelaForma();
                pForma.Show();
                this.Close();
            }











        }

        private void JelaForma_Load(object sender, EventArgs e)
        {


            if (File.Exists("dodatak.bin"))
            {


                using (Stream fileStream = File.OpenRead("dodatak.bin"))
                {
                    BinaryFormatter binform = new BinaryFormatter();
                    listDodatak = (List<Dodatak>)binform.Deserialize(fileStream);

                }

                foreach (Dodatak a in listDodatak)
                {

                    comboBox1.Items.Add(a.Id+" "+a.Nazivdodatka);


                }
            }


                if (File.Exists("prilog.bin"))
                {

                    using (Stream fileStream = File.OpenRead("prilog.bin"))
                    {
                        BinaryFormatter binform = new BinaryFormatter();
                        listPriloga = (List<Prilog>)binform.Deserialize(fileStream);

                    }

                    foreach (Prilog a in listPriloga)
                    {

                        comboBox3.Items.Add(a.Id+ " "+a.Nazivpriloga);


                    }





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

                        comboBox2.Items.Add(a.Id+" "+a.naziv);


                    }

                }


            if (File.Exists("jelo.bin"))
            {
                List<Jelo> lista;

                using (Stream fileStream = File.OpenRead("jelo.bin"))
                {
                    BinaryFormatter binform = new BinaryFormatter();
                    lista = (List<Jelo>)binform.Deserialize(fileStream);

                }

                foreach (Jelo p in lista)
                {

                    listBox1.Items.Add(p.Naziv);


                }
             

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            string value=comboBox3.GetItemText(comboBox3.SelectedItem);    

            dodaci.Add(value);  
            listBox2.Items.Add(value);  



        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            string naziv = textBox1.Text;
            int cena = Convert.ToInt32(textBox4.Text);
            int gramza = Convert.ToInt32(textBox2.Text);
            string opis = textBox3.Text;
            int idPriloga = Convert.ToInt32(comboBox1.GetItemText(comboBox1.SelectedItem).Substring(0, 1));
            int idRestorana = Convert.ToInt32(comboBox2.GetItemText(comboBox2.SelectedItem).Substring(0, 1));
            foreach (var item in listBox2.Items)
            {
                dodaci.Add(Convert.ToInt32(item.ToString().Substring(0, 1)));
            }


            foreach (Jelo a in listaCitaj)
            {
                if (a.Id == idH)
                {
                    a.Naziv = naziv;
                    a.Cena = cena;
                    a.Gramaza = gramza;
                    a.Opis = opis;
                    a.IdPrilog = idPriloga;
                    a.IdRestoran = idRestorana;
                    var theString = string.Join(" ", dodaci.ToArray());
                    a.Dodaci = theString;

                }

            }

            using (Stream stream = File.Open("jelo.bin", FileMode.OpenOrCreate))
            {
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(stream, listaCitaj);
            }
            MessageBox.Show("jelo je  AZURIRANo!!!");

           JelaForma jeloForma = new JelaForma();
            jeloForma.Show();
            this.Close();

        }

    

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;


            string value = listBox1.GetItemText(listBox1.SelectedItem);



            using (Stream fileStream = File.OpenRead("jelo.bin"))
            {
                BinaryFormatter binform = new BinaryFormatter();
                listaCitaj = (List<Jelo>)binform.Deserialize(fileStream);

            }

            foreach (Jelo a in listaCitaj)
            {

                if (a.Naziv == value)
                {
                    textBox1.Text = a.Naziv;
                    textBox3.Text = a.Opis;
                    textBox2.Text = a.Gramaza.ToString();
                    textBox4.Text = a.Cena.ToString();
                    comboBox1.SelectedItem = a.IdPrilog;
                    comboBox2.SelectedItem = a.IdRestoran;
                    comboBox3.SelectedItem = a.Dodaci;
                    idH = a.Id;


                }


            }


        }

        private void button3_Click(object sender, EventArgs e)
        {



            string value = listBox1.GetItemText(listBox1.SelectedItem);

            if (value == null)
            {

                MessageBox.Show("Niste izabrali jelo");
            }
            else
            {

                for (int i = 0; i < listaCitaj.Count; i++)
                {


                    if (listaCitaj[i].Naziv == value)
                    {

                        listaCitaj.RemoveAt(i);
                        break;
                    }


                }

                using (Stream stream = File.Open("jelo.bin", FileMode.OpenOrCreate))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, listaCitaj);
                }
                MessageBox.Show("Jeloje obrisano!!!!");

                JelaForma prilogForma = new JelaForma();
                prilogForma.Show();
                this.Close();




            }


        }
    }
}
