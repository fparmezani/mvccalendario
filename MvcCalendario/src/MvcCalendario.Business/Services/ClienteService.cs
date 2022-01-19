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
        private readonly IContatoRepository _contatoRepository;


        public ClienteService(IClienteRepository ClienteRepository,
                                 IEnderecoRepository enderecoRepository,
                                 IContatoRepository contatoRepository,
                                 INotificador notificador) : base(notificador)
        {
            _clienteRepository = ClienteRepository;
            _enderecoRepository = enderecoRepository;
            _contatoRepository = contatoRepository;
        }

        public async Task Adicionar(Cliente cliente)
        {
            if (!ExecutarValidacao(new ClienteValidation(), cliente)) return;

            if (_clienteRepository.Buscar(f => f.CPF == cliente.CPF).Result.Any())
            {
                Notificar("Já existe um cliente com este documento infomado.");
                return;
            }

            await _clienteRepository.Adicionar(cliente);
        }

        public async Task Atualizar(Cliente Cliente)
        {
            if (!ExecutarValidacao(new ClienteValidation(), Cliente)) return;

            await _clienteRepository.Atualizar(Cliente);
        }

        public async Task Remover(Guid id)
        {
            try
            {
                var result = _clienteRepository.ObterClienteCompleto(id).Result;

                //if (result.Enderecos != null && result.Enderecos.Any())
                //{
                //    Notificar("O Cliente possui endereços cadastrados!");
                //    return;
                //}

                //if (result.Contatos != null && result.Contatos.Any())
                //{
                //    Notificar("O Cliente possui contatos cadastrados!");
                //    return;
                //}

                var enderecos = _enderecoRepository.ObterEnderecosPorCliente(id);
                var contatos = _contatoRepository.ObterContatosPorCliente(id);

                if (enderecos != null) await _clienteRepository.RemoverEnderecosPorCliente(id);
                if (contatos != null) await _clienteRepository.RemoverContatosPorCliente(id);

                await _clienteRepository.Remover(id);

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }


        public void Dispose()
        {
            _clienteRepository?.Dispose();
            _enderecoRepository?.Dispose();
        }
    }
}
