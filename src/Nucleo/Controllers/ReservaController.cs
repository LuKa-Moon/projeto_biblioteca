using src.Nucleo.Modelos;
using src.Nucleo.Repositorios;
using src.Nucleo.IServicos;

namespace src.Nucleo.Controllers
{
    public enum ResultadoReserva
    {
        Sucesso,
        EstudanteOuLivroNaoEncontrado,
        EstudanteNaoPodeReservar,
        LivroIndisponivel
    }

    public class ReservaController
    {
        private readonly ReservaRepository _reservaRepository;
        private readonly LivroRepository _livroRepository;
        private readonly EstudanteRepository _estudanteRepository;
        private readonly INotificacaoService _notificacaoService;

        public ReservaController(
            ReservaRepository reservaRepository,
            LivroRepository livroRepository,
            EstudanteRepository estudanteRepository,
            INotificacaoService notificacaoService)
        {
            _reservaRepository = reservaRepository;
            _livroRepository = livroRepository;
            _estudanteRepository = estudanteRepository;
            _notificacaoService = notificacaoService;
        }

        public async Task<Reserva?> GetReserva(string id)
        {
            return await _reservaRepository.Get(id);
        }

        public async Task<ResultadoReserva> ReservarLivro(
            string grr, string idLivro)
        {
            Estudante? estudante =
                await _estudanteRepository.Get(grr);

            Livro? livro =
                await _livroRepository.Get(idLivro);

            if (estudante == null || livro == null)
                return ResultadoReserva.EstudanteOuLivroNaoEncontrado;

            if (!estudante.PodeReservarLivro())
                return ResultadoReserva.EstudanteNaoPodeReservar;

            if (livro.Disponiveis().Count == 0)
                return ResultadoReserva.LivroIndisponivel;

            Reserva novaReserva = new Reserva(livro, estudante);

            await _reservaRepository.Criar(novaReserva);

            await _notificacaoService.Notificar(
                novaReserva,
                estudante.Nome,
                estudante.Email
            );

            return ResultadoReserva.Sucesso;
        }
    }
}