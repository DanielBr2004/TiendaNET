using System.Windows.Forms;
using CryptSharp;
namespace DESIGNER
{
    internal class frmLogin1 : Form
    {
        private Label label1;
        private Label label3;
        private Button btnIngresar;
        private Button btnFinalizar;
        private TextBox txtcorreo;
        private TextBox txtClave;
        private Label label2;

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.txtcorreo = new System.Windows.Forms.TextBox();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Acceso al Sistema ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Correo Electrónico";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Clave de acceso";
            // 
            // btnIngresar
            // 
            this.btnIngresar.Location = new System.Drawing.Point(43, 275);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(243, 22);
            this.btnIngresar.TabIndex = 3;
            this.btnIngresar.Text = "Iniciar Sesión";
            this.btnIngresar.UseVisualStyleBackColor = true;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.Location = new System.Drawing.Point(43, 303);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(243, 23);
            this.btnFinalizar.TabIndex = 4;
            this.btnFinalizar.Text = "Finalizar";
            this.btnFinalizar.UseVisualStyleBackColor = true;
            // 
            // txtcorreo
            // 
            this.txtcorreo.Location = new System.Drawing.Point(43, 114);
            this.txtcorreo.Name = "txtcorreo";
            this.txtcorreo.Size = new System.Drawing.Size(243, 20);
            this.txtcorreo.TabIndex = 5;
            // 
            // txtClave
            // 
            this.txtClave.Location = new System.Drawing.Point(43, 182);
            this.txtClave.Name = "txtClave";
            this.txtClave.Size = new System.Drawing.Size(243, 20);
            this.txtClave.TabIndex = 6;
            // 
            // frmLogin
            // 
            this.ClientSize = new System.Drawing.Size(316, 363);
            this.Controls.Add(this.txtClave);
            this.Controls.Add(this.txtcorreo);
            this.Controls.Add(this.btnFinalizar);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmLogin";
            this.Text = "frmLogin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void label2_Click(object sender, System.EventArgs e)
        {
            
        }

        private void btnIngresar_Click(object sender, System.EventArgs e)
        {
            txtClave.Text = Crypter.Blowfish.Crypt("SENATI123");
        }
    }
}