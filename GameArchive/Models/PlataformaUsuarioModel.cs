namespace GameArchive.Models
{
    public class PlataformaUsuarioModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int PlataformaId { get; set; }
        public virtual PlataformaModel? Plataforma { get; set; }
        public int UsuarioId { get; set; }
        public virtual UsuarioModel? Usuario { get; set; }
        public int Controles { get; set; }
    }
}
