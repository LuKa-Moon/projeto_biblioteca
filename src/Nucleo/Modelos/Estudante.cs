namespace src.Nucleo.Modelos
{
    public class Estudante : Usuario
    {
        public required string Grr {get; set;}
        public ICollection<Reserva> Reservas {get; set;} = [];
        public required string Email {get; set;}

        // public ICollection<Emprestimo> Emprestimos {get; set;} = [];
        // ...

        // public bool PodeEmprestarLivro() {}

        public bool PodeReservarLivro()
        {
            return this.Reservas.Count(reserva => !reserva.Finalizado) < 5;
        }

        // ...
    }
}