using System.ComponentModel.DataAnnotations;

namespace GameArchive.Models
{
    public class JogoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do jogo é obrigatório")]
        [StringLength(200, ErrorMessage = "O nome deve ter no máximo 200 caracteres")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "A plataforma é obrigatória")]
        public int PlataformaId { get; set; }
        public virtual PlataformaModel? Plataforma { get; set; }

        [Required(ErrorMessage = "A desenvolvedora é obrigatória")]
        public int DesenvolvedoraId { get; set; }
        public virtual DesenvolvedoraModel? Desenvolvedora { get; set; }

        [Required(ErrorMessage = "O gênero é obrigatório")]
        public int GeneroId { get; set; }
        public virtual GeneroModel? Genero { get; set; }

        [Required(ErrorMessage = "A faixa etária é obrigatória")]
        [Range(0, 18, ErrorMessage = "A faixa etária deve estar entre 0 e 18")]
        public int FaixaEtaria { get; set; }
    }
}
