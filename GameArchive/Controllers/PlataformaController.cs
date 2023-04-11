using GameArchive.Models;
using GameArchive.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameArchive.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlataformaController : ControllerBase
    {
        private readonly IPlataformaRepositorio _plataformaRepositorio;

        public PlataformaController(IPlataformaRepositorio plataformaRepositorio)
        {
            _plataformaRepositorio = plataformaRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlataformaModel>>> BuscarTodos()
        {
            var plataformas = await _plataformaRepositorio.BuscarTodas();

            return Ok(plataformas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlataformaModel>> BuscarPorId(int id)
        {
            var plataforma = await _plataformaRepositorio.BuscarPorId(id);
            return Ok(plataforma);
        }

        [HttpPost]
        public async Task<ActionResult<PlataformaModel>> Cadastrar([FromBody] PlataformaModel plataformaModel)
        {
            var plataforma = await _plataformaRepositorio.Adicionar(plataformaModel);

            return Ok(plataforma);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PlataformaModel>> Atualizar([FromBody] PlataformaModel plataformaModel, int id)
        {
            plataformaModel.Id = id;
            var plataforma = await _plataformaRepositorio.Atualizar(plataformaModel, id);
            return Ok(plataforma);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PlataformaModel>> Apagar(int id)
        {
            var apagada = await _plataformaRepositorio.Apagar(id);

            return Ok(apagada);
        }
    }
}
