namespace src.Nucleo.Modelos
{
    public abstract class Usuario
    {
        public required string Nome { get; set; }
        public required string Cpf { get; set; }
    }
}