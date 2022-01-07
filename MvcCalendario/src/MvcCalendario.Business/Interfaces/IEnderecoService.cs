using MvcCalendario.Business.Models;
using System;
using System.Threading.Tasks;

namespace MvcCalendario.Business.Interfaces
{
    public interface IEnderecoService : IDisposable
    {
        Task Adicionar(Endereco endereco);
        Task Atualizar(Endereco endereco);
        Task Remover(Guid id);
    }
}
