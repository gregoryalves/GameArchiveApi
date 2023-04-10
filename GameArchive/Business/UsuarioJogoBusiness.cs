using GameArchive.Business.Interfaces;
using GameArchive.DataContracts;
using GameArchive.Models;

namespace GameArchive.Business
{
    public class UsuarioJogoBusiness : IUsuarioJogoBusiness
    {
        public FaixaEtariaDataContract ValidarFaixaEtaria(UsuarioJogoModel usuarioJogo)
        {
            var dataNascimento = usuarioJogo.Usuario.DataNascimento;
            var dataAtual = DateTime.Today;

            var idade = RetornarIdade(dataNascimento, dataAtual);
            var faixaEtariaDoJogo = usuarioJogo.Jogo.FaixaEtaria;

            var faixaEtaria = new FaixaEtariaDataContract()
            {
                PossuiIdadeMinimaParaJogar = idade >= faixaEtariaDoJogo,
                FaixaEtaria = faixaEtariaDoJogo,
                Idade = idade
            };

            return faixaEtaria;
        }

        private int RetornarIdade(DateTime dataNascimento, DateTime dataAtual)
        {
            var idade = dataAtual.Year - dataNascimento.Year;

            if (dataNascimento > dataAtual.AddYears(-idade))
                idade--;

            return idade;
        }
    }
}
