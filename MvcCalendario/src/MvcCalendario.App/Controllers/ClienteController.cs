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
        private readonly IContatoService _contatoService;

        private readonly IMapper _mapper;

        public ClienteController(IClienteRepository clienteRepository,
            IClienteService clienteService,
            IEnderecoService enderecoService,
            IContatoService contatoService,
            IMapper mapper,
            INotificador notificador) : base(notificador)
        {
            _clienteRepository = clienteRepository;
            _clienteService = clienteService;
            _enderecoService = enderecoService;
            _mapper = mapper;
            _contatoService = contatoService;
        }


        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ClienteViewModel>>(await _clienteRepository.ObterTodos()));
        }



        [Route("editar-cliente/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var clienteViewModel = await PopularCliente(id);

            if (clienteViewModel == null)
            {
                return NotFound();
            }

            return View("Edit", clienteViewModel);
        }

        [Route("editar-cliente/{id:guid}")]
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, ClienteViewModel clienteViewModel)
        {
            if (id != clienteViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(clienteViewModel);

            var cliente = _mapper.Map<Cliente>(clienteViewModel);
            await _clienteService.Atualizar(cliente);

            if (!OperacaoValida()) return View(await ObterEnderecos(id));

            return RedirectToAction("Index");
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


        [Route("novo-endereco-cliente/{id:guid}")]
        public async Task<IActionResult> NovoEndereco(Guid Id)
        {
            var enderecoViewModel = new EnderecoViewModel(Id);

            return PartialView("_NovoEndereco", enderecoViewModel);
        }

        [Route("novo-contato-cliente/{id:guid}")]
        public async Task<IActionResult> NovoContato(Guid Id)
        {
            var contatoViewModel = new ContatoViewModel(Id);

            return PartialView("_NovoContato", contatoViewModel);
        }



        [Route("excluir-cliente/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var clienteViewModel = await PopularCliente(id);

            if (clienteViewModel == null)
            {
                return NotFound();
            }

            return View(clienteViewModel);
        }

        [Route("excluir-cliente/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var cliente = await PopularCliente(id);

            if (cliente == null) return NotFound();

            await _clienteService.Remover(id);

            if (!OperacaoValida()) return View(cliente);

            return RedirectToAction("Index");
        }


        [Route("obter-enderecos/{id:guid}")]
        public async Task<IActionResult> ObterEnderecos(Guid id)
        {
            var cliente = await PopularCliente(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return PartialView("_Enderecos", cliente);
        }

        [Route("obter-contatos/{id:guid}")]
        public async Task<IActionResult> ObterContatos(Guid id)
        {
            var cliente = await PopularCliente(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return PartialView("_Contatos", cliente);
        }


        [Route("novo-endereco-cliente/{id:guid}")]
        [HttpPost]
        public async Task<IActionResult> NovoEndereco(EnderecoViewModel enderecoViewModel)
        {

            if (!ModelState.IsValid) return PartialView("_NovoEndereco", enderecoViewModel);

            var endereco = _mapper.Map<Endereco>(enderecoViewModel);

            await _enderecoService.Adicionar(endereco);

            if (!OperacaoValida()) return PartialView("_NovoEndereco", enderecoViewModel);

            var url = Url.Action("ObterEnderecos", "Cliente", new { id = enderecoViewModel.ClienteId });

            return Json(new { success = true, url });
        }


        [Route("novo-contato-cliente/{id:guid}")]
        [HttpPost]
        public async Task<IActionResult> NovoContato(ContatoViewModel contatoViewModel)
        {

            if (!ModelState.IsValid) return PartialView("_NovoContato", contatoViewModel);

            var contato = _mapper.Map<Contato>(contatoViewModel);

            await _contatoService.Adicionar(contato);

            if (!OperacaoValida()) return PartialView("_NovoContato", contatoViewModel);

            var url = Url.Action("ObterContatos", "Cliente", new { id = contatoViewModel.ClienteId });

            return Json(new { success = true, url });
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
