using src.Nucleo.Modelos;

namespace src.Nucleo.IServicos
{
    public interface IEstudanteService
    {
        Task<Estudante?> BuscarEstudanteGrr(string grr);
    }
}