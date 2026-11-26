namespace src.Nucleo.IServicos
{
    public interface INotificacaoService
    {
        Task Notificar(string nome, string email, string mensagem);
    }
}