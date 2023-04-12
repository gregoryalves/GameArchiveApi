using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace GameArchive.Api.DataContracts
{
    [ComVisible(true)]
    [DataContract]
    public class LoginDataContract
    {
        /// <summary>
        /// Campo com o Email do usuário logando
        /// </summary>
        [DataMember]
        public string? Email { get; set; }

        /// <summary>
        /// Campo com o campo a senha do usuário logando
        /// </summary>
        [DataMember]
        public string? Senha { get; set; }
    }
}
