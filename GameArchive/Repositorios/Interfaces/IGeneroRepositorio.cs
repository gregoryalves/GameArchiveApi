using GameArchive.Models;

namespace GameArchive.Repositorios.Interfaces
{
    public interface IGeneroRepositorio
    {
        Task<List<Models.GeneroModel>> BuscarTodos();
        Task<Models.GeneroModel> BuscarPorId(int id);
        Task<Models.GeneroModel> Adicionar(Models.GeneroModel genero);
        Task<Models.GeneroModel> Atualizar(Models.GeneroModel genero, int id);
        Task<bool> Apagar(int id);
    }
}
