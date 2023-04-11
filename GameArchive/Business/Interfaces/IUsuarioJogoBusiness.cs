using GameArchive.DataContracts;
using GameArchive.Models;

namespace GameArchive.Business.Interfaces
{
    public interface IUsuarioJogoBusiness
    {
        FaixaEtariaDataContract ValidarFaixaEtaria(UsuarioModel usuario, JogoModel jogo);
    }
}
