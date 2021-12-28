using MvcCalendario.Business.Models;
using System;
using System.Threading.Tasks;

namespace MvcCalendario.Business.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<Cliente> ObterClienteContato(Guid id);

        Task<Cliente> ObterClienteEndereco(Guid id);

    }
}
