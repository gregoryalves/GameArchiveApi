using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace GameArchive.Api.DataContracts
{
    [ComVisible(true)]
    [DataContract]
    public class UsuarioENomeDataContract
    {
        /// <summary>
        /// Campo com o Id do usuário
        /// </summary>
        [DataMember]
        public int UsuarioId { get; set; }

        /// <summary>
        /// Campo com o campo de busca Nome
        /// </summary>
        [DataMember]
        public string? Nome { get; set; }
    }
}
