using GameArchive.Data;
using GameArchive.Models;
using Microsoft.EntityFrameworkCore;

namespace GameArchive.Repositorios.Interfaces
{
    public class GeneroRepositorio : IGeneroRepositorio
    {
        private readonly GameArchiveDbContext _dbContext;

        public GeneroRepositorio(GameArchiveDbContext gamerArchiveDbContext)
        {
            _dbContext = gamerArchiveDbContext;
        }

        public async Task<GeneroModel> Adicionar(GeneroModel genero)
        {
            await _dbContext.Generos.AddAsync(genero);
            await _dbContext.SaveChangesAsync();

            return genero;
        }

        public async Task<bool> Apagar(int id)
        {
            var generoId = await BuscarPorId(id);

            if (generoId == null)
            {
                throw new Exception($"Gênero com ID: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.Generos.Remove(generoId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<GeneroModel> Atualizar(GeneroModel genero, int id)
        {
            var generoPorId = await BuscarPorId(id);

            if (generoPorId == null)
            {
                throw new Exception($"Gênero com ID: {id} não foi encontrado no banco de dados.");
            }

            generoPorId.Nome = genero.Nome;

            _dbContext.Generos.Update(generoPorId);
            await _dbContext.SaveChangesAsync();

            return generoPorId;
        }

        public async Task<GeneroModel> BuscarPorId(int id)
        {
            var genero = await _dbContext.Generos.FirstOrDefaultAsync(x => x.Id == id);

            if (genero == null)
                throw new Exception($"Gênero com ID: {id} não foi encontrado no banco de dados.");

            return genero;
        }

        public async Task<List<GeneroModel>> BuscarTodos()
        {
            return await _dbContext.Generos.ToListAsync();
        }
    }
}
