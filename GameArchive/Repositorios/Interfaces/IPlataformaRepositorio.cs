using GameArchive.Models;

namespace GameArchive.Repositorios.Interfaces
{
    public interface IPlataformaRepositorio
    {
        Task<IEnumerable<PlataformaModel>> BuscarTodas();
        Task<PlataformaModel> BuscarPorId(int id);
        Task<IEnumerable<PlataformaModel>> BuscarPorNome(string nome);
        Task<PlataformaModel> Adicionar(PlataformaModel plataforma);
        Task<PlataformaModel> Atualizar(PlataformaModel plataforma, int id);
        Task<bool> Apagar(int id);
    }
}
