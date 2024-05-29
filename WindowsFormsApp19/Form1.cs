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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
          f2.Show();
                }

        private void button1_Click(object sender, EventArgs e)
        {
            string u = textBox1.Text;
            string p = textBox2.Text;
            
            List<Korisnik> lista;



            using (Stream fileStream = File.OpenRead("korisnik.bin"))
            {
                BinaryFormatter binform = new BinaryFormatter();
                lista = (List<Korisnik>)binform.Deserialize(fileStream);
            }
            Korisnik k=null;
            bool flag = false;
            foreach(Korisnik kor in lista)
            {

                if (u == kor.Username && p==kor.Password)
                {
                    k = kor;
                    flag = true;
                    break;
                }


            }

            if (flag)
            {
                if (k.VrstaKorisnika == "admin")
                {
                    AdminPanel a = new AdminPanel();
                    a.Show();
               
                }
                else
                {
                    Form4 f4 = new Form4(k.Id);
                    f4.Show();
             
                }
            }
            else
            {
                MessageBox.Show("Pogresan username/password");
            }


        }
    }
}
