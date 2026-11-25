namespace designsoftware.nucleo.modelos
{
    public class Estudante : Usuario
    {
        public required string Grr {get; set;}
        public IList<Reserva> Reservas {get; set;} = [];
        public required string Email {get; set;}

        // public IList<Emprestimo> Emprestimos {get; set;} = [];
        // ...

        // public bool PodeEmprestarLivro() {}

        public bool PodeReservarLivro()
        {
            return this.Reservas.Count(reserva => !reserva.Finalizado) < 5;
        }

        // ...
    }
}