using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using DotNetTrainingBatch3.ConsoleApp.Models;
using Microsoft.IdentityModel.Tokens;
using Refit;

namespace DotNetTrainingBatch3.ConsoleApp.RefitExamples
{
    public class RefitExample
    {
        private readonly IBlogApi refitApi = RestService.For<IBlogApi>("https://localhost:7163");


        public async Task Run()
        {
            //await Read();
            //await Edit(1);
            //await Edit(0);
            //await Create("title5", "author5", "content5");
            //await Update(20, "title6", "author6", "content6");
            await Delete(20);

        }

        private async Task Read()
        {

            var lst = await refitApi.GetBlogs();

            foreach (BlogModel item in lst)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);

            }
        }

        private async Task Edit(int id)
        {
            try
            {
                var item = await refitApi.GetBlog(id);
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            }
            catch(Refit.ApiException ex)
            {
                Console.WriteLine(ex.Content);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }
        }

        private async Task Create(string title, string author, string content)
        {

            try
            {
                BlogModel blog = new BlogModel()
                {
                    BlogTitle = title,
                    BlogAuthor = author,
                    BlogContent = content
                };

                string message = await refitApi.CreateBlog(blog);
                Console.WriteLine(message);

            }
            catch (Refit.ApiException ex)
            {
                Console.WriteLine(ex.Content);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }
        }

        private async Task Update(int id, string title, string author, string content)
        {
            try
            {
                BlogModel blog = new BlogModel()
                {
                    BlogTitle = title,
                    BlogAuthor = author,
                    BlogContent = content
                };

                string message = await refitApi.UpdateBlog(id, blog);
                Console.WriteLine(message);
            }
            catch (Refit.ApiException ex)
            {
                Console.WriteLine(ex.Content);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }
        }

        private async Task Delete(int id)
        {
            try
            {
                string message = await refitApi.DeleteBlog(id);
                Console.WriteLine(message);
            }
            catch (Refit.ApiException ex)
            {
                Console.WriteLine(ex.Content);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
                
            }
        }
    }
}
