namespace src.Nucleo.Modelos
{
    public class Reserva : Prazo, INotificavel
    {
        public Exemplar LivroReservado {get; set;} = null!;
        public int Id {get; set;}
        public int LivroReservadoId {get; set;}

        public Reserva() {}

        public Reserva(Exemplar livro, Estudante responsavel)
            : base(responsavel)
        {
            this.LivroReservado = livro;
        }

        public string GeraNotificacao()
        {
            return $"Sua reserva do livro '{LivroReservado.LivroBase.Nome}' foi realizada com sucesso!";
        }
    }
}