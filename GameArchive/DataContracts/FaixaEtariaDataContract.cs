using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace GameArchive.DataContracts
{
    [ComVisible(true)]
    [DataContract]
    public class FaixaEtariaDataContract
    {
        /// <summary>
        /// Campo que informa se possui idade suficiente para o jogo
        /// </summary>
        [DataMember]
        public bool PossuiIdadeMinimaParaJogar { get; set; }

        /// <summary>
        /// Idade do usuário
        /// </summary>
        [DataMember]
        public int Idade { get; set; }

        /// <summary>
        /// Faixa etária do jogo que se está cadastrando para o usuário
        /// </summary>
        [DataMember]
        public int FaixaEtaria { get; set; }
    }
}
