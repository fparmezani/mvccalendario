using System;

namespace MvcCalendario.Business.Models
{
    public class Contato : Entity
    {
        public Guid ClienteId { get; set; }

        public string Telefone { get; set; }

        public string Celular { get; set; }

        public string Email { get; set; }

        public bool Principal { get; set; }

        public bool EhWhatsApp { get; set; }

        public Cliente Cliente { get; set; }


    }
}
