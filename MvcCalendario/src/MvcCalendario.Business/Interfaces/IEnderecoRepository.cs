using MvcCalendario.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MvcCalendario.Business.Interfaces
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        Task<IEnumerable<Endereco>> ObterEnderecosPorCliente(Guid clienteId);
    }
}
