using MvcCalendario.Business.Models;
using System;
using System.Threading.Tasks;

namespace MvcCalendario.Business.Interfaces
{
    public interface IAgendaRepository : IRepository<Agenda>
    {
        Task<Agenda> ObterAgendaCliente(Guid id);
    }
}
