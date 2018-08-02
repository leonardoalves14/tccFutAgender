using Newtonsoft.Json;
using SocietyAgendor.UI.Models;
using SocietyAgendor.UI.Service;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SocietyAgendor.UI.Concrete
{
    public class UsuarioService : IUsuarioService
    {
        private const string URL = "http://localhost:50197/api";

        public async Task<List<UsuarioModel>> GetUsuarios()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var usuarios = new List<UsuarioModel>();

            var resposta = await httpClient.GetAsync($"{URL}/usuarios").ConfigureAwait(false);

            if (resposta.IsSuccessStatusCode)
            {
                using (var respostaStream = await resposta.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    return JsonConvert.DeserializeObject<List<UsuarioModel>>(
                        await new StreamReader(respostaStream).
                        ReadToEndAsync().ConfigureAwait(false));
                }
            }

            return usuarios;
        }
    }
}
