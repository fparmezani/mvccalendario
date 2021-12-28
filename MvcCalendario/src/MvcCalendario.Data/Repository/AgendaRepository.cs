using Microsoft.EntityFrameworkCore;
using MvcCalendario.Business.Interfaces;
using MvcCalendario.Business.Models;
using MvcCalendario.Data.Context;
using System;
using System.Threading.Tasks;

namespace MvcCalendario.Data.Repository
{
    public class AgendaRepository : Repository<Agenda>, IAgendaRepository
    {
        public AgendaRepository(MvcContext context) : base(context) { }

        public async Task<Agenda> ObterAgendaCliente(Guid id)
        {
            return await Db.Agendas.AsNoTracking().Include(f => f.Cliente)
               .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
