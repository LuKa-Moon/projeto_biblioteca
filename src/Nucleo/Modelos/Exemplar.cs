namespace src.nucleo.modelos
{
    public class Exemplar
    {
        public int Id {get; set;}
        public bool Disponivel {get; set;}

        public bool EstaDisponivel()
        {
            return this.Disponivel;
        }
    }
}