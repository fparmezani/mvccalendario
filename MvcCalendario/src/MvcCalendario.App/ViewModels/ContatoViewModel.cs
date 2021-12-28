using MvcCalendario.Business.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace MvcCalendario.App.ViewModels
{
    public class ContatoViewModel
    {
        public Guid ClienteId { get; set; }
        public Telefone Telefone { get; set; }
        public Telefone Celular { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Email { get; set; }
        public bool Principal { get; set; }
        public bool EhWhatsApp { get; set; }

    }
}