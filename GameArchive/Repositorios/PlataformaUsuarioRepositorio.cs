using GameArchive.Data;
using GameArchive.Models;
using Microsoft.EntityFrameworkCore;

namespace GameArchive.Repositorios.Interfaces
{
    public class PlataformaUsuarioRepositorio : IPlataformaUsuarioRepositorio
    {
        private readonly GameArchiveDbContext _dbContext;

        public PlataformaUsuarioRepositorio(GameArchiveDbContext gamerArchiveDbContext)
        {
            _dbContext = gamerArchiveDbContext;
        }

        public async Task<PlataformaUsuarioModel> Adicionar(PlataformaUsuarioModel plataformaUsuario)
        {
            await _dbContext.PlataformasUsuarios.AddAsync(plataformaUsuario);
            await _dbContext.SaveChangesAsync();

            return plataformaUsuario;
        }

        public async Task<bool> Apagar(int id)
        {
            var plataformaUsuarioPorId = await BuscarPorId(id);

            if (plataformaUsuarioPorId == null)
            {
                throw new Exception($"Plataforma do usuário com ID: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.PlataformasUsuarios.Remove(plataformaUsuarioPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<PlataformaUsuarioModel> Atualizar(PlataformaUsuarioModel plataformaUsuario, int id)
        {
            var plataformaUsuarioPorId = await BuscarPorId(id);

            if (plataformaUsuarioPorId == null)
            {
                throw new Exception($"Plataforma do usuário com ID: {id} não foi encontrado no banco de dados.");
            }

            plataformaUsuarioPorId.Nome = plataformaUsuario.Nome;
            plataformaUsuarioPorId.PlataformaId = plataformaUsuario.PlataformaId;
            plataformaUsuarioPorId.UsuarioId = plataformaUsuario.UsuarioId;
            plataformaUsuarioPorId.Controles = plataformaUsuario.Controles;

            _dbContext.PlataformasUsuarios.Update(plataformaUsuarioPorId);
            await _dbContext.SaveChangesAsync();

            return plataformaUsuarioPorId;
        }

        public async Task<PlataformaUsuarioModel> BuscarPorId(int id)
        {
            var plataformaUsuario = await _dbContext.PlataformasUsuarios.Include(x => x.Usuario)
                                                                        .Include(x => x.Plataforma).FirstOrDefaultAsync(x => x.Id == id);

            if (plataformaUsuario == null)
                throw new Exception($"Plataforma do usuário com ID: {id} não foi encontrado no banco de dados.");

            plataformaUsuario.Usuario.Senha = string.Empty;

            return plataformaUsuario;
        }

        public async Task<IEnumerable<PlataformaUsuarioModel>> BuscarTodos()
        {
            var plataformasUsuariosRetorno = new List<PlataformaUsuarioModel>();

            var plataformasUsuarios = await _dbContext.PlataformasUsuarios.Include(x => x.Usuario)
                                                       .Include(x => x.Plataforma).ToListAsync();

            foreach (var plataformaUsuario in plataformasUsuarios)
            {
                plataformaUsuario.Usuario.Senha = string.Empty;
                plataformasUsuariosRetorno.Add(plataformaUsuario);
            }

            return plataformasUsuariosRetorno;
        }

        public async Task<IEnumerable<PlataformaUsuarioModel>> BuscarTodosPorUsuario(int usuarioId)
        {
            var plataformasUsuariosRetorno = new List<PlataformaUsuarioModel>();

            var plataformasUsuarios = await _dbContext.PlataformasUsuarios.Where(x => x.UsuarioId == usuarioId)
                                                       .Include(x => x.Usuario)
                                                       .Include(x => x.Plataforma).ToListAsync();

            foreach(var plataformaUsuario in plataformasUsuarios)
            {
                plataformaUsuario.Usuario.Senha = string.Empty;
                plataformasUsuariosRetorno.Add(plataformaUsuario);
            }

            return plataformasUsuariosRetorno;
        }
    }
}
