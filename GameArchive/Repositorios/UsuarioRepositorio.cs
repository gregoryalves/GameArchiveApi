using GameArchive.Models;

namespace GameArchive.Repositorios.Interfaces
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        public Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Apagar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioModel> BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UsuarioModel>> BuscarTodos()
        {
            throw new NotImplementedException();
        }

        public Task<int> Logar(UsuarioModel usuario)
        {
            throw new NotImplementedException();
        }
    }
}
