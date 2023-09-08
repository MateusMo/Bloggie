using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Admin.Blogs
{
    public class ListModel : PageModel
    {
        private readonly BloggieDbContext _BloggieDbContext;
        public List<BlogPost> BlogPosts { get; set; }
        public ListModel(BloggieDbContext BloggieDbContext)
        {
            _BloggieDbContext = BloggieDbContext;
        }
        public void OnGet()
        {
            BlogPosts = _BloggieDbContext.BlogPosts.ToList();


        }
    }
}
