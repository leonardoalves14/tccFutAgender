using FutAgender.RepositoryApp.Entities;
using System.Collections.Generic;

namespace FutAgender.RepositoryApp.Abstract
{
    public interface IClienteRepository
    {
        List<Cliente> GetClientes();
    }
}
