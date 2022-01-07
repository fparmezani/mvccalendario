using System;

namespace MvcCalendario.App.ViewModels
{
    public class EnderecoViewModel
    {
        public EnderecoViewModel()
        {

        }

        public EnderecoViewModel(Guid Id)
        {
            ClienteId = Id;
        }

        public Guid ClienteId { get; set; }
        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public string Cep { get; set; }

        public string Cidade { get; set; }

        public string UF { get; set; }

    }
}