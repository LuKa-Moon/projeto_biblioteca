namespace designsoftware.nucleo.modelos
{
    public class Livro
    {
        public required string Nome {get; set;}
        public int Id {get; set;}
        public IList<Exemplar> Exemplares {get; set;} = [];

        public IList<Exemplar> Disponiveis()
        {
            return Exemplares.Where(exemplar => exemplar.EstaDisponivel()).ToList();
        }
    }
}