using GameArchive.Models;

namespace GameArchive.Repositorios.Interfaces
{
    public interface IDesenvolvedoraRepositorio
    {
        Task<IEnumerable<DesenvolvedoraModel>> BuscarTodas();
        Task<DesenvolvedoraModel> BuscarPorId(int id);
        Task<IEnumerable<DesenvolvedoraModel>> BuscarPorNome(string nome);
        Task<DesenvolvedoraModel> Adicionar(DesenvolvedoraModel desenvolvedora);
        Task<DesenvolvedoraModel> Atualizar(DesenvolvedoraModel desenvolvedora, int id);
        Task<bool> Apagar(int id);
    }
}
