using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using DotNetTrainingBatch3.ConsoleApp.Models;
using Newtonsoft.Json;
using RestSharp;

namespace DotNetTrainingBatch3.ConsoleApp.RestClientExamples
{
    public class RestClientExample
    {
        private readonly string _apiUrl = "https://localhost:7163/api/Blog";
        public async Task Run()
        {
            await Read();
            //await ReadJsonPlaceHolder();
            //await Edit(1);
            //await Create("title1", "author1", "content1");
            //await Update(18,"title2", "author2", "content2");
            //await Delete(18);

        }

        private async Task Read()
        {
            RestRequest request = new RestRequest(_apiUrl, Method.Get);
            RestClient restClient = new RestClient();
            RestResponse response = await restClient.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = response.Content!;
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
            else
            {
                Console.WriteLine(response.Content);
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

        private async Task Edit(int id)
        {
            string url = $"{_apiUrl}/{id}";
            RestRequest request = new RestRequest(url, Method.Get);
            RestClient restClient = new RestClient();
            RestResponse response = await restClient.ExecuteAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string jsonStr = response.Content!;


                BlogModel item = JsonConvert.DeserializeObject<BlogModel>(jsonStr)!;


                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);


            }
            else
            {
                Console.WriteLine(response.Content);
            }
        }

        private async Task Create(string title, string author, string content)
        {
            BlogModel blog = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            RestRequest request = new RestRequest(_apiUrl, Method.Post);
            request.AddJsonBody(blog);
            RestClient restClient = new RestClient();
            RestResponse response = await restClient.ExecuteAsync(request);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.Content);


            }
            else
            {
                Console.WriteLine(response.Content);
            }
        }

        private async Task Update(int id, string title, string author, string content)
        {
            BlogModel blog = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            string url = $"{_apiUrl}/{id}";
            RestRequest request = new RestRequest(url, Method.Put);
            request.AddJsonBody(blog);
            RestClient restClient = new RestClient();
            RestResponse response = await restClient.ExecuteAsync(request);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.Content);


            }
            else
            {
                Console.WriteLine(response.Content!);
            }
        }

        private async Task Delete(int id)
        {
            string url = $"{_apiUrl}/{id}";
            RestRequest request = new RestRequest(url, Method.Delete);
            RestClient restClient = new RestClient();
            RestResponse response = await restClient.ExecuteAsync(request);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.Content!);
            }
            else
            {
                Console.WriteLine(response.Content!);
            }
        }
    }
}
