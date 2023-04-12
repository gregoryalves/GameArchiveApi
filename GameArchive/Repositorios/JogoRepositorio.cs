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

        public async Task<IEnumerable<JogoModel>> BuscarPorNome(string nome)
        {
            return await _dbContext.Jogos.Include(x => x.Plataforma)
                                              .Include(x => x.Desenvolvedora)
                                              .Include(x => x.Genero)
                                              .Where(x => x.Nome.Contains(nome)).ToListAsync();
        }

        public async Task<IEnumerable<JogoModel>> BuscarPorPlataforma(string nome)
        {
            var plataformas = await _dbContext.Plataformas.Where(x => x.Nome.Contains(nome)).ToListAsync();
            var plataformasId = plataformas.Select(x => x.Id).ToList();

            var Jogos = await _dbContext.Jogos.Include(x => x.Plataforma)
                                              .Include(x => x.Desenvolvedora)
                                              .Include(x => x.Genero)
                                              .Where(x => plataformasId.Contains(x.PlataformaId)).ToListAsync();

            return Jogos;
        }

        public async Task<IEnumerable<JogoModel>> BuscarPorDesenvolvedora(string nome)
        {
            var desenvolvedoras = await _dbContext.Desenvolvedoras.Where(x => x.Nome.Contains(nome)).ToListAsync();
            var desenvolvedorasId = desenvolvedoras.Select(x => x.Id).ToList();

            var Jogos = await _dbContext.Jogos.Include(x => x.Plataforma)
                                              .Include(x => x.Desenvolvedora)
                                              .Include(x => x.Genero)
                                              .Where(x => desenvolvedorasId.Contains(x.DesenvolvedoraId)).ToListAsync();

            return Jogos;
        }

        public async Task<IEnumerable<JogoModel>> BuscarPorGenero(string nome)
        {
            var generos = await _dbContext.Generos.Where(x => x.Nome.Contains(nome)).ToListAsync();
            var generosId = generos.Select(x => x.Id).ToList();

            var Jogos = await _dbContext.Jogos.Include(x => x.Plataforma)
                                              .Include(x => x.Desenvolvedora)
                                              .Include(x => x.Genero)
                                              .Where(x => generosId.Contains(x.GeneroId)).ToListAsync();

            return Jogos;
        }

        public async Task<IEnumerable<JogoModel>> BuscarTodos()
        {
            return await _dbContext.Jogos.Include(x => x.Plataforma)
                                         .Include(x => x.Desenvolvedora)
                                         .Include(x => x.Genero).ToListAsync();
        }
    }
}
