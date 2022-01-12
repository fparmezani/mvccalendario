using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcCalendario.App.ViewModels
{
    public class ContatoViewModel
    {

        #region Construtor

        public ContatoViewModel()
        {

        }

        public ContatoViewModel(Guid Id)
        {
            ClienteId = Id;
        }

        #endregion

        #region Propriedades

        public Guid ClienteId { get; set; }

        public string Telefone { get; set; }

        public string Celular { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Email { get; set; }

        [DisplayName("É o número principal?")]
        public bool Principal { get; set; }

        [DisplayName("É o número para WhatsApp?")]
        public bool EhWhatsApp { get; set; }

        #endregion
    }
}