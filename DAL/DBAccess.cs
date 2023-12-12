using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
namespace DAL

{
    public class DBAccess
    {
        private SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["AccesoTiendaNET"].ConnectionString);

        public SqlConnection getconexion()
        {
            return this.conexion;
        }
        public void abrirConexion()
        {
            if (this.conexion.State == ConnectionState.Closed)
            {
                this.conexion.Open();
            }

        }
        public void cerrarConecion()
        {
            if (this.conexion.State == ConnectionState.Open)
            {
                this.conexion.Close();
            }
        }

        /// <summary>
        /// metodo general que retorna una coleccion de datos de una consulta 
        /// que no tiene variables de entrada
        /// </summary>
        /// <param name="spu">nombre del procedimiento</param>
        /// <returns>Coleccion de datos de tipo Datatable</returns>
        public DataTable listarDatos( string spu) 
        {
            DataTable dt = new DataTable();
            this.abrirConexion();
            SqlCommand comando = new SqlCommand(spu, this.getconexion());
            comando.CommandType = CommandType.StoredProcedure;
            dt.Load(comando.ExecuteReader());
            this.cerrarConecion();
            return dt;
        }
        public DataTable listarDatosVariable(string spu, string nombrevariable, object valorvariable) 
        {
            DataTable dt = new DataTable();
            this.abrirConexion();
            SqlCommand comando = new SqlCommand(spu, this.getconexion());
            comando.CommandType = CommandType.StoredProcedure;

            //agregar parametro de entrada(variable)
            comando.Parameters.AddWithValue(nombrevariable,valorvariable);
            dt.Load(comando.ExecuteReader());
            this.cerrarConecion();
            return dt;
        }
       
    }        
}
