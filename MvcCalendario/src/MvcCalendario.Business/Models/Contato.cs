using System;

namespace MvcCalendario.Business.Models
{
    public class Contato : Entity
    {
        public Guid ClienteId { get; set; }
        public Telefone Telefone { get; set; }
        public Telefone Celular { get; set; }
        public string Email { get; set; }
        public bool Principal { get; set; }
        public bool EhWhatsApp { get; set; }

    }
}
