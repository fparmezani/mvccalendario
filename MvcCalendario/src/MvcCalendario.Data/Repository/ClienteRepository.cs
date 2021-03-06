using Microsoft.EntityFrameworkCore;
using MvcCalendario.Business.Interfaces;
using MvcCalendario.Business.Models;
using MvcCalendario.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MvcCalendario.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {

        public ClienteRepository(MvcContext context) : base(context) { }

        public async Task<Cliente> ObterClienteContatos(Guid id)
        {
            return await Db.Clientes.AsNoTracking().Include(f => f.Contatos)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Cliente>> ObterClienteContatos()
        {
            return await Db.Clientes.AsNoTracking().Include(f => f.Contatos).ToListAsync();
        }

        public async Task<IEnumerable<Cliente>> ObterClienteEnderecos()
        {
            return await Db.Clientes.AsNoTracking().Include(f => f.Enderecos).ToListAsync();
        }

        public async Task<Cliente> ObterClienteCompleto(Guid Id)
        {
            var cliente = await Db.Clientes.AsNoTracking()
                .Include(f => f.Contatos)
                .Include(f => f.Enderecos)
                .FirstOrDefaultAsync(p => p.Id == Id);

            return cliente;

        }

        public async Task<Cliente> ObterClienteEnderecos(Guid id)
        {
            return await Db.Clientes.AsNoTracking().Include(f => f.Enderecos)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task RemoverEnderecosPorCliente(Guid id)
        {
            var cliente = await ObterClienteEnderecos(id);
            Db.Enderecos.RemoveRange(cliente.Enderecos);
            Db.SaveChanges();

        }
        public async Task RemoverContatosPorCliente(Guid id)
        {
            var cliente = await ObterClienteContatos(id);
            Db.Contatos.RemoveRange(cliente.Contatos);
            Db.SaveChanges();

        }

    }
}
