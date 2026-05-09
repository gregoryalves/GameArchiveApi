using System.ComponentModel.DataAnnotations;

namespace GameArchive.Models
{
    public class PlataformaModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da plataforma é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        public string? Nome { get; set; }
    }
}
