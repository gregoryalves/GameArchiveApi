using GameArchive.Models;
using GameArchive.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameArchive.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlataformaUsuarioController : ControllerBase
    {
        private readonly IPlataformaUsuarioRepositorio _plataformaUsuarioRepositorio;

        public PlataformaUsuarioController(IPlataformaUsuarioRepositorio plataformaUsuarioRepositorio)
        {
            _plataformaUsuarioRepositorio = plataformaUsuarioRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<PlataformaUsuarioModel>>> BuscarTodos()
        {
            var plataformasUsuarios = await _plataformaUsuarioRepositorio.BuscarTodos();

            return Ok(plataformasUsuarios);
        }

        [HttpGet("BuscarTodosPorUsuario/{usuarioId}")]
        public async Task<ActionResult<List<PlataformaUsuarioModel>>> BuscarTodosPorUsuario(int usuarioId)
        {
            var plataformasUsuarios = await _plataformaUsuarioRepositorio.BuscarTodosPorUsuario(usuarioId);

            return Ok(plataformasUsuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlataformaUsuarioModel>> BuscarPorId(int id)
        {
            var plataformaUsuario = await _plataformaUsuarioRepositorio.BuscarPorId(id);
            return Ok(plataformaUsuario);
        }

        [HttpPost]
        public async Task<ActionResult<PlataformaUsuarioModel>> Cadastrar([FromBody] PlataformaUsuarioModel plataformaUsuarioModel)
        {
            var plataformaUsuario = await _plataformaUsuarioRepositorio.Adicionar(plataformaUsuarioModel);

            return Ok(plataformaUsuario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PlataformaUsuarioModel>> Atualizar([FromBody] PlataformaUsuarioModel plataformaUsuarioModel, int id)
        {
            plataformaUsuarioModel.Id = id;
            var plataformaUsuario = await _plataformaUsuarioRepositorio.Atualizar(plataformaUsuarioModel, id);
            return Ok(plataformaUsuario);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PlataformaUsuarioModel>> Apagar(int id)
        {
            var apagado = await _plataformaUsuarioRepositorio.Apagar(id);

            return Ok(apagado);
        }
    }
}
