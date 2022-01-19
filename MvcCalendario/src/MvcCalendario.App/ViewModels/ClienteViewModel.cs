using MvcCalendario.Business.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcCalendario.App.ViewModels
{
    public class ClienteViewModel
    {
        #region Construtor

        public ClienteViewModel()
        {
            Contatos = new List<ContatoViewModel>();
            Enderecos = new List<EnderecoViewModel>();
        }

        #endregion


        #region Propriedades

        public Guid Id { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]

        [DisplayName("Nome")]
        public string Nome { get; set; }

        public string Cep { get; set; }


        [DisplayName("CPF")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        [DisplayName("Grupo")]
        public Grupo Grupo { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        public IEnumerable<ContatoViewModel> Contatos { get; set; }

        public IEnumerable<EnderecoViewModel> Enderecos { get; set; }

        #endregion

    }
}
