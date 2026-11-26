using src.Nucleo.Modelos;
using src.Nucleo.IServicos;
using src.Portas;

namespace src.Nucleo.Servicos
{
    public class NotificacaoService : INotificacaoService
    {
        private readonly NotificadorPort _notificador;

        public NotificacaoService(NotificadorPort notificador)
        {
            _notificador = notificador;
        }

        public async Task Notificar(
            INotificavel notificavel,
            string destinatario,
            string endereco)
        {
            string mensagem = notificavel.GeraNotificacao();

            await _notificador.Notifica(
                destinatario,
                endereco,
                mensagem
            );
        }
    }
}