using GameArchive.Api.DataContracts;
using GameArchive.Models;

namespace GameArchive.Repositorios.Interfaces
{
    public interface IUsuarioJogoRepositorio
    {
        Task<IEnumerable<UsuarioJogoModel>> BuscarTodos();
        Task<IEnumerable<UsuarioJogoModel>> BuscarTodosPorUsuario(int usuarioId);
        Task<UsuarioJogoModel> BuscarPorId(int id);
        Task<IEnumerable<UsuarioJogoModel>> BuscarPorNome(UsuarioENomeDataContract usuarioNome);
        Task<IEnumerable<UsuarioJogoModel>> BuscarPorPlataforma(UsuarioENomeDataContract usuarioNome);
        Task<IEnumerable<UsuarioJogoModel>> BuscarPorDesenvolvedora(UsuarioENomeDataContract usuarioNome);
        Task<IEnumerable<UsuarioJogoModel>> BuscarPorGenero(UsuarioENomeDataContract usuarioNome);
        Task<UsuarioJogoModel> Adicionar(UsuarioJogoModel usuarioJogo);
        Task<UsuarioJogoModel> Atualizar(UsuarioJogoModel usuarioJogo, int id);
        Task<bool> Apagar(int id);
    }
}
