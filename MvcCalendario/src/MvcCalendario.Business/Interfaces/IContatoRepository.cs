using MvcCalendario.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MvcCalendario.Business.Interfaces
{
    public interface IContatoRepository : IRepository<Contato>
    {
        Task<IEnumerable<Contato>> ObterContatosPorCliente(Guid clienteId);
    }
}
