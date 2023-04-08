using GameArchive.Models;

namespace GameArchive.Repositorios.Interfaces
{
    public class DesenvolvedoraRepositorio : IDesenvolvedoraRepositorio
    {
        public Task<DesenvolvedoraModel> Adicionar(DesenvolvedoraModel desenvolvedora)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Apagar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<DesenvolvedoraModel> Atualizar(DesenvolvedoraModel desenvolvedora, int id)
        {
            throw new NotImplementedException();
        }

        public Task<DesenvolvedoraModel> BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<DesenvolvedoraModel>> BuscarTodas()
        {
            throw new NotImplementedException();
        }
    }
}
