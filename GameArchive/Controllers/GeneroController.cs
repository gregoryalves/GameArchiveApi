using GameArchive.Models;
using GameArchive.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameArchive.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        private readonly IGeneroRepositorio _generoRepositorio;

        public GeneroController(IGeneroRepositorio generoRepositorio)
        {
            _generoRepositorio = generoRepositorio;
        }

        [HttpGet("BuscarTodos")]
        public async Task<ActionResult<IEnumerable<GeneroModel>>> BuscarTodos()
        {
            var generos = await _generoRepositorio.BuscarTodos();

            return Ok(generos);
        }

        [HttpGet("BuscarPorId/{id}")]
        public async Task<ActionResult<GeneroModel>> BuscarPorId(int id)
        {
            var genero = await _generoRepositorio.BuscarPorId(id);
            return Ok(genero);
        }

        [HttpGet("BuscarPorNome/{nome}")]
        public async Task<ActionResult<GeneroModel>> BuscarPorNome(string nome)
        {
            var jogos = await _generoRepositorio.BuscarPorNome(nome);
            return Ok(jogos);
        }

        [HttpPost("Cadastrar")]
        public async Task<ActionResult<GeneroModel>> Cadastrar([FromBody] GeneroModel generoModel)
        {
            var genero = await _generoRepositorio.Adicionar(generoModel);

            return Ok(genero);
        }

        [HttpPut("Atualizar/{id}")]
        public async Task<ActionResult<GeneroModel>> Atualizar([FromBody] GeneroModel generoModel, int id)
        {
            generoModel.Id = id;
            var genero = await _generoRepositorio.Atualizar(generoModel, id);
            return Ok(genero);
        }

        [HttpDelete("Apagar/{id}")]
        public async Task<ActionResult<GeneroModel>> Apagar(int id)
        {
            var apagado = await _generoRepositorio.Apagar(id);

            return Ok(apagado);
        }
    }
}
