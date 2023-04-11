using GameArchive.Models;

namespace GameArchive.Repositorios.Interfaces
{
    public interface IJogoRepositorio
    {
        Task<IEnumerable<JogoModel>> BuscarTodos();
        Task<JogoModel> BuscarPorId(int id);
        Task<JogoModel> Adicionar(JogoModel jogo);
        Task<JogoModel> Atualizar(JogoModel jogo, int id);
        Task<bool> Apagar(int id);
    }
}
