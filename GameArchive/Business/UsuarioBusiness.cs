using GameArchive.Business.Interfaces;
using GameArchive.Data;
using GameArchive.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace GameArchive.Business
{
    public class UsuarioBusiness : IUsuarioBusiness
    {
        public string GerarHashMd5(string? senha)
        {
            var md5Hash = MD5.Create();
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(senha));

            var sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        public async Task<bool> ValidarEmailJaCadastrado(GameArchiveDbContext dbContext, UsuarioModel usuario)
        {
            var usuarioComEmailExistente = await dbContext.Usuarios.Where(x => x.Email == usuario.Email && x.Id != usuario.Id).FirstOrDefaultAsync();

            return usuarioComEmailExistente != null;
        }
    }
}
