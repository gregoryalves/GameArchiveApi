using GameArchive.Models;

namespace GameArchive.Repositorios.Interfaces
{
    public interface IPlataformaUsuarioRepositorio
    {
        Task<List<PlataformaUsuarioModel>> BuscarTodos();
        Task<List<PlataformaUsuarioModel>> BuscarTodosPorUsuario(int usuarioId);
        Task<PlataformaUsuarioModel> BuscarPorId(int id);
        Task<PlataformaUsuarioModel> Adicionar(PlataformaUsuarioModel plataformaUsuario);
        Task<PlataformaUsuarioModel> Atualizar(PlataformaUsuarioModel plataformaUsuario, int id);
        Task<bool> Apagar(int id);
    }
}
