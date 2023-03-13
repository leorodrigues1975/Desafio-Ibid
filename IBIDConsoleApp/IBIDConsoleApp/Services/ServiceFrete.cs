using IBIDConsoleApp.Model;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;


namespace IBIDConsoleApp.Services
{
    public class ServiceFrete
    {
        public static Frete Consultar(string codigo)
        {
            string token = Integration.WsIbid.GetToken();

            var client = new RestClient($"https://wsibid.portaldecompras.co/api/v1/Cadastro/Frete/?codigoERP={codigo}");
            
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json")
            .AddHeader("Authorization", $"Bearer {token}");

            RestResponse response = client.Execute(request, Method.Get);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<Frete>(response.Content);
            }

            return null;
        }

        public static dynamic Adicionar(Frete Frete)
        {
            string body = JsonConvert.SerializeObject(Frete);

            string token = Integration.WsIbid.GetToken();

            var client = new RestClient("https://wsibid.portaldecompras.co/api/v1/Cadastro/Frete");

            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json")
            .AddHeader("Authorization", $"Bearer {token}")
            .AddBody(body);

            RestResponse response = client.Execute(request, Method.Post);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<dynamic>(response.Content);
            }

            return null;
        }

    }
}
