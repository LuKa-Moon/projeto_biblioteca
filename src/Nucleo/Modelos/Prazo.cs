namespace src.Nucleo.Modelos
{
    public abstract class Prazo
    {
        public bool Finalizado {get; set;}
        public DateTime DataInicial {get; set;}
        public DateTime DataLimite {get; set;}
        public Estudante Responsavel {get; set;}

        public Prazo() {}

        public Prazo(Estudante responsavel)
        {
            this.Responsavel = responsavel;
            this.DataInicial = DateTime.Now;
            this.DataLimite = this.DataInicial.AddDays(7);
            this.Finalizado = false;
        }

        public Prazo(Estudante responsavel, DateTime dataInicial)
        {
            this.Responsavel = responsavel;
            this.DataInicial = dataInicial;
            this.DataLimite = this.DataInicial.AddDays(7);
            this.Finalizado = false;
        }

        public void Renovar()
        {
            this.DataLimite.AddDays(7);
        }

        public void Finalizar()
        {
            this.Finalizado = true;
        }
    }
}