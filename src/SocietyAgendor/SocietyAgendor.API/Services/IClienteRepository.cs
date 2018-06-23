using SocietyAgendor.API.Entities;
using System.Collections.Generic;

namespace SocietyAgendor.API.Services
{
    public interface IClienteRepository
    {
        List<Cliente> GetAllClientes();
        Cliente CreateCliente(Cliente model);
        void UpdateCliente(Cliente model);
        bool ClienteExists(int clienteId);
    }
}
