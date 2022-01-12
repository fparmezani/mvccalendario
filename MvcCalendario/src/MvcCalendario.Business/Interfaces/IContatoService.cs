using MvcCalendario.Business.Models;
using System;
using System.Threading.Tasks;


namespace MvcCalendario.Business.Interfaces
{
    public interface IContatoService : IDisposable
    {
        Task Adicionar(Contato contato);
        Task Atualizar(Contato contato);
        Task Remover(Guid id);
    }
}
