using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetTrainingBatch3.ConsoleApp.Models;
using Newtonsoft.Json;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DotNetTrainingBatch3.ConsoleApp.HttpClientExamples
{
    public class HttpClientExample
    {
        public async Task Run()
        {
            //await Read();
            await ReadJsonPlaceHolder();
        }

        private async Task Read()
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response  = await httpClient.GetAsync("https://localhost:7163/api/Blog");

            if(response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                Console.WriteLine(jsonStr);

                //JsonConvert.SerializeObject(jsonStr); C# object to json
                //JsonConvert.DeserializeObject(jsonStr); json object to C# object

                List<BlogModel> lst = JsonConvert.DeserializeObject<List<BlogModel>>(jsonStr)!;

                foreach (BlogModel item in lst)
                {
                    Console.WriteLine(item.BlogId);
                    Console.WriteLine(item.BlogTitle);
                    Console.WriteLine(item.BlogAuthor);
                    Console.WriteLine(item.BlogContent);

                }
            }
        }


        private async Task ReadJsonPlaceHolder()
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts");

            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                Console.WriteLine(jsonStr);

                //JsonConvert.SerializeObject(jsonStr); C# object to json
                //JsonConvert.DeserializeObject(jsonStr); json object to C# object

                List<JsonPlaceHolderModel> lst = JsonConvert.DeserializeObject<List<JsonPlaceHolderModel>>(jsonStr)!;

                foreach (JsonPlaceHolderModel item in lst)
                {
                    Console.WriteLine(item.title);
                    Console.WriteLine(item.body);
                    Console.WriteLine(item.id);
                    Console.WriteLine(item.userId);

                }
            }
        }
    }
}
