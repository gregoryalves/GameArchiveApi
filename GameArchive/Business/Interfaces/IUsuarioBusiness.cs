using GameArchive.Data;
using GameArchive.Models;

namespace GameArchive.Business.Interfaces
{
    public interface IUsuarioBusiness
    {
        string GerarHashMd5(string? senha);
        Task<bool> ValidarEmailJaCadastrado(GameArchiveDbContext dbContext, UsuarioModel usuario);
    }
}
