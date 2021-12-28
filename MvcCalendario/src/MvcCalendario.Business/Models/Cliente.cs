using System;
using System.Collections.Generic;

namespace MvcCalendario.Business.Models
{
    public class Cliente : Entity
    {
        public string Nome { get; set; }

        public string CPF { get; set; }

        public Grupo Grupo { get; set; }


        /*Relacionamento*/
        public IEnumerable<Endereco> Enderecos { get; set; }
        public IEnumerable<Contato> Contatos { get; set; }

    }

}
