namespace GameArchive.Models
{
    public class JogoModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int PlataformaId { get; set; }
        public virtual PlataformaModel? Plataforma { get; set; }
        public int DesenvolvedoraId { get; set; }
        public virtual DesenvolvedoraModel? Desenvolvedora { get; set; }
        public int GeneroId { get; set; }
        public virtual GeneroModel? Genero { get; set; }
        public int FaixaEtaria { get; set; }
    }
}
