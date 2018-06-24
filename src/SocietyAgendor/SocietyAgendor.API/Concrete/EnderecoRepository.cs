using Dapper;
using Microsoft.Extensions.Configuration;
using SocietyAgendor.API.Entities;
using SocietyAgendor.API.Services;
using System.Collections.Generic;
using System.Linq;

namespace SocietyAgendor.API.Concrete
{
    public class EnderecoRepository : Base.Base, IEnderecoRepository
    {
        public EnderecoRepository(IConfiguration configuration) : base(configuration) { }

        public bool EnderecoExists(int enderecoId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Endereco_Id", enderecoId, System.Data.DbType.Int32);

            var endereco = new List<HelperEntity>();
            var list = ExecuteSP<HelperEntity>("speEndereco", parameters);

            foreach (var item in list)
            {
                endereco.Add(item);
            }

            if (endereco.FirstOrDefault().Exists)
                return true;
            else
                return false;
        }
    }
}
