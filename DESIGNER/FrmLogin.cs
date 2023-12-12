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
using DESIGNER.tools;
namespace DESIGNER
{
    public partial class FrmLogin : Form
    {

        Usuario usuario = new Usuario();
        DataTable dtRpta = new DataTable();
        

        public FrmLogin()
        {
            InitializeComponent();
           
        }
        private void Login()
        {

            if (txtcorreo.Text.Trim() == string.Empty)
            {
                ErrorLogin.SetError(txtcorreo, "Ingrese su Email");
                txtcorreo.Focus();
            }
            else
            {
                ErrorLogin.Clear();
                if (txtclave.Text.Trim() == string.Empty)
                {
                    ErrorLogin.SetError(txtclave, "Ingrese el Contraseña");
                    txtclave.Focus();
                }
                else
                {
                    ErrorLogin.Clear();
                    //Los datos fueron validados
                    dtRpta = usuario.iniciarSesion(txtcorreo.Text);

                    if (dtRpta.Rows.Count > 0)
                    {
                        string claveEncrptada = dtRpta.Rows[0][4].ToString();
                        string apellidos = dtRpta.Rows[0][1].ToString();
                        string nombres = dtRpta.Rows[0][2].ToString();
                        if (Crypter.CheckPassword(txtclave.Text, claveEncrptada))
                        {
                            Aviso.Informar($"Bienvenido{apellidos}{nombres}");
                            frmMain frmMain = new frmMain();
                            frmMain.Show(); //Abre el formulario principal
                            this.Hide(); //Login se oculta
                        }
                        else
                        {
                            Aviso.Advertir("Error en la contraseña");
                        }

                    }
                    else
                    {
                        Aviso.Advertir("El usuario no existe");
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            //txtclave.Text = Crypter.Blowfish.Crypt("SENATI123");
            // Permite generar clave encriptada
            //return;
            Login();

        }

        private void txtcorreo_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtclave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==Convert.ToChar(Keys.Enter)) 
            {
                Login();
            }
        }
    }
}
