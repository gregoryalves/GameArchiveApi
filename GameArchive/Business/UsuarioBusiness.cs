using GameArchive.Business.Interfaces;
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
    }
}
