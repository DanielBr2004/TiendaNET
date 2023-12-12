using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;
using System.Data.SqlClient;
using ENTITIES;
namespace BOL

{
    public class Usuario
    {
        DBAccess conexion = new DBAccess();

        /// <summary>
        /// Inicia sesion usando datos del servidor.
        /// </summary>
        /// <param name="email">Identificador o nombre de uusario</param>
        /// <returns>Objeto datatable conteniendo toda la fila(varios canpos)</returns>
        public DataTable iniciarSesion(string email)
        {
            //1.- Crear un objeto que contendra el resultado
            DataTable dt = new DataTable();
            //2.- abrir conexion
            conexion.abrirConexion();
            //3.- Objeto para enviar consulta 
            SqlCommand comando = new SqlCommand("spu_usuarios_login", conexion.getconexion());

            //4.- tipo de comando (procedimiento almacenado)
            comando.CommandType = CommandType.StoredProcedure;

            //5.- pasar  la(s) variable(s)
            comando.Parameters.AddWithValue("email", email);

            //6.- Ejecutar y obtener los datos.
            dt.Load(comando.ExecuteReader());

            //7.- Cerrar
            conexion.cerrarConecion();


            //8. retornamos el objeto con la info
            return dt;
        }

        public DataTable login(string email) 
        {
            
            return conexion.listarDatosVariable("spu_usuarios_login", "@email",email);
    
        }
        public int Registrar(Empresa entidad)
        {
            int totalregistros = 0;
            SqlCommand comando = new SqlCommand("spu_usuarios_registrar", conexion.getconexion());
            comando.CommandType = CommandType.StoredProcedure;
            conexion.abrirConexion();
            try
            {
                comando.Parameters.AddWithValue("@apellidos", entidad.apellidos);
                comando.Parameters.AddWithValue("@nombres", entidad.nombres);
                comando.Parameters.AddWithValue("@email", entidad.email);
                comando.Parameters.AddWithValue("@claveacceso", entidad.claveacceso);
                comando.Parameters.AddWithValue("@nivelacceso", entidad.nivelacceso);

                totalregistros = comando.ExecuteNonQuery();
            }
            catch
            {
                totalregistros = -1;
            }
            finally
            {
                conexion.cerrarConecion();
            }
            return totalregistros;

            
        }public DataTable Listar() 
        {
            DataTable dt = new DataTable();
            SqlCommand comando = new SqlCommand("spu_usuarios_listar", conexion.getconexion());
            comando.CommandType = CommandType.StoredProcedure;

            conexion.abrirConexion();
            dt.Load(comando.ExecuteReader());
            conexion.cerrarConecion();
            return dt;
        }

        
    }
}
