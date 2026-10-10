using System;

namespace Modelo.Modelo
{

    // Para manejar los NULL de la base de datos
    public static class Nulos
    {

        public static string Leer(object valor)
        {
            if (valor == DBNull.Value) return "";
            return valor.ToString();
        }

        public static int LeerEntero(object valor)
        {
            if (valor == DBNull.Value) return 0;
            return Convert.ToInt32(valor);
        }

        public static object Guardar(string texto)
        {
            if (texto == null) return DBNull.Value;
            if (texto.Trim().Length == 0) return DBNull.Value;
            return texto.Trim();
        }

        public static object GuardarId(int id)
        {
            if (id <= 0) return DBNull.Value;
            return id;
        }

        public static object GuardarFecha(DateTime? fecha)
        {
            if (fecha == null) return DBNull.Value;
            return fecha.Value.Date;
        }
    }
}
