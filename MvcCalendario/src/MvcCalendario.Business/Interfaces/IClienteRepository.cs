using MvcCalendario.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MvcCalendario.Business.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<Cliente> ObterClienteContatos(Guid id);

        Task<IEnumerable<Cliente>> ObterClienteContatos();
        Task<IEnumerable<Cliente>> ObterClienteEnderecos();

        Task<Cliente> ObterClienteCompleto(Guid id);

        Task<Cliente> ObterClienteEnderecos(Guid id);

        Task RemoverEnderecosPorCliente(Guid id);
        Task RemoverContatosPorCliente(Guid id);

    }
}
