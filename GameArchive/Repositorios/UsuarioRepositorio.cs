using GameArchive.Data;
using GameArchive.Models;
using Microsoft.EntityFrameworkCore;

namespace GameArchive.Repositorios.Interfaces
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly GameArchiveDbContext _dbContext;

        public UsuarioRepositorio(GameArchiveDbContext gamerArchiveDbContext)
        {
            _dbContext = gamerArchiveDbContext;
        }

        public async Task<List<UsuarioModel>> BuscarTodos()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }

        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            var usuario = await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);

            if (usuario == null)
                throw new Exception($"Usuário com ID: {id} não foi encontrado no banco de dados.");

            return usuario;
        }

        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario;
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            var usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuário com ID: {id} não foi encontrado no banco de dados.");
            }

            usuarioPorId.Nome = usuario.Nome;
            usuarioPorId.Email = usuario.Email;

            _dbContext.Usuarios.Update(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return usuarioPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            var usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuário com ID: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.Usuarios.Remove(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public Task<long> Logar(UsuarioModel usuario)
        {
            throw new NotImplementedException();
        }
    }
}
