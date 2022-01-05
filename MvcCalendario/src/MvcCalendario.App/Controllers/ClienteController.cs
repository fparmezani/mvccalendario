using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MvcCalendario.App.ViewModels;
using MvcCalendario.Business.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MvcCalendario.App.Controllers
{
    public class ClienteController : BaseController
    {


        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteController(IClienteRepository clienteRepository,
            IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }


        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ClienteViewModel>>(await _clienteRepository.ObterTodos()));
        }


        [Route("novo-cliente")]
        public async Task<IActionResult> Create()
        {
            var produtoViewModel = await PopularClientes(new ClienteViewModel());

            return View(produtoViewModel);
        }

        private async Task<ClienteViewModel> PopularClientes(ClienteViewModel cliente)
        {
            cliente.Contatos = _mapper.Map<IEnumerable<ContatoViewModel>>(await _clienteRepository.ObterClienteContatos());
            cliente.Enderecos = _mapper.Map<IEnumerable<EnderecoViewModel>>(await _clienteRepository.ObterClienteEnderecos());
            return cliente;
        }
       
        public async Task<IActionResult> Edit()
        {
            var clienteviewmodel = await PopularClientes(new ClienteViewModel());
            return View(clienteviewmodel);
        }
        public async Task<ClienteViewModel> EditarCliente(ClienteViewModel editarcliente)
        {

            editarcliente.Contatos = _mapper.Map<IEnumerable<ContatoViewModel>>(await _clienteRepository.ObterClienteContatos());
            editarcliente.Enderecos = _mapper.Map<IEnumerable<EnderecoViewModel>>(await _clienteRepository.ObterClienteEnderecos());
            return editarcliente;
        }
    }

  
}
