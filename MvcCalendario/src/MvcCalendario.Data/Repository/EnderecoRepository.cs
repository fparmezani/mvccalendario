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
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(MvcContext context) : base(context) { }

        public async Task<IEnumerable<Endereco>> ObterEnderecosPorCliente(Guid clienteId)
        {
            return await Db.Enderecos.AsNoTracking().Where(f => f.ClienteId == clienteId).ToListAsync();

        }
    }
}
