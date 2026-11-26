namespace src.nucleo.modelos
{
    public class Reserva : Prazo
    {
        public Livro LivroReservado {get; set;}
        public int Id {get; set;}

        public Reserva() {}

        public Reserva(Livro livro, Estudante responsavel)
            : base(responsavel)
        {
            this.LivroReservado = livro;
        }
    }
}