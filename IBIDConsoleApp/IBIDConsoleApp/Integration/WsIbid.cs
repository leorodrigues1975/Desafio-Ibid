using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBIDConsoleApp.Integration
{
    public static class WsIbid
    {
        public static string GetToken()
        {

            string retornaToken = "";

            string arquivoToken = Directory.GetCurrentDirectory() + @"\Token.txt";
            if (File.Exists(arquivoToken))
            {
                string jsonToken = File.ReadAllText(arquivoToken);
                var token = JsonConvert.DeserializeObject<dynamic>(jsonToken);
                if (Convert.ToDateTime(token.expiration) > DateTime.Now)
                {
                    return token.token;
                }

                File.Delete(arquivoToken);
            }


            dynamic userToken = new ExpandoObject();
            userToken.usuario = "IBID";
            userToken.senha = "senhaProcessoSeletivo@ibid";

            string body = JsonConvert.SerializeObject(userToken);

            var client = new RestClient("https://wsibid.portaldecompras.co/api/v1/Token");

            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");

            request.AddBody(body);

            RestResponse response = client.Execute(request, Method.Post);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var objetoTokenRetorno = JsonConvert.DeserializeObject<dynamic>(response.Content);
                retornaToken = objetoTokenRetorno.token;

                using var file = new StreamWriter(arquivoToken);
                file.WriteLine(response.Content);
                file.Close();
            }

            return retornaToken;
        }
    }
}
