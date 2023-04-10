using GameArchive.Business;
using GameArchive.Business.Interfaces;
using GameArchive.Data;
using GameArchive.Models;
using Microsoft.EntityFrameworkCore;

namespace GameArchive.Repositorios.Interfaces
{
    public class UsuarioJogoRepositorio : IUsuarioJogoRepositorio
    {
        private readonly GameArchiveDbContext _dbContext;

        public UsuarioJogoRepositorio(GameArchiveDbContext gamerArchiveDbContext)
        {
            _dbContext = gamerArchiveDbContext;
        }

        public async Task<UsuarioJogoModel> Adicionar(UsuarioJogoModel usuarioJogo)
        {
            IUsuarioJogoBusiness faixaEtariaBusiness = new UsuarioJogoBusiness();
            var faixaEtaria = faixaEtariaBusiness.ValidarFaixaEtaria(usuarioJogo);            

            if (!faixaEtaria.PossuiIdadeMinimaParaJogar)
                throw new Exception($"Este jogo não é aconselhável, pois você possui {faixaEtaria.Idade} anos e a faixa etária dele é de {faixaEtaria.FaixaEtaria} anos");

            await _dbContext.UsuariosJogos.AddAsync(usuarioJogo);
            await _dbContext.SaveChangesAsync();

            return usuarioJogo;
        }        

        public async Task<bool> Apagar(int id)
        {
            var usuarioJogoPorId = await BuscarPorId(id);

            if (usuarioJogoPorId == null)
            {
                throw new Exception($"Jogo do usuário com ID: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.UsuariosJogos.Remove(usuarioJogoPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<UsuarioJogoModel> Atualizar(UsuarioJogoModel usuarioJogo, int id)
        {
            var usuarioJogoPorId = await BuscarPorId(id);

            if (usuarioJogoPorId == null)
            {
                throw new Exception($"Jogo do usuário com ID: {id} não foi encontrado no banco de dados.");
            }

            usuarioJogoPorId.EhMidiaFisica = usuarioJogo.EhMidiaFisica;
            usuarioJogoPorId.UsuarioId = usuarioJogo.UsuarioId;
            usuarioJogoPorId.JogoId = usuarioJogo.JogoId;
            usuarioJogoPorId.DataAquisicao = usuarioJogo.DataAquisicao;
            usuarioJogoPorId.Descricao = usuarioJogo.Descricao;
            usuarioJogoPorId.JaZerado = usuarioJogo.JaZerado;
            usuarioJogoPorId.Nota = usuarioJogo.Nota;
            usuarioJogoPorId.PrecoPago = usuarioJogo.PrecoPago;

            _dbContext.UsuariosJogos.Update(usuarioJogoPorId);
            await _dbContext.SaveChangesAsync();

            return usuarioJogoPorId;
        }

        public async Task<UsuarioJogoModel> BuscarPorId(int id)
        {
            var usuarioJogo = await _dbContext.UsuariosJogos.Include(x => x.Jogo)
                                                            .Include(x => x.Usuario).FirstOrDefaultAsync(x => x.Id == id);

            if (usuarioJogo == null)
                throw new Exception($"Jogo do usuário com ID: {id} não foi encontrado no banco de dados.");

            return usuarioJogo;
        }

        public async Task<List<UsuarioJogoModel>> BuscarTodos()
        {
            return await _dbContext.UsuariosJogos.Include(x => x.Jogo)
                                                 .Include(x => x.Usuario).ToListAsync();
        }

        public async Task<List<UsuarioJogoModel>> BuscarTodosPorUsuario(int usuarioId)
        {
            return await _dbContext.UsuariosJogos.Where(x => x.UsuarioId == usuarioId)
                                                       .Include(x => x.Jogo)
                                                       .Include(x => x.Usuario).ToListAsync();
        }        
    }
}
