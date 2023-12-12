using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CryptSharp;
using BOL;
using ENTITIES;
using DESIGNER.tools;
namespace DESIGNER.Modulos
{
    public partial class frmUsuario : Form
    {   
        //Objeto "usuario" contiene las funciones logicas (crud)
        Usuario usuario = new Usuario();
        //contiene los datos(apellidos,nombres)
        Empresa entUsuario = new Empresa();

        string nivelacceso = "INV";

        DataView dv;

        public frmUsuario()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuarda_Click(object sender, EventArgs e)
        {
            if (Aviso.Preguntar("Estas seguro de guardar")== DialogResult.Yes) 
            {
                string claveEncriptada = Crypter.Blowfish.Crypt(txtclave.Text.Trim());
                entUsuario.apellidos = txtapellidos.Text;
                entUsuario.nombres = txtnombres.Text;
                entUsuario.email = txtemail.Text;
                entUsuario.claveacceso = claveEncriptada;
                entUsuario.nivelacceso = nivelacceso;

                if (usuario.Registrar(entUsuario) > 0)
                {
                    reiniciarInterfaz();
                    actualizarDatos();
                    Aviso.Informar("Nuevo usuario Registrado");
                }
                else
                {
                    Aviso.Informar("No hemos podido terminar el registro");
                }
                
            }
        }
        private void actualizarDatos() 
        {
            dv = new DataView(usuario.Listar());
            gridUsuarios.DataSource = dv;
            gridUsuarios.Refresh();

            gridUsuarios.Columns[0].Visible = false;
            gridUsuarios.Columns[4].Visible = false;
            gridUsuarios.Columns[1].Width = 200;
            gridUsuarios.Columns[2].Width = 200;
            gridUsuarios.Columns[3].Width = 200;
            gridUsuarios.Columns[5].Width = 122;

            //filas (cebreadas)
            gridUsuarios.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
           
        }

        private void reiniciarInterfaz() 
        {
            txtapellidos.Clear();
            txtnombres.Clear();
            txtclave.Clear();
            txtemail.Clear();
            optInvitado.Checked = true;
            nivelacceso = "INV";
            txtapellidos.Focus();

        }
        private void optAdministrador_CheckedChanged(object sender, EventArgs e)
        {
            nivelacceso = "ADM";
        }

        private void optInvitado_CheckedChanged(object sender, EventArgs e)
        {
            nivelacceso ="INV";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmUsuario_Load(object sender, EventArgs e)
        {
            actualizarDatos();
        }

        private void gridUsuarios_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            gridUsuarios.ClearSelection();
        }

        private void txtbuscar_KeyUp(object sender, KeyEventArgs e)
        {
            dv.RowFilter = " apellidos LIKE '%"+txtbuscar.Text+ "%' OR nombres LIKE '%" + txtbuscar.Text + "%'";
           
        }
    }
}
