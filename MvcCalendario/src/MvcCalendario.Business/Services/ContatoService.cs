using MvcCalendario.Business.Interfaces;
using MvcCalendario.Business.Models;
using MvcCalendario.Business.Models.Validations;
using System;
using System.Threading.Tasks;

namespace MvcCalendario.Business.Services
{
    public class ContatoService : BaseService, IContatoService
    {

        private readonly IContatoRepository _contatoRepository;

        public ContatoService(IContatoRepository contatoRepository,
                                 INotificador notificador) : base(notificador)
        {
            _contatoRepository = contatoRepository;
        }

        public async Task Adicionar(Contato contato)
        {
            //]if (!ExecutarValidacao(new EnderecoValidation(), endereco)) return;

            await _contatoRepository.Adicionar(contato);
        }

        public async Task Atualizar(Contato contato)
        {
            if (!ExecutarValidacao(new ContatoValidation(), contato)) return;

            await _contatoRepository.Atualizar(contato);
        }

        public async Task Remover(Guid id)
        {
            await _contatoRepository.Remover(id);
        }


        public void Dispose()
        {
            _contatoRepository?.Dispose();
        }


    }
}
