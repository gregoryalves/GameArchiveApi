using GameArchive.Data;
using GameArchive.Models;
using Microsoft.EntityFrameworkCore;

namespace GameArchive.Repositorios.Interfaces
{
    public class PlataformaRepositorio : IPlataformaRepositorio
    {
        private readonly GameArchiveDbContext _dbContext;

        public PlataformaRepositorio(GameArchiveDbContext gamerArchiveDbContext)
        {
            _dbContext = gamerArchiveDbContext;
        }

        public async Task<PlataformaModel> Adicionar(PlataformaModel plataforma)
        {
            await _dbContext.Plataformas.AddAsync(plataforma);
            await _dbContext.SaveChangesAsync();

            return plataforma;
        }

        public async Task<bool> Apagar(int id)
        {
            var plataformaPorId = await BuscarPorId(id);

            if (plataformaPorId == null)
            {
                throw new Exception($"Plataforma com ID: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.Plataformas.Remove(plataformaPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<PlataformaModel> Atualizar(PlataformaModel plataforma, int id)
        {
            var plataformaPorId = await BuscarPorId(id);

            if (plataformaPorId == null)
            {
                throw new Exception($"Plataforma com ID: {id} não foi encontrado no banco de dados.");
            }

            plataformaPorId.Nome = plataforma.Nome;

            _dbContext.Plataformas.Update(plataformaPorId);
            await _dbContext.SaveChangesAsync();

            return plataformaPorId;
        }

        public async Task<PlataformaModel> BuscarPorId(int id)
        {
            var plataforma = await _dbContext.Plataformas.FirstOrDefaultAsync(x => x.Id == id);

            if (plataforma == null)
                throw new Exception($"Plataforma com ID: {id} não foi encontrado no banco de dados.");

            return plataforma;
        }

        public async Task<List<PlataformaModel>> BuscarTodas()
        {
            return await _dbContext.Plataformas.ToListAsync();
        }
    }
}
