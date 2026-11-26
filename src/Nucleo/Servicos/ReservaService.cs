using src.Nucleo.Modelos;
using src.Nucleo.Repositorios;
using src.Nucleo.IServicos;

namespace src.Nucleo.Servicos
{
    public class ReservaService : IReservaService
    {
        private readonly ReservaRepository _reservaRepository;
        private readonly LivroRepository _livroRepository;
        private readonly EstudanteRepository _estudanteRepository;
        private readonly INotificacaoService _notificacaoService;

        public ReservaService(
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

        public async Task<Reserva?> BuscarReservaId(int id)
        {
            return await _reservaRepository.Get(id);
        }

        public async Task<ResultadoReserva> ReservarLivro(
            string grr,
            int idLivro)
        {
            Estudante? estudante =
                await _estudanteRepository.Get(grr);

            Livro? livro =
                await _livroRepository.Get(idLivro);

            if (estudante == null || livro == null)
                return ResultadoReserva.EstudanteOuLivroNaoEncontrado;

            if (!estudante.PodeReservarLivro())
                return ResultadoReserva.EstudanteNaoPodeReservar;

            Exemplar? exemplar = livro.Disponiveis().FirstOrDefault();

            if (exemplar == null)
                return ResultadoReserva.LivroIndisponivel;

            exemplar.Disponivel = false;

            Reserva novaReserva = new Reserva(exemplar, estudante);

            await _livroRepository.Atualizar(livro);
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