using GameArchive.Models;

namespace GameArchive.Repositorios.Interfaces
{
    public class PlataformaUsuarioRepositorio : IPlataformaUsuarioRepositorio
    {
        public Task<PlataformaUsuarioModel> Adicionar(PlataformaUsuarioModel plataformaUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Apagar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PlataformaUsuarioModel> Atualizar(PlataformaUsuarioModel plataformaUsuario, int id)
        {
            throw new NotImplementedException();
        }

        public Task<PlataformaUsuarioModel> BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PlataformaUsuarioModel>> BuscarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
