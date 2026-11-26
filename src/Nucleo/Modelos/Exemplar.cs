namespace src.nucleo.modelos
{
    public class Exemplar
    {
        public int Id {get; set;}
        public bool Disponivel {get; set;}
        public int LivroId {get; set;}
        public Livro LivroBase {get; set;} = null!;

        public bool EstaDisponivel()
        {
            return this.Disponivel;
        }
    }
}