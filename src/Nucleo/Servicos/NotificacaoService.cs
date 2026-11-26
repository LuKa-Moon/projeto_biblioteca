using src.Nucleo.IServicos;
using src.Adaptadores;

namespace src.Nucleo.Servicos
{
    public class NotificacaoService : INotificacaoService
    {
        private readonly NotificadorEmailAdapter _notificador;

        public NotificacaoService(NotificadorEmailAdapter notificador)
        {
            _notificador = notificador;
        }

        public async Task Notificar(
            string nome, string email, string mensagem)
        {
            await _notificador.Notifica(nome, email, mensagem);
        }
    }
}