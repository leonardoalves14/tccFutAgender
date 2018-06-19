using FutAgender.RepositoryApp.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FutAgender.RepositoryApp.Abstract
{
    public interface IClienteRepository
    {
        Task<List<Cliente>> GetClientes();
    }
}
