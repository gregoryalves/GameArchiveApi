using GameArchive.Models;
using GameArchive.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameArchive.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogoController : ControllerBase
    {
        private readonly IJogoRepositorio _jogoRepositorio;

        public JogoController(IJogoRepositorio jogoRepositorio)
        {
            _jogoRepositorio = jogoRepositorio;
        }

        [HttpGet("BuscarTodos")]
        public async Task<ActionResult<IEnumerable<JogoModel>>> BuscarTodos()
        {
            try
            {
                var jogos = await _jogoRepositorio.BuscarTodos();
                return Ok(jogos);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpGet("BuscarPorId/{id}")]
        public async Task<ActionResult<JogoModel>> BuscarPorId(int id)
        {
            try
            {
                var jogo = await _jogoRepositorio.BuscarPorId(id);
                return Ok(jogo);
            }
            catch (Exception ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
        }

        [HttpGet("BuscarPorNome/{nome}")]
        public async Task<ActionResult<JogoModel>> BuscarPorNome(string nome)
        {
            try
            {
                var jogos = await _jogoRepositorio.BuscarPorNome(nome);
                return Ok(jogos);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpGet("BuscarPorPlataforma/{nome}")]
        public async Task<ActionResult<JogoModel>> BuscarPorPlataforma(string nome)
        {
            try
            {
                var jogos = await _jogoRepositorio.BuscarPorPlataforma(nome);
                return Ok(jogos);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpGet("BuscarPorDesenvolvedora/{nome}")]
        public async Task<ActionResult<JogoModel>> BuscarPorDesenvolvedora(string nome)
        {
            try
            {
                var jogos = await _jogoRepositorio.BuscarPorDesenvolvedora(nome);
                return Ok(jogos);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpGet("BuscarPorGenero/{nome}")]
        public async Task<ActionResult<JogoModel>> BuscarPorGenero(string nome)
        {
            try
            {
                var jogos = await _jogoRepositorio.BuscarPorGenero(nome);
                return Ok(jogos);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpPost("Cadastrar")]
        public async Task<ActionResult<JogoModel>> Cadastrar([FromBody] JogoModel jogoModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var jogo = await _jogoRepositorio.Adicionar(jogoModel);
                return CreatedAtAction(nameof(BuscarPorId), new { id = jogo.Id }, jogo);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpPut("Atualizar/{id}")]
        public async Task<ActionResult<JogoModel>> Atualizar([FromBody] JogoModel jogoModel, int id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                jogoModel.Id = id;
                var jogo = await _jogoRepositorio.Atualizar(jogoModel, id);
                return Ok(jogo);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpDelete("Apagar/{id}")]
        public async Task<ActionResult<JogoModel>> Apagar(int id)
        {
            try
            {
                var apagado = await _jogoRepositorio.Apagar(id);
                return Ok(new { mensagem = "Jogo removido com sucesso" });
            }
            catch (Exception ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
        }
    }
}
