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
            var usuario = await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == usuarioJogo.UsuarioId);
            var jogo = await _dbContext.Jogos.FirstOrDefaultAsync(x => x.Id == usuarioJogo.JogoId);

            var faixaEtaria = faixaEtariaBusiness.ValidarFaixaEtaria(usuario, jogo);            

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

            IUsuarioJogoBusiness faixaEtariaBusiness = new UsuarioJogoBusiness();
            var usuario = await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == usuarioJogo.UsuarioId);
            var jogo = await _dbContext.Jogos.FirstOrDefaultAsync(x => x.Id == usuarioJogo.JogoId);

            var faixaEtaria = faixaEtariaBusiness.ValidarFaixaEtaria(usuario, jogo);

            if (!faixaEtaria.PossuiIdadeMinimaParaJogar)
                throw new Exception($"Este jogo não é aconselhável, pois você possui {faixaEtaria.Idade} anos e a faixa etária dele é de {faixaEtaria.FaixaEtaria} anos");

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

            PreencheJoinsDaEntidade(usuarioJogo);

            return usuarioJogo;
        }

        public async Task<IEnumerable<UsuarioJogoModel>> BuscarTodos()
        {
            var usuariosJogosRetorno = new List<UsuarioJogoModel>();

            var usuariosJogos = await _dbContext.UsuariosJogos.Include(x => x.Jogo)
                                                 .Include(x => x.Usuario).ToListAsync();

            foreach(var usuarioJogo in usuariosJogos)
            {
                PreencheJoinsDaEntidade(usuarioJogo);
                usuariosJogosRetorno.Add(usuarioJogo);
            }

            return usuariosJogosRetorno;
        }

        public async Task<IEnumerable<UsuarioJogoModel>> BuscarTodosPorUsuario(int usuarioId)
        {
            var usuariosJogosRetorno = new List<UsuarioJogoModel>();

            var usuariosJogos = await _dbContext.UsuariosJogos.Where(x => x.UsuarioId == usuarioId)
                                                       .Include(x => x.Jogo)
                                                       .Include(x => x.Usuario).ToListAsync();

            foreach (var usuarioJogo in usuariosJogos)
            {
                PreencheJoinsDaEntidade(usuarioJogo);
                usuariosJogosRetorno.Add(usuarioJogo);
            }

            return usuariosJogosRetorno;
        }        

        private async void PreencheJoinsDaEntidade(UsuarioJogoModel usuarioJogo)
        {
            var jogo = await _dbContext.Jogos.Include(x => x.Plataforma)
                                             .Include(x => x.Desenvolvedora)
                                             .Include(x => x.Genero).FirstOrDefaultAsync(x => x.Id == usuarioJogo.JogoId);

            usuarioJogo.Jogo = jogo;
            usuarioJogo.Usuario.Senha = string.Empty;
        }
    }
}
