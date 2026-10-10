using System.Data.SqlClient;

namespace Modelo.Modelo
{

    // Mensajes de error que se le muestran al usuario según el error de SQL
    public static class Errores
    {

        public static string Codigo(SqlException sql)
        {

            if (sql.Number == 2627) return "ERR-SQL-002";
            if (sql.Number == 2601) return "ERR-SQL-002";
            if (sql.Number == 547) return "ERR-SQL-003";
            if (sql.Number == 53) return "ERR-SQL-001";
            if (sql.Number == 40) return "ERR-SQL-001";
            if (sql.Number == -1) return "ERR-SQL-001";
            if (sql.Number == 2) return "ERR-SQL-001";
            if (sql.Number == 233) return "ERR-SQL-001";
            if (sql.Number == 258) return "ERR-SQL-001";
            if (sql.Number == 1225) return "ERR-SQL-001";
            if (sql.Number == 10054) return "ERR-SQL-001";
            if (sql.Number == 10060) return "ERR-SQL-001";
            if (sql.Number == 10061) return "ERR-SQL-001";
            if (sql.Number == 11001) return "ERR-SQL-001";
            if (sql.Number == 18452) return "ERR-SQL-001";
            if (sql.Number == 4060) return "ERR-SQL-008";
            if (sql.Number == 18456) return "ERR-SQL-008";
            if (sql.Number == -2) return "ERR-SQL-005";
            if (sql.Number == 208) return "ERR-SQL-004";
            if (sql.Number == 207) return "ERR-SQL-004";
            if (sql.Number == 8115) return "ERR-SQL-009";
            if (sql.Number == 8152) return "ERR-SQL-010";
            if (sql.Number == 2628) return "ERR-SQL-010";
            if (sql.Number == 1205) return "ERR-SQL-011";

            return "ERR-SQL-006";
        }

        public static string Mensaje(string codigo)
        {
            switch (codigo)
            {
                case "ERR-SQL-001":
                    return "No se pudo conectar con la base de datos.\n" +
                           "Revisa que el servicio SQL Server (SQLEXPRESS) esté iniciado.";

                case "ERR-SQL-002":
                    return "Ese dato ya existe y no se puede repetir.";

                case "ERR-SQL-003":
                    return "Ese dato está unido a otro registro: no se puede eliminar si otro lo usa,\n" +
                           "ni guardar si apunta a algo que no existe.";

                case "ERR-SQL-004":
                    return "La consulta pide una tabla o una columna que no existe.";

                case "ERR-SQL-005":
                    return "La base de datos tardó demasiado en responder.";

                case "ERR-SQL-006":
                    return "La base de datos rechazó la operación.";

                case "ERR-SQL-007":
                    return "La base de datos rechazó el dato porque rompe una regla del negocio.";

                case "ERR-SQL-008":
                    return "El servidor responde, pero la base de datos SIGMA no existe o tu usuario de Windows\n" +
                           "no tiene permiso para usarla. Ejecuta el script SIGMA_Script.sql para crearla.";

                case "ERR-SQL-009":
                    return "Un número es demasiado grande para guardarlo en la base de datos.";

                case "ERR-SQL-010":
                    return "Un texto es demasiado largo para guardarlo en la base de datos.";

                case "ERR-SQL-011":
                    return "Otro usuario estaba guardando lo mismo en ese momento.\n" +
                           "Revisa cómo quedó el registro y vuelve a intentar.";

                case "ERR-VAL-001":
                    return "Hay campos obligatorios sin llenar.";

                case "ERR-VAL-002":
                    return "Un dato está escrito en un formato incorrecto.";

                case "ERR-VAL-003":
                    return "Un número está fuera del rango permitido.";

                case "ERR-APP-001":
                    return "Ocurrió un error inesperado y la acción no se completó.";

                case "ERR-APP-002":
                    return "Ocurrió un error grave y SIGMA se tiene que cerrar.\n" +
                           "Lo que ya estaba guardado en la base de datos no se pierde.";

                default:
                    return "Ocurrió un error inesperado en la aplicación.";
            }
        }

        public static string Texto(SqlException ex)
        {
            string codigo = Codigo(ex);
            return Mensaje(codigo) + "\n\nCódigo del error: " + codigo;
        }

        public static string Regla(string mensaje)
        {
            return mensaje + "\n\nCódigo del error: ERR-SQL-007";
        }
    }
}
