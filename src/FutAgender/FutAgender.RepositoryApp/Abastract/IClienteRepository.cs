using FutAgender.RepositoryApp.Entities;
using System.Collections.Generic;

namespace FutAgender.RepositoryApp.Abastract
{
    public interface IClienteRepository
    {
        List<Cliente> GetClientes();
    }
}
