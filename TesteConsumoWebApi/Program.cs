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
                client.BaseAddress = new Uri("http://localhost:64349/aluno/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("apllication/json"));

                var t = new Aluno()
                {
                    Nome = "Guilherme",
                    Idade = 18
                };

                //WebApi POST
                HttpResponseMessage response = await client.PostAsJsonAsync("cadastrarAluno", t);

                
                //WebApi GET
                response = await client.GetAsync("buscar");

                //Resposta vira uma string 
                var r = await response.Content.ReadAsAsync<Aluno>();

                //Utilizando o ReadAsAsync, precisamos ter uma classe que contem os atribuitos com o mesmo nome da resposta
                //var r = await response.Content.ReadAsAsync<T>();;
            }
        }
    }
}
