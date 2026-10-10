using System;
using System.Data;
using System.Data.SqlClient;
using Modelo.ConexionDB;

namespace Modelo.Modelo
{

    public static class ClienteDatos
    {
        private const string SqlBase =
            "SELECT IdCliente, Nombre, Nit, Contacto, Telefono, Correo, Direccion FROM Clientes";

        public static Cliente[] Listar()
        {
            try
            {
                DataTable tabla = new DataTable();
                SqlDataAdapter adaptador = new SqlDataAdapter(SqlBase + " ORDER BY Nombre", Conexion.Cadena);
                adaptador.Fill(tabla);
                Cliente[] lista = new Cliente[tabla.Rows.Count];

                for (int i = 0; i < tabla.Rows.Count; i++)
                    lista[i] = LeerFila(tabla.Rows[i]);
                return lista;
            }
            catch (SqlException ex)
            {
                throw new Exception(Errores.Texto(ex), ex);
            }
        }

        // revisa que no haya otro cliente con el mismo nombre o NIT
        public static bool Existe(string columna, string valor, int exceptoId)
        {
            if (columna != "Nombre") columna = "Nit";

            try
            {
                using (SqlConnection con = Conexion.Abrir())
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM Clientes WHERE " + columna + " = @Valor AND IdCliente <> @Id", con))
                {
                    cmd.Parameters.AddWithValue("@Valor", valor);
                    cmd.Parameters.AddWithValue("@Id", exceptoId);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(Errores.Texto(ex), ex);
            }
        }

        public static int Insertar(Cliente c)
        {
            try
            {
                string sql = @"INSERT INTO Clientes (Nombre, Nit, Contacto, Telefono, Correo, Direccion)
                               VALUES (@Nombre, @Nit, @Contacto, @Telefono, @Correo, @Direccion);
                               SELECT CAST(SCOPE_IDENTITY() AS INT);";

                using (SqlConnection con = Conexion.Abrir())
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    PonerParametros(cmd, c);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(Errores.Texto(ex), ex);
            }
        }

        public static int Actualizar(Cliente c)
        {
            try
            {
                string sql = @"UPDATE Clientes
                               SET Nombre = @Nombre, Nit = @Nit, Contacto = @Contacto,
                                   Telefono = @Telefono, Correo = @Correo, Direccion = @Direccion
                               WHERE IdCliente = @Id";

                using (SqlConnection con = Conexion.Abrir())
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    PonerParametros(cmd, c);
                    cmd.Parameters.AddWithValue("@Id", c.IdCliente);
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(Errores.Texto(ex), ex);
            }
        }

        public static int Eliminar(int idCliente)
        {
            try
            {
                using (SqlConnection con = Conexion.Abrir())
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Clientes WHERE IdCliente = @Id", con))
                {
                    cmd.Parameters.AddWithValue("@Id", idCliente);
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(Errores.Texto(ex), ex);
            }
        }

        private static void PonerParametros(SqlCommand cmd, Cliente c)
        {
            cmd.Parameters.AddWithValue("@Nombre",    c.Nombre);
            cmd.Parameters.AddWithValue("@Nit",       c.Nit);
            cmd.Parameters.AddWithValue("@Contacto",  c.Contacto);
            cmd.Parameters.AddWithValue("@Telefono",  c.Telefono);
            cmd.Parameters.AddWithValue("@Correo",    Nulos.Guardar(c.Correo));
            cmd.Parameters.AddWithValue("@Direccion", c.Direccion);
        }

        private static Cliente LeerFila(DataRow fila)
        {
            Cliente cliente = new Cliente();
            cliente.IdCliente = Convert.ToInt32(fila["IdCliente"]);
            cliente.Nombre = fila["Nombre"].ToString();
            cliente.Nit = fila["Nit"].ToString();
            cliente.Contacto = fila["Contacto"].ToString();
            cliente.Telefono = fila["Telefono"].ToString();
            cliente.Correo = Nulos.Leer(fila["Correo"]);
            cliente.Direccion = fila["Direccion"].ToString();
            return cliente;
        }
    }
}
