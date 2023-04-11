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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GeneroModel>>> BuscarTodos()
        {
            var generos = await _generoRepositorio.BuscarTodos();

            return Ok(generos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GeneroModel>> BuscarPorId(int id)
        {
            var genero = await _generoRepositorio.BuscarPorId(id);
            return Ok(genero);
        }

        [HttpPost]
        public async Task<ActionResult<GeneroModel>> Cadastrar([FromBody] GeneroModel generoModel)
        {
            var genero = await _generoRepositorio.Adicionar(generoModel);

            return Ok(genero);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GeneroModel>> Atualizar([FromBody] GeneroModel generoModel, int id)
        {
            generoModel.Id = id;
            var genero = await _generoRepositorio.Atualizar(generoModel, id);
            return Ok(genero);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<GeneroModel>> Apagar(int id)
        {
            var apagado = await _generoRepositorio.Apagar(id);

            return Ok(apagado);
        }
    }
}
