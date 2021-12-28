namespace MvcCalendario.Business.Models
{
    public class Contato : Entity
    {
        public Telefone Telefone { get; set; }

        public Telefone Celular { get; set; }

        public bool Principal { get; set; }

        public bool EhWhatsApp { get; set; }

    }
}
