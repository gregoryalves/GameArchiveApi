﻿using GameArchive.Api.DataContracts;
using GameArchive.Models;

namespace GameArchive.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<IEnumerable<UsuarioModel>> BuscarTodos();
        Task<UsuarioModel> BuscarPorId(int id);
        Task<UsuarioModel> Adicionar(UsuarioModel usuario);
        Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id);
        Task<bool> Apagar(int id);
        Task<int> Logar(LoginDataContract usuarioLogin);
    }
}
