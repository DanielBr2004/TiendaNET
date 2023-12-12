using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;
using System.Data.SqlClient;
namespace BOL
{
    public class Categoria
    {
        DBAccess conexion = new DBAccess();
        public DataTable lista() 
        {

            return conexion.listarDatos("spu_categorias_lsitar");
        }
    }
}
