using src.Nucleo.Modelos;

namespace src.Nucleo.IServicos
{
    public enum ResultadoReserva
    {
        Sucesso,
        EstudanteOuLivroNaoEncontrado,
        EstudanteNaoPodeReservar,
        LivroIndisponivel
    }
    
    public interface IReservaService
    {
        Task<Reserva?> BuscarReservaId(int id);

        Task<ResultadoReserva> ReservarLivro(
            string grr,
            int idLivro
        );
    }
}