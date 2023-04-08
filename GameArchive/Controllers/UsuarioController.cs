using GameArchive.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace GameArchive.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        //private readonly ITarefaRepositorio _tarefaRepositorio;

        //public TarefaController(ITarefaRepositorio tarefaRepositorio)
        //{
        //    _tarefaRepositorio = tarefaRepositorio;
        //}

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
