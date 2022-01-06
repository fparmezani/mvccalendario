using MvcCalendario.Business.Models;
using System;
using System.Threading.Tasks;

namespace MvcCalendario.Business.Interfaces
{
    public interface IClienteService : IDisposable
    {
        Task Adicionar(Cliente cliente);
        Task Atualizar(Cliente cliente);
        Task Remover(Guid id);
    }
}
