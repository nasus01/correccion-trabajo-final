using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVC_vista_
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void fpbar()
        {
            pgbcargainicial.Increment(1);
            lblcargando.Text =  pgbcargainicial.Value.ToString() + "%";
            if (pgbcargainicial.Value == pgbcargainicial.Maximum)
            {
                timer1.Stop();
                MessageBox.Show("BIENVENIDO A LA BASE DE DATOS PARKINGLOT.");
                Form2 form2 = new Form2();
                form2.Show();
               this.Hide();

            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {



            fpbar();




        }
    }
}
