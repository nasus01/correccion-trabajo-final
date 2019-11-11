using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CONTROLADOR.parking;

namespace MVC_vista_
{
    public partial class Form2 : System.Windows.Forms.Form
    {
        ParkingDTO parkingDTO = null;
        ParkingDAO parkingDAO = null;
        DataTable Dtt =null;



        public Form2()
        {
            InitializeComponent();

            ListarParking();
            label3.Visible = false;
            txtcodigo.Visible = false;
            btnguardarcambios.Enabled = false;
            btneliminar.Enabled = false;
            btncalcelar.Enabled = false;
            txtNombreusuario.MaxLength = 50;
            txtTvehiculo.MaxLength = 50;
            txtPlaca.MaxLength = 50;
        }

        public void ListarParking()

        {
            parkingDTO = new ParkingDTO();
            parkingDAO = new ParkingDAO(parkingDTO);
            Dtt = new DataTable();
            Dtt = parkingDAO.ListarParking();
            if (Dtt.Rows.Count > 0)
            {
                dtparking.DataSource = Dtt;

            }
            else
            {
                MessageBox.Show("no hay lista vehiculos");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void Guardar()
        {
            parkingDTO = new ParkingDTO();
            parkingDTO.setNombre(txtNombreusuario.Text);
            parkingDTO.setPlaca(int.Parse(txtPlaca.Text));
            parkingDTO.setTipov(txtTvehiculo.Text);
            parkingDAO = new ParkingDAO(parkingDTO);

            parkingDAO.Guardarvehiculo();
            MessageBox.Show("Registro Guardado");
        }

        public void GuardarCambios()
        {
            parkingDTO = new ParkingDTO();
            parkingDTO.setIdpark(int.Parse(txtcodigo.Text));
            parkingDTO.setNombre(txtNombreusuario.Text);
            parkingDTO.setPlaca(int.Parse(txtPlaca.Text));
            parkingDTO.setTipov(txtTvehiculo.Text);
            parkingDAO = new ParkingDAO(parkingDTO);

            parkingDAO.Guardarcambios();
            MessageBox.Show("Registro Modificado");
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            if (txtNombreusuario.Text.Trim()=="")
            {
                MessageBox.Show("oye hacker, intenta un dato valido");
                txtNombreusuario.Focus();
            }
            else
            {
                Guardar();
                ListarParking();
                txtNombreusuario.Clear();
                txtPlaca.Clear();
                txtTvehiculo.Clear();
                txtNombreusuario.Focus();

            }


           
        }

      

        private void btnguardarcambios_Click(object sender, EventArgs e)
        {

            if (txtNombreusuario.Text.Trim() == "")
            {
                MessageBox.Show("oye  intenta un dato valido");
                txtNombreusuario.Focus();
            }
            else
            {
                GuardarCambios();
                ListarParking();

                txtcodigo.Enabled = true;
                label3.Visible = false;
                txtcodigo.Visible = false;
                btnguardar.Enabled = true;
                btnguardarcambios.Enabled = false;
                btneliminar.Enabled = true;
                btncalcelar.Enabled = true;
                txtNombreusuario.Clear();
                txtPlaca.Clear();
                txtTvehiculo.Clear();
                txtNombreusuario.Focus();
                btnguardarcambios.Enabled = true;
            }
           
        }
        public void EliminarRegistro()
        {
            parkingDTO = new ParkingDTO();
            parkingDTO.setIdpark(int.Parse(txtcodigo.Text));
            parkingDAO = new ParkingDAO(parkingDTO);

            parkingDAO.Eliminar();
            MessageBox.Show("registro eliminado");
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            EliminarRegistro();
            ListarParking();

            txtcodigo.Enabled = true;
            label3.Visible = false;
            txtcodigo.Visible = false;
            btnguardar.Enabled = true;
            btnguardarcambios.Enabled = false;
            btneliminar.Enabled = true;
            btncalcelar.Enabled = true;
            txtNombreusuario.Clear();
            txtPlaca.Clear();
            txtTvehiculo.Clear();
            txtNombreusuario.Focus();
            btnguardarcambios.Enabled = true;

        }

        private void btncalcelar_Click(object sender, EventArgs e)
        {
            ListarParking();

            txtcodigo.Enabled = true;
            label3.Visible = false;
            txtcodigo.Visible = false;
            btnguardar.Enabled = true;
            btnguardarcambios.Enabled = false;
            btneliminar.Enabled = false;
            btncalcelar.Enabled = false;
            txtNombreusuario.Clear();
            txtPlaca.Clear();
            txtTvehiculo.Clear();
            txtNombreusuario.Focus();
            btnguardarcambios.Enabled = false;
        }

        private void dtparkin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label3.Visible = true;
            txtcodigo.Visible = true;
            txtcodigo.Enabled = false;

            txtcodigo.Text = dtparking.Rows[dtparking.CurrentRow.Index].Cells[0].Value.ToString();
            txtNombreusuario.Text = dtparking.Rows[dtparking.CurrentRow.Index].Cells[1].Value.ToString();
            txtPlaca.Text = dtparking.Rows[dtparking.CurrentRow.Index].Cells[2].Value.ToString();
            txtTvehiculo.Text = dtparking.Rows[dtparking.CurrentRow.Index].Cells[3].Value.ToString();

            btnguardar.Enabled = false;
            btnguardarcambios.Enabled = true;
            btneliminar.Enabled = true;
            btncalcelar.Enabled = true;
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
