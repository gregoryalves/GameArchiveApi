using GameArchive.Business;
using GameArchive.Business.Interfaces;
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

        public async Task<IEnumerable<UsuarioModel>> BuscarTodos()
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
            IUsuarioBusiness usuarioBusiness = new UsuarioBusiness();

            var jaPossuiEmailNaBase = await usuarioBusiness.ValidarEmailJaCadastrado(_dbContext, usuario);

            if (jaPossuiEmailNaBase)
            {
                throw new Exception($"O E-mail informado já está cadastrado.");
            }

            usuario.Senha = usuarioBusiness.GerarHashMd5(usuario.Senha);

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

            IUsuarioBusiness usuarioBusiness = new UsuarioBusiness();

            var jaPossuiEmailNaBase = await usuarioBusiness.ValidarEmailJaCadastrado(_dbContext, usuario);

            if (jaPossuiEmailNaBase)
            {
                throw new Exception($"O E-mail informado já está cadastrado.");
            }

            usuario.Senha = usuarioBusiness.GerarHashMd5(usuario.Senha);

            usuarioPorId.Nome = usuario.Nome;
            usuarioPorId.DataNascimento = usuario.DataNascimento;
            usuarioPorId.Email = usuario.Email;
            usuarioPorId.Senha = usuario.Senha;

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

        public async Task<int> Logar(UsuarioModel usuario)
        {
            IUsuarioBusiness usuarioBusiness = new UsuarioBusiness();
            usuario.Senha = usuarioBusiness.GerarHashMd5(usuario.Senha);

            var usuarioRetornado = await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Email == usuario.Email && x.Senha == usuario.Senha);

            if (usuarioRetornado == null)
            {
                throw new Exception($"E-mail ou senha inválidos.");
            }

            return usuarioRetornado.Id;
        }
    }
}
