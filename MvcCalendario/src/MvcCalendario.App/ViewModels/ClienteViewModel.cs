using MvcCalendario.Business.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcCalendario.App.ViewModels
{
    public class ClienteViewModel
    {



        public ClienteViewModel()
        {
            Contatos = new List<ContatoViewModel>();
            Enderecos = new List<EnderecoViewModel>();

        }
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        public Grupo Grupo { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        public IEnumerable<ContatoViewModel> Contatos { get; set; }

        public IEnumerable<EnderecoViewModel> Enderecos { get; set; }

        public Guid ClienteId { get; set; }
        public Telefone Telefone { get; set; }
        public Telefone Celular { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Email { get; set; }
        public bool Principal { get; set; }
        public bool EhWhatsApp { get; set; }

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public string Cep { get; set; }

        public string Cidade { get; set; }

        public string UF { get; set; }

    }
}
