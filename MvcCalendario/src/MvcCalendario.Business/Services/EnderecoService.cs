using MvcCalendario.Business.Interfaces;
using MvcCalendario.Business.Models;
using MvcCalendario.Business.Models.Validations;
using System;
using System.Threading.Tasks;

namespace MvcCalendario.Business.Services
{
    public class EnderecoService : BaseService, IEnderecoService
    {

        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoService(IEnderecoRepository enderecoRepository,
                                 INotificador notificador) : base(notificador)
        {
            _enderecoRepository = enderecoRepository;
        }

        public async Task Adicionar(Endereco endereco)
        {
            if (!ExecutarValidacao(new EnderecoValidation(), endereco)) return;

            await _enderecoRepository.Adicionar(endereco);
        }

        public async Task Atualizar(Endereco endereco)
        {
            if (!ExecutarValidacao(new EnderecoValidation(), endereco)) return;

            await _enderecoRepository.Atualizar(endereco);
        }

        public async Task Remover(Guid id)
        {
            await _enderecoRepository.Remover(id);
        }


        public void Dispose()
        {
            _enderecoRepository?.Dispose();
        }


    }
}
