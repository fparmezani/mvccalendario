﻿using System.Collections.Generic;

namespace MvcCalendario.Business.Models
{
    public class Cliente : Entity
    {
        public string Nome { get; set; }

        public string CPF { get; set; }

        public string Email { get; set; }

        public Grupo Grupo { get; set; }


        /*Relacionamento*/

        public Contato Contato { get; set; }

        public Endereco Endereco { get; set; }

        public IEnumerable<Contato> Contatos { get; set; }


    }



}
