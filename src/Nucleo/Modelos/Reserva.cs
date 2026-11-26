namespace src.Nucleo.Modelos
{
    public class Reserva : Prazo, INotificavel
    {
        public Livro LivroReservado {get; set;}
        public int Id {get; set;}

        public Reserva() {}

        public Reserva(Livro livro, Estudante responsavel)
            : base(responsavel)
        {
            this.LivroReservado = livro;
        }

        public string GeraNotificacao()
        {
            return $"Sua reserva do livro '{LivroReservado.Nome}' foi realizada com sucesso!";
        }
    }
}