namespace src.Nucleo.IServicos
{
    public interface INotificacaoService
    {
        Task Notificar(INotificavel notificavel, string destinatario, string endereco);
    }
}