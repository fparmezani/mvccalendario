using System;

namespace MvcCalendario.Business.Models
{
    public class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();

        }

        public Guid Id { get; set; }

        public DateTime DataCadastro { get; set; }

    }
}
