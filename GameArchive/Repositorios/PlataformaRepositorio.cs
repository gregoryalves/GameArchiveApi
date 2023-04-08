using GameArchive.Models;

namespace GameArchive.Repositorios.Interfaces
{
    public class PlataformaRepositorio : IPlataformaRepositorio
    {
        public Task<PlataformaModel> Adicionar(PlataformaModel plataforma)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Apagar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PlataformaModel> Atualizar(PlataformaModel plataforma, int id)
        {
            throw new NotImplementedException();
        }

        public Task<PlataformaModel> BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PlataformaModel>> BuscarTodas()
        {
            throw new NotImplementedException();
        }
    }
}
