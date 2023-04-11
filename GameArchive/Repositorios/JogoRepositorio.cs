using GameArchive.Data;
using GameArchive.Models;
using Microsoft.EntityFrameworkCore;

namespace GameArchive.Repositorios.Interfaces
{
    public class JogoRepositorio : IJogoRepositorio
    {
        private readonly GameArchiveDbContext _dbContext;

        public JogoRepositorio(GameArchiveDbContext gamerArchiveDbContext)
        {
            _dbContext = gamerArchiveDbContext;
        }

        public async Task<JogoModel> Adicionar(JogoModel jogo)
        {
            await _dbContext.Jogos.AddAsync(jogo);
            await _dbContext.SaveChangesAsync();

            return jogo;
        }

        public async Task<bool> Apagar(int id)
        {
            var jogoPorId = await BuscarPorId(id);

            if (jogoPorId == null)
            {
                throw new Exception($"Jogo com ID: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.Jogos.Remove(jogoPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<JogoModel> Atualizar(JogoModel jogo, int id)
        {
            var jogosPorId = await BuscarPorId(id);

            if (jogosPorId == null)
            {
                throw new Exception($"Jogo com ID: {id} não foi encontrado no banco de dados.");
            }

            jogosPorId.Nome = jogo.Nome;
            jogosPorId.PlataformaId = jogo.PlataformaId;
            jogosPorId.DesenvolvedoraId = jogo.DesenvolvedoraId;
            jogosPorId.GeneroId = jogo.GeneroId;
            jogosPorId.FaixaEtaria = jogo.FaixaEtaria;

            _dbContext.Jogos.Update(jogosPorId);
            await _dbContext.SaveChangesAsync();

            return jogosPorId;
        }

        public async Task<JogoModel> BuscarPorId(int id)
        {
            var jogo = await _dbContext.Jogos.Include(x => x.Plataforma)
                                             .Include(x => x.Desenvolvedora)
                                             .Include(x => x.Genero).FirstOrDefaultAsync(x => x.Id == id);

            if (jogo == null)
                throw new Exception($"Jogo com ID: {id} não foi encontrado no banco de dados.");

            return jogo;
        }

        public async Task<IEnumerable<JogoModel>> BuscarTodos()
        {
            return await _dbContext.Jogos.Include(x => x.Plataforma)
                                         .Include(x => x.Desenvolvedora)
                                         .Include(x => x.Genero).ToListAsync();
        }
    }
}
