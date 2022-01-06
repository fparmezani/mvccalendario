using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MvcCalendario.App.ViewModels;
using MvcCalendario.Business.Interfaces;
using MvcCalendario.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MvcCalendario.App.Controllers
{
    public class ClienteController : BaseController
    {


        private readonly IClienteRepository _clienteRepository;
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;

        public ClienteController(IClienteRepository clienteRepository,
            IClienteService clienteService,
            IMapper mapper,
            INotificador notificador) : base(notificador)
        {
            _clienteRepository = clienteRepository;
            _clienteService = clienteService;
            _mapper = mapper;
        }


        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ClienteViewModel>>(await _clienteRepository.ObterTodos()));
        }


        [Route("novo-cliente")]
        public async Task<IActionResult> Create()
        {
            var produtoViewModel = new ClienteViewModel();

            return View(produtoViewModel);
        }


        [Route("novo-cliente")]
        [HttpPost]
        public async Task<IActionResult> Create(ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid) return View(clienteViewModel);

            var cliente = _mapper.Map<Cliente>(clienteViewModel);

            await _clienteService.Adicionar(cliente);

            if (!OperacaoValida()) return View(clienteViewModel);

            return RedirectToAction("Index");
        }



        private async Task<ClienteViewModel> PopularClientes(ClienteViewModel cliente)
        {
            var dados = await _clienteRepository.ObterClienteCompleto(cliente.Id);

            cliente.Contatos = _mapper.Map<IEnumerable<ContatoViewModel>>(dados.Contatos);
            cliente.Enderecos = _mapper.Map<IEnumerable<EnderecoViewModel>>(dados.Enderecos);

            return cliente;
        }

        //public async Task<IActionResult> Edit()
        //{
        //    var clienteviewmodel = await PopularClientes(new ClienteViewModel());
        //    return View(clienteviewmodel);
        //}
        //public async Task<ClienteViewModel> EditarCliente(ClienteViewModel editarcliente)
        //{

        //    editarcliente.Contatos = _mapper.Map<IEnumerable<ContatoViewModel>>(await _clienteRepository.ObterClienteContatos());
        //    editarcliente.Enderecos = _mapper.Map<IEnumerable<EnderecoViewModel>>(await _clienteRepository.ObterClienteEnderecos());
        //    return editarcliente;
        //}
    }


}
