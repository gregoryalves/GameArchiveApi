using GameArchive.Models;
using GameArchive.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace GameArchive.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarTodos()
        {
            var usuarios = await _usuarioRepositorio.BuscarTodos();

            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> BuscarPorId(int id)
        {
            var usuario = await _usuarioRepositorio.BuscarPorId(id);
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> Cadastrar([FromBody] UsuarioModel usuarioModel)
        {
            var usuario = await _usuarioRepositorio.Adicionar(usuarioModel);

            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioModel>> Atualizar([FromBody] UsuarioModel usuarioModel, int id)
        {
            usuarioModel.Id = id;
            var usuario = await _usuarioRepositorio.Atualizar(usuarioModel, id);
            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioModel>> Apagar(int id)
        {
            var apagado = await _usuarioRepositorio.Apagar(id);

            return Ok(apagado);
        }

        //[HttpGet]
        //public async Task<int> Logar([FromBody] UsuarioModel usuarioModel)
        //{
        //    var usuarioId = await _usuarioRepositorio.Logar(usuarioModel);

        //    if (usuarioId > 0)
        //        return Ok(usuarioId);

        //    throw new Exception("Usuário ou senha incorretos.");
        //}
    }
}
