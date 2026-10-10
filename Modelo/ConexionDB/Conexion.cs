using System.Configuration;
using System.Data.SqlClient;

namespace Modelo.ConexionDB
{

    // Conexión a la base de datos SIGMA
    public static class Conexion
    {
        private const string CadenaPorDefecto =
            "Data Source=localhost\\SQLEXPRESS;Initial Catalog=SIGMA;Integrated Security=True;";

        // la cadena se puede cambiar en el App.config, si no está se usa la de arriba
        public static readonly string Cadena = LeerCadena();

        private static string LeerCadena()
        {
            try
            {
                ConnectionStringSettings configurada = ConfigurationManager.ConnectionStrings["SIGMA"];
                if (configurada == null) return CadenaPorDefecto;
                if (configurada.ConnectionString.Trim().Length == 0) return CadenaPorDefecto;
                return configurada.ConnectionString;
            }
            catch (ConfigurationException)
            {
                return CadenaPorDefecto;
            }
        }

        public static SqlConnection Abrir()
        {
            SqlConnection con = new SqlConnection(Cadena);
            con.Open();
            return con;
        }
    }
}
