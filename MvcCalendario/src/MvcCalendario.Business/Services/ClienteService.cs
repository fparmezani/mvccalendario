using MvcCalendario.Business.Interfaces;
using MvcCalendario.Business.Models;
using MvcCalendario.Business.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCalendario.Business.Services
{
    public class ClienteService : BaseService, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IEnderecoRepository _enderecoRepository;

        public ClienteService(IClienteRepository ClienteRepository,
                                 IEnderecoRepository enderecoRepository,
                                 INotificador notificador) : base(notificador)
        {
            _clienteRepository = ClienteRepository;
            _enderecoRepository = enderecoRepository;
        }

        public async Task Adicionar(Cliente Cliente)
        {
            if (!ExecutarValidacao(new ClienteValidation(), Cliente)) return;

            await _clienteRepository.Adicionar(Cliente);
        }

        public async Task Atualizar(Cliente Cliente)
        {
            if (!ExecutarValidacao(new ClienteValidation(), Cliente)) return;

            await _clienteRepository.Atualizar(Cliente);
        }

        public async Task Remover(Guid id)
        {
            if (_clienteRepository.ObterPorId(id).Result.Enderecos.Any())
            {
                Notificar("O Cliente possui endereços cadastrados!");
                return;
            }

            var cliente = await _clienteRepository.ObterPorId(id);

            if (cliente.Enderecos.Any())
            {
                await _clienteRepository.RemoverEnderecosPorCliente(id);
            }

            await _clienteRepository.Remover(id);
        }


        public void Dispose()
        {
            _clienteRepository?.Dispose();
            _enderecoRepository?.Dispose();
        }
    }
}
