using System.Runtime.Serialization;

namespace GameArchive.DataContracts
{
    [DataContract]
    public class FaixaEtariaDataContract
    {
        [DataMember]
        public bool PossuiIdadeMinimaParaJogar { get; set; }

        [DataMember]
        public int Idade { get; set; }

        [DataMember]
        public int FaixaEtaria { get; set; }
    }
}
