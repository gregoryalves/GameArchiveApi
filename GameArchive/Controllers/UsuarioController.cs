using GameArchive.Api.DataContracts;
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

        [HttpGet("BuscarTodos")]
        public async Task<ActionResult<IEnumerable<UsuarioModel>>> BuscarTodos()
        {
            try
            {
                var usuarios = await _usuarioRepositorio.BuscarTodos();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpGet("BuscarPorId/{id}")]
        public async Task<ActionResult<UsuarioModel>> BuscarPorId(int id)
        {
            try
            {
                var usuario = await _usuarioRepositorio.BuscarPorId(id);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
        }

        [HttpPost("Cadastrar")]
        public async Task<ActionResult<UsuarioModel>> Cadastrar([FromBody] UsuarioModel usuarioModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var usuario = await _usuarioRepositorio.Adicionar(usuarioModel);
                return CreatedAtAction(nameof(BuscarPorId), new { id = usuario.Id }, usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpPut("Atualizar/{id}")]
        public async Task<ActionResult<UsuarioModel>> Atualizar([FromBody] UsuarioModel usuarioModel, int id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                usuarioModel.Id = id;
                var usuario = await _usuarioRepositorio.Atualizar(usuarioModel, id);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpDelete("Apagar/{id}")]
        public async Task<ActionResult<UsuarioModel>> Apagar(int id)
        {
            try
            {
                var apagado = await _usuarioRepositorio.Apagar(id);
                return Ok(new { mensagem = "Usuário removido com sucesso" });
            }
            catch (Exception ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
        }

        [HttpPost("Logar")]
        public async Task<ActionResult<int>> Logar([FromBody] LoginDataContract usuarioLogin)
        {
            try
            {
                var usuarioId = await _usuarioRepositorio.Logar(usuarioLogin);
                return Ok(new { usuarioId });
            }
            catch (Exception ex)
            {
                return Unauthorized(new { mensagem = ex.Message });
            }
        }
    }
}
