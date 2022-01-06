using MvcCalendario.Business.Notifications;
using System.Collections.Generic;

namespace MvcCalendario.Business.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
