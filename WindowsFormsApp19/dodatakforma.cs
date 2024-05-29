using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp19
{
    public partial class dodatakforma : Form
    {

        int idH;
        List<Dodatak> listaCitaj;//dohatanje liste dodataka
        public dodatakforma()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            string naziv = textBox1.Text;
            int cena =Convert.ToInt32(textBox2.Text);
            int gramza = Convert.ToInt32(textBox3.Text);

            List<Dodatak> lista;

            if (!File.Exists("dodatak.bin"))
            {
                List<Dodatak> lista2;
                using (Stream stream = File.Open("dodatak.bin", FileMode.OpenOrCreate))
                {
                    lista2 = new List<Dodatak>();
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream,lista2);
                }
                int idNew = 1;
                Dodatak d1 = new Dodatak(idNew, naziv, cena, gramza);
                lista2.Add(d1);
                using (Stream stream = File.Open("dodatak.bin", FileMode.OpenOrCreate))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, lista2);
                }
                MessageBox.Show("Dodatak je  dodat");


            }else
            {
                using (Stream fileStream = File.OpenRead("dodatak.bin"))
                {
                    BinaryFormatter binform = new BinaryFormatter();
                    lista = (List<Dodatak>)binform.Deserialize(fileStream);

                }

                int id=lista.Count+1;
                Dodatak d = new Dodatak(id, naziv, cena, gramza);
                lista.Add(d);

                using (Stream stream = File.Open("dodatak.bin", FileMode.OpenOrCreate))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, lista);
                }
                MessageBox.Show("Dodatak je  dodat");
            }


          
     

 


         

       


        }

        private void dodatakforma_Load(object sender, EventArgs e)
        {
            if (File.Exists("dodatak.bin"))
            {
                List<Dodatak> lista;

                using (Stream fileStream = File.OpenRead("dodatak.bin"))
                {
                    BinaryFormatter binform = new BinaryFormatter();
                    lista = (List<Dodatak>)binform.Deserialize(fileStream);

                }

                foreach(Dodatak a in lista)
                {

                    listBox1.Items.Add(a.Nazivdodatka);


                }
         
           
            }
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
       
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            string value = listBox1.GetItemText(listBox1.SelectedItem);

     

            using (Stream fileStream = File.OpenRead("dodatak.bin"))
            {
                BinaryFormatter binform = new BinaryFormatter();
                listaCitaj = (List<Dodatak>)binform.Deserialize(fileStream);

            }


            
foreach(Dodatak a in listaCitaj)
            {
      
                if (a.Nazivdodatka == value)
                {
                    textBox1.Text = a.Nazivdodatka;
                    textBox2.Text =a.Cena.ToString();
                    textBox3.Text = a.Gramaza.ToString();
                    idH = a.Id;
                }


            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            string naziv = textBox1.Text;
            int cena = Convert.ToInt32(textBox2.Text);
            int gramza = Convert.ToInt32(textBox3.Text);


            foreach(Dodatak a in listaCitaj)
            {
                if (a.Id == idH)
                {

                    a.Nazivdodatka = naziv;
                    a.Cena = cena;
                    a.Gramaza = gramza;
                }            
            
            }
            using (Stream stream = File.Open("dodatak.bin", FileMode.OpenOrCreate))
            {
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(stream, listaCitaj);
            }
            MessageBox.Show("Dodatak je  AZURIRAN!!!");
            
            dodatakforma dodatakforma=new dodatakforma();
            dodatakforma.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string value = listBox1.GetItemText(listBox1.SelectedItem);

            if (value == null)
            {

                MessageBox.Show("Niste izabrali dodatak1");
            }
            else
            {

     for(int i = 0; i <listaCitaj.Count; i++) {


                    if (listaCitaj[i].Nazivdodatka== value)
                    {

                        listaCitaj.RemoveAt(i);
                        break;
                    }

                
                }

                using (Stream stream = File.Open("dodatak.bin", FileMode.OpenOrCreate))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, listaCitaj);
                }
                MessageBox.Show("element je obrisan!!!!");

                dodatakforma dodatakforma = new dodatakforma();
                dodatakforma.Show();
                this.Close();




            }

        }
    }
}
