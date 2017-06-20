using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TesteConsumoWebApi
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAsync().Wait();
            Console.ReadKey();
        }

        static async Task RunAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://webapisistemastrabalhofinal.azurewebsites.net");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("apllication/json"));

                var t = new Aluno()
                {
                    Nome = "Rodrigo",
                    Idade = 18
                };

                ////WebApi POST
                HttpResponseMessage response = await client.PostAsJsonAsync("/aluno/cadastrarAluno", t);


                //WebApi GET
                response = await client.GetAsync("aluno/buscar");

                //Resposta vira uma string 
                var r = await response.Content.ReadAsAsync<List<Aluno>>();

                //Utilizando o ReadAsAsync, precisamos ter uma classe que contem os atribuitos com o mesmo nome da resposta
                //var r = await response.Content.ReadAsAsync<T>();;
            }
        }
    }
}
