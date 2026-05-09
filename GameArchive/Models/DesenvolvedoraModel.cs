using System.ComponentModel.DataAnnotations;

namespace GameArchive.Models
{
    public class DesenvolvedoraModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da desenvolvedora é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        public string? Nome { get; set; }
    }
}
