using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MvcCalendario.App.ViewModels;
using MvcCalendario.Business.Interfaces;
using MvcCalendario.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MvcCalendario.App.Controllers
{
    public class ClienteController : BaseController
    {


        private readonly IClienteRepository _clienteRepository;
        private readonly IClienteService _clienteService;
        private readonly IEnderecoService _enderecoService;

        private readonly IMapper _mapper;

        public ClienteController(IClienteRepository clienteRepository,
            IClienteService clienteService,
            IEnderecoService enderecoService,
            IMapper mapper,
            INotificador notificador) : base(notificador)
        {
            _clienteRepository = clienteRepository;
            _clienteService = clienteService;
            _enderecoService = enderecoService;
            _mapper = mapper;
        }


        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ClienteViewModel>>(await _clienteRepository.ObterTodos()));
        }



        [Route("dados-do-cliente/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var clienteViewModel = await PopularCliente(id);

            if (clienteViewModel == null)
            {
                return NotFound();
            }

            return View("Details", clienteViewModel);
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


        [Route("novo-endereco/{id:guid}")]
        public async Task<IActionResult> NovoEndereco(Guid Id)
        {
            var enderecoViewModel = new EnderecoViewModel(Id);

            return PartialView("_NovoEndereco", enderecoViewModel);
        }

        [Route("obter-endereco/{id:guid}")]
        public async Task<IActionResult> ObterEndereco(Guid id)
        {
            var cliente = await PopularCliente(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return PartialView("_Enderecos", cliente);
        }


        [Route("novo-endereco/{id:guid}")]
        [HttpPost]
        public async Task<IActionResult> AtualizarEndereco(EnderecoViewModel enderecoViewModel)
        {

            if (!ModelState.IsValid) return PartialView("_NovoEndereco", enderecoViewModel);

            var endereco = _mapper.Map<Endereco>(enderecoViewModel);

            await _enderecoService.Adicionar(endereco);
            
            if (!OperacaoValida()) return PartialView("_AtualizarEndereco", enderecoViewModel);

            var url = Url.Action("ObterEnderecos", "Cliente", new { id = enderecoViewModel.ClienteId });

            return Json(new { success = true, url });
        }




        private async Task<ClienteViewModel> PopularClientes(ClienteViewModel cliente)
        {
            var dados = await _clienteRepository.ObterClienteCompleto(cliente.Id);

            cliente.Contatos = _mapper.Map<IEnumerable<ContatoViewModel>>(dados.Contatos);
            cliente.Enderecos = _mapper.Map<IEnumerable<EnderecoViewModel>>(dados.Enderecos);

            return cliente;
        }


        private async Task<ClienteViewModel> PopularCliente(Guid Id)
        {

            var cliente = _mapper.Map<ClienteViewModel>(await _clienteRepository.ObterClienteCompleto(Id));
            cliente.Contatos = _mapper.Map<IEnumerable<ContatoViewModel>>(cliente.Contatos);
            cliente.Enderecos = _mapper.Map<IEnumerable<EnderecoViewModel>>(cliente.Enderecos);

            return cliente;
        }






    }


}
