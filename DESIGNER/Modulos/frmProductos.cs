using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BOL;
using DESIGNER.tools;
using ENTITIES;
namespace DESIGNER.Modulos
{
    public partial class frmProductos : Form
    {   /// <summary>
    /// llamamos
    /// </summary>
        Producto producto = new Producto();
        Categoria categroia = new Categoria();
        Subcategoria subcategoria = new Subcategoria();
        Marca marca = new Marca();


        Productos productos = new Productos();

        //bandera=variable logica que controla estados;
        bool categoriasListas = false;
        public frmProductos()
        {
            InitializeComponent();
        }
        private void actualizarmarcas()
        {

            cbomarca.DataSource = marca.listar();
            cbomarca.Refresh();
            cbomarca.DisplayMember = "marca"; //mostrar
            cbomarca.ValueMember = "idmarca"; //pk(guarda)
            cbomarca.Refresh();
        }
        private void actualizarProducto() 
        {
            gridproductos.DataSource = producto.listar();
            gridproductos.Refresh();
        }
        private void actualizarcategorias() 
        {
            cbocategoria.DataSource = categroia.lista();
            cbocategoria.Refresh();
            cbocategoria.DisplayMember = "categoria";
            cbocategoria.ValueMember = "idcategoria";
            cbocategoria.Refresh();
              
           

        }

        
        private void frmProductos_Load(object sender, EventArgs e)
        {
            actualizarProducto();
            actualizarmarcas();
            actualizarcategorias();

            gridproductos.Columns[0].Visible = false;
            
            categoriasListas = true;
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cbomarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cbocategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (categoriasListas) 
            {
                //invocar al metodo que carga las subcategorias
                int idcategoria = Convert.ToInt32(cbocategoria.SelectedValue.ToString());
                cbosubcateoria.DataSource = subcategoria.listar(idcategoria);
                cbosubcateoria.DisplayMember = "subcategoria";
                cbosubcateoria.ValueMember = "idsubcategoria";
                cbosubcateoria.Refresh();
                cbosubcateoria.Text = "";
            }
           
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtgarantia_TextChanged(object sender, EventArgs e)
        {

        }
        private void limpiarinterfaz() 
        {
            cbomarca.Text = "";
            cbocategoria.Text="";
            cbosubcateoria.Text = "";
            txtdescripcion.Clear();
            txtgarantia.Clear();
            txtprecio.Clear();
            txtstock.Clear();
        
        }
        private void btnguardar_Click(object sender, EventArgs e)
        {
            if (Aviso.Preguntar("Desea registrar el producto?") == DialogResult.Yes)
            {

                productos.idmarca = Convert.ToInt32(cbomarca.SelectedValue.ToString());
                productos.idsubcategoria = Convert.ToInt32(cbosubcateoria.SelectedValue.ToString());
                productos.descripcion = txtdescripcion.Text;
                productos.precio = Convert.ToDouble(txtprecio.Text);
                productos.garantia = Convert.ToInt32(txtgarantia.Text);
                productos.stock= Convert.ToInt32(txtstock.Text);

                if (producto.registrar(productos) > 0)
                {
                    Aviso.Informar("Registro realizado");
                    actualizarProducto();
                    limpiarinterfaz();

                }
                else 
                {
                    Aviso.Advertir("No se puede realizar el registro");
                }
            }
            
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            //1.- Crear isntacia para reporte (crystall)
            Reportes.rptProductos reporte = new Reportes.rptProductos();

            //2.- asignar los datos al objeto reporte(creado en el paso)
            reporte.SetDataSource(producto.listar());
            reporte.Refresh();
            //3.-instanciar el formulario donde se mostraran ls resportes
            Reportes.Visordereportes formulario = new Reportes.Visordereportes();
            //4.- pasamos el repsorte al visor
            formulario.Visor.ReportSource = reporte;
            formulario.Refresh();
            //mostramos  el formualrio 
            formulario.ShowDialog();
        }

        private void txtprecio_TextChanged(object sender, EventArgs e)
        {

        }

        private void exportarDatos(string extension)
        {
            SaveFileDialog sd = new SaveFileDialog();
            sd.Filter = $"archivos en formato {extension.ToUpper()}|*.{extension.ToLower()}";
            sd.Title = "Reporte de products";

            if (sd.ShowDialog() == DialogResult.OK)
            {
                //creamos una version del reporte en formato pdf
                //1 instcion del objeto reporte(crystalreport)
                Reportes.rptProductos reporte = new Reportes.rptProductos();
                //2 asignar los datos al objeto reporte
                reporte.SetDataSource(producto.listar());
                reporte.Refresh();

                if (extension.ToUpper() == "PDF")
                {
                    reporte.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, sd.FileName);
                }
                else if (extension.ToUpper() == "XLSX")
                {
                    reporte.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.ExcelWorkbook, sd.FileName);
                }
               

                Aviso.Informar("se ha creado el reporte correctamente");

                Aviso.Informar(sd.FileName);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            exportarDatos("PDF");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            exportarDatos("XLSX");
        }

        private void gridproductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
