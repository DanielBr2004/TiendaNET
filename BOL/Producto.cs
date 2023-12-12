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
   public  class Producto
    {
        DBAccess conexion= new DBAccess();
        public DataTable listar() 
        {
            return conexion.listarDatos("spu_productis_listar");
        }

        public int registrar(Productos entidad)
        {
            int registros = 0;
            
            SqlCommand comando = new SqlCommand("spu_productos_registrar", conexion.getconexion());
            comando.CommandType = CommandType.StoredProcedure;
            conexion.abrirConexion();
            try
            {
               
                
                comando.Parameters.AddWithValue("@idmarca",entidad.idmarca);
                comando.Parameters.AddWithValue("@idsubcategoria", entidad.idsubcategoria);
                comando.Parameters.AddWithValue("@descripcion", entidad.descripcion);
                comando.Parameters.AddWithValue("@garantia", entidad.garantia);
                comando.Parameters.AddWithValue("@precio", entidad.precio);
                comando.Parameters.AddWithValue("@stock", entidad.stock);
                registros = comando.ExecuteNonQuery();
            }
            catch
            {
                registros = -1;
            }
            finally 
            {
                conexion.cerrarConecion();
            }
            return registros;
        }

    }
}
