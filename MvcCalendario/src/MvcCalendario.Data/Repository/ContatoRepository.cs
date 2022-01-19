using Microsoft.EntityFrameworkCore;
using MvcCalendario.Business.Interfaces;
using MvcCalendario.Business.Models;
using MvcCalendario.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCalendario.Data.Repository
{
    public class ContatoRepository : Repository<Contato>, IContatoRepository
    {
        public ContatoRepository(MvcContext context) : base(context) { }

        public async Task<IEnumerable<Contato>> ObterContatosPorCliente(Guid clienteId)
        {
            return await Db.Contatos.AsNoTracking().Where(f => f.ClienteId == clienteId).ToListAsync();

        }

       
    }
}