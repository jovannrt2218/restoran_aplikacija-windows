using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp19
{
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Restoranforma d = new Restoranforma();
            d.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dodatakforma d = new dodatakforma();
            d.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrilogForma d = new PrilogForma();
            d.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            JelaForma d = new JelaForma();
            d.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Korisnikforma d = new Korisnikforma();  
            d.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            rezervacijaforma r=new rezervacijaforma();
            r.Show();
        }
    }
}
