using Dapper;
using Microsoft.Extensions.Configuration;
using SocietyAgendor.API.Entities;
using SocietyAgendor.API.Services;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace SocietyAgendor.API.Concrete
{
    public class UsuarioRepository : Base.Base, IUsuarioRepository
    {
        public UsuarioRepository(IConfiguration configuration) : base(configuration) { }

        public List<Usuario> GetAllUsuarios()
        {
            return ExecuteSP<Usuario>("spsUsuario");
        }

        public Usuario CreateUsuario(Usuario model)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Usuario_Id", model.UsuarioId, System.Data.DbType.Int32, System.Data.ParameterDirection.InputOutput);
            parameters.Add("@Usuario_Login", model.UsuarioLogin, System.Data.DbType.String);

            ExecuteSP("spiUsuario", parameters);
            model.UsuarioId = parameters.Get<int>("@Usuario_Id");

            return model;
        }

        public void UpdateUsuario(Usuario model)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Usuario_Id", model.UsuarioId, System.Data.DbType.Int32);
            parameters.Add("@Usuario_Login", model.UsuarioLogin, System.Data.DbType.String);

            ExecuteSP("spuUsuario", parameters);
        }

        public void DeleteUsuario(int usuarioId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Usuario_Id", usuarioId, System.Data.DbType.Int32);

            ExecuteSP("spdUsuario", parameters);
        }

        public void UpdateUsuarioSenha(Usuario model)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Usuario_Id", model.UsuarioId, System.Data.DbType.Int32);
            parameters.Add("@Usuario_Senha", SHA1Crypto(model.UsuarioSenha), System.Data.DbType.String);

            ExecuteSP("spuUsuarioSenha", parameters);
        }

        /// <summary>
        /// Método responsável pela criptografia SHA1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private string SHA1Crypto(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }

            SHA1 sha = new SHA1CryptoServiceProvider();
            var hashedData = sha.ComputeHash(Encoding.Unicode.GetBytes(value));
            var sha1text = string.Empty;

            foreach (var b in hashedData)
            {
                sha1text += string.Format("{0,2:X2}", b);
            }

            return sha1text;
        }
    }
}
