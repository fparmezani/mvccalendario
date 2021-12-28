using System;

namespace MvcCalendario.Business.Models
{
    public class Agenda : Entity
    {

        public DateTime DataAgenda { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public Status Ativo { get; set; }

        /*Relacionamento*/
        public Guid ClienteId { get; set; }

        public Cliente Cliente { get; set; }

    }
}
