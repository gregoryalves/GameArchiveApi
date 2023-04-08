using GameArchive.Models;

namespace GameArchive.Repositorios.Interfaces
{
    public class GeneroRepositorio : IGeneroRepositorio
    {
        public Task<Models.GeneroModel> Adicionar(Models.GeneroModel genero)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Apagar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Models.GeneroModel> Atualizar(Models.GeneroModel genero, int id)
        {
            throw new NotImplementedException();
        }

        public Task<Models.GeneroModel> BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Models.GeneroModel>> BuscarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
