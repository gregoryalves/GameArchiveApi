using GameArchive.Models;

namespace GameArchive.Repositorios.Interfaces
{
    public class UsuarioJogoRepositorio : IUsuarioJogoRepositorio
    {
        public Task<UsuarioJogoModel> Adicionar(UsuarioJogoModel usuarioJogo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Apagar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioJogoModel> Atualizar(UsuarioJogoModel usuarioJogo, int id)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioJogoModel> BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UsuarioJogoModel>> BuscarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
