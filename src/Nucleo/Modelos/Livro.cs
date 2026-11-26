namespace src.Nucleo.Modelos
{
    public class Livro
    {
        public required string Nome {get; set;}
        public int Id {get; set;}
        public ICollection<Exemplar> Exemplares {get; set;} = [];
        public string? CapaUrl {get; set;}

        public ICollection<Exemplar> Disponiveis()
        {
            return Exemplares.Where(exemplar => exemplar.EstaDisponivel()).ToList();
        }
    }
}