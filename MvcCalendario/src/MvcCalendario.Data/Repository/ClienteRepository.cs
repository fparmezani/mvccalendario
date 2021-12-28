using Microsoft.EntityFrameworkCore;
using MvcCalendario.Business.Interfaces;
using MvcCalendario.Business.Models;
using MvcCalendario.Data.Context;
using System;
using System.Threading.Tasks;

namespace MvcCalendario.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {

        public ClienteRepository(MvcContext context) : base(context) { }

        public async Task<Cliente> ObterClienteContato(Guid id)
        {
            return await Db.Clientes.AsNoTracking().Include(f => f.Contato)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Cliente> ObterClienteEndereco(Guid id)
        {
            return await Db.Clientes.AsNoTracking().Include(f => f.Endereco)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
