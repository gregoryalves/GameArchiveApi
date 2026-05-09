using GameArchive.Business.Interfaces;
using GameArchive.Data;
using GameArchive.Models;
using Microsoft.EntityFrameworkCore;

namespace GameArchive.Business
{
    public class UsuarioBusiness : IUsuarioBusiness
    {
        public string GerarHashSenha(string? senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        public bool VerificarSenha(string senha, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(senha, hash);
        }

        public async Task<bool> ValidarEmailJaCadastrado(GameArchiveDbContext dbContext, UsuarioModel usuario)
        {
            var usuarioComEmailExistente = await dbContext.Usuarios.Where(x => x.Email == usuario.Email && x.Id != usuario.Id).FirstOrDefaultAsync();

            return usuarioComEmailExistente != null;
        }
    }
}
