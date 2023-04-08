using GameArchive.Models;

namespace GameArchive.Repositorios.Interfaces
{
    public interface IUsuarioJogoRepositorio
    {
        Task<List<UsuarioJogoModel>> BuscarTodos();
        Task<UsuarioJogoModel> BuscarPorId(int id);
        Task<UsuarioJogoModel> Adicionar(UsuarioJogoModel usuarioJogo);
        Task<UsuarioJogoModel> Atualizar(UsuarioJogoModel usuarioJogo, int id);
        Task<bool> Apagar(int id);
    }
}
