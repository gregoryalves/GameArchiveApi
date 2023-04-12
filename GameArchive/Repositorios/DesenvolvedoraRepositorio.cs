using GameArchive.Data;
using GameArchive.Models;
using Microsoft.EntityFrameworkCore;

namespace GameArchive.Repositorios.Interfaces
{
    public class DesenvolvedoraRepositorio : IDesenvolvedoraRepositorio
    {
        private readonly GameArchiveDbContext _dbContext;

        public DesenvolvedoraRepositorio(GameArchiveDbContext gamerArchiveDbContext)
        {
            _dbContext = gamerArchiveDbContext;
        }

        public async Task<DesenvolvedoraModel> Adicionar(DesenvolvedoraModel desenvolvedora)
        {
            await _dbContext.Desenvolvedoras.AddAsync(desenvolvedora);
            await _dbContext.SaveChangesAsync();

            return desenvolvedora;
        }

        public async Task<bool> Apagar(int id)
        {
            var desenvolvedoraId = await BuscarPorId(id);

            if (desenvolvedoraId == null)
            {
                throw new Exception($"Desenvolvedora com ID: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.Desenvolvedoras.Remove(desenvolvedoraId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<DesenvolvedoraModel> Atualizar(DesenvolvedoraModel desenvolvedora, int id)
        {
            var desenvolvedoraPorId = await BuscarPorId(id);

            if (desenvolvedoraPorId == null)
            {
                throw new Exception($"Desenvolvedora com ID: {id} não foi encontrado no banco de dados.");
            }

            desenvolvedoraPorId.Nome = desenvolvedora.Nome;

            _dbContext.Desenvolvedoras.Update(desenvolvedoraPorId);
            await _dbContext.SaveChangesAsync();

            return desenvolvedoraPorId;
        }

        public async Task<DesenvolvedoraModel> BuscarPorId(int id)
        {
            var desenvolvedora = await _dbContext.Desenvolvedoras.FirstOrDefaultAsync(x => x.Id == id);

            if (desenvolvedora == null)
                throw new Exception($"Desenvolvedora com ID: {id} não foi encontrado no banco de dados.");

            return desenvolvedora;
        }

        public async Task<IEnumerable<DesenvolvedoraModel>> BuscarPorNome(string nome)
        {
            return await _dbContext.Desenvolvedoras.Where(x => x.Nome.Contains(nome)).ToListAsync();
        }

        public async Task<IEnumerable<DesenvolvedoraModel>> BuscarTodas()
        {
            return await _dbContext.Desenvolvedoras.ToListAsync();
        }
    }
}
