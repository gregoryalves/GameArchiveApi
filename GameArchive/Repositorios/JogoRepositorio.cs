using GameArchive.Models;

namespace GameArchive.Repositorios.Interfaces
{
    public class JogoRepositorio : IJogoRepositorio
    {
        public Task<JogoModel> Adicionar(JogoModel jogo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Apagar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<JogoModel> Atualizar(JogoModel jogo, int id)
        {
            throw new NotImplementedException();
        }

        public Task<JogoModel> BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<JogoModel>> BuscarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
