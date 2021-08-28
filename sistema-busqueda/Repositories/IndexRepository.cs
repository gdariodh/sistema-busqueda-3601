using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace sistema_busqueda.Repositories
{
    public class IndexRepository
    {
        private readonly string ConnectionString = "server=localhost;database=sistema_busqueda_aiep;Integrated Security=true";

        public bool ValidarUsuario(string usuario, string password)
        {
            bool resultado = false; 
            using SqlConnection sql = new SqlConnection(ConnectionString);
            //using SqlCommand cmd = new SqlCommand("select count(*) from usuarios where usuario= '" + usuario + "' and [password] = '" + password + "'", sql);

            // procedimientos almacenados
            using SqlCommand cmd = new SqlCommand("sp_check_usuario", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@usuario", usuario));
            cmd.Parameters.Add(new SqlParameter("@password", password));
            // termina consulta con procedimientos almacenados
            int valor;

            sql.Open();

            valor = (int)cmd.ExecuteScalar();

            if(valor > 0)
            {
                resultado = true;
            }

            return resultado;
        }
    }
}
