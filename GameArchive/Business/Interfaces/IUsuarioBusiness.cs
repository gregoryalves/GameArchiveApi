using GameArchive.Data;
using GameArchive.Models;

namespace GameArchive.Business.Interfaces
{
    public interface IUsuarioBusiness
    {
        string GerarHashSenha(string? senha);
        bool VerificarSenha(string senha, string hash);
        Task<bool> ValidarEmailJaCadastrado(GameArchiveDbContext dbContext, UsuarioModel usuario);
    }
}
