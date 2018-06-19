using Dapper;
using FutAgender.RepositoryApp.Abstract;
using FutAgender.RepositoryApp.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FutAgender.RepositoryApp.Concrete
{
    public class ClienteRepository : IClienteRepository
    {
        public async Task<List<Cliente>> GetClientes()
        {
            var clientes = new List<Cliente>();

            using (SqlConnection conn = new SqlConnection())
            {
                await conn.OpenAsync();

                clientes.AddRange(await conn.QueryAsync<Cliente>("spsCliente"));
            }

            return clientes;
        }
    }
}
