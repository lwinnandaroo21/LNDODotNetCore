using DotNetTrainingBatch3.MvcApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTrainingBatch3.MvcApp.Controllers
{
    public class BlogController : Controller
    {

        private readonly AddDbContext _context;

        public BlogController ()
        {
            _context = new AddDbContext ();
        }

        //https://localhost:7187/Blog/Index
        [ActionName("Index")]
        public IActionResult BlogIndex()
        {
            List<BlogModel> lst = _context.Blogs.ToList();
            return View("BlogIndex",lst);
        }
    }
}
