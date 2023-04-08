namespace GameArchive.Models
{
    public class UsuarioJogoModel
    {
        public int Id { get; set; }
        public int JogoId { get; set; }
        public virtual JogoModel? Jogo { get; set; }
        public int UsuarioId { get; set; }
        public virtual UsuarioModel? Usuario { get; set; }
        public DateTime? DataAquisicao { get; set; }
        public bool JaZerado { get; set; }
        public bool EhMidiaFisica { get; set; }
        public decimal PrecoPago { get; set; }
        public string? Descricao { get; set; }
        public int Nota { get; set; }
    }
}
