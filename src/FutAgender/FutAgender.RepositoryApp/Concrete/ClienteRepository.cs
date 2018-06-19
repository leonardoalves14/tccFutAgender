using Dapper;
using FutAgender.RepositoryApp.Abastract;
using FutAgender.RepositoryApp.Entities;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace FutAgender.RepositoryApp.Concrete
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly string ConnString = ConfigurationManager.ConnectionStrings["SocietyAgendorConnectionString"].ConnectionString;

        public List<Cliente> GetClientes()
        {
            var usuarios = new List<Cliente>();

            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                conn.Open();
                usuarios.AddRange(conn.Query<Cliente>("spsCliente"));
            }

            return usuarios;
        }
    }
}
