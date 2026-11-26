using src.Nucleo.IServicos;
using src.Nucleo.Modelos;
using src.Nucleo.Repositorios;

namespace src.Nucleo.Servicos
{
    public class EstudanteService : IEstudanteService
    {
        private readonly EstudanteRepository _estudanteRepository;

        public EstudanteService(EstudanteRepository estudanteRepository)
        {
            _estudanteRepository = estudanteRepository;
        }

        public async Task<Estudante?> BuscarEstudanteGrr(string grr)
        {
            return await _estudanteRepository.Get(grr);
        }
    }
}