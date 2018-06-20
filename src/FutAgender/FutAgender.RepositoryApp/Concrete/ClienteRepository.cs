using Dapper;
using FutAgender.RepositoryApp.Abstract;
using FutAgender.RepositoryApp.Entities;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace FutAgender.RepositoryApp.Concrete
{
    public class ClienteRepository : IClienteRepository
    {
        public List<Cliente> GetClientes()
        {
            var clientes = new List<Cliente>();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SocietyAgendorDb"].ConnectionString))
                {
                    conn.Open();
                    clientes.AddRange(conn.Query<Cliente>("spsCliente"));
                }

                return clientes;
            }
            catch (SqlException e)
            {
                throw e;
            }
        }
    }
}
