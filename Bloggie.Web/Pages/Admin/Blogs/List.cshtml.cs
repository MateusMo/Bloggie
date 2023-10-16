using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.Pages.Admin.Blogs
{
    public class ListModel : PageModel
    {
        private readonly IBlogPostRepository _IBlogPostRepository;
        public List<BlogPost> BlogPosts { get; set; }
        public ListModel(IBlogPostRepository IBlogPostRepository)
        {
            _IBlogPostRepository = IBlogPostRepository;
        }
        public async Task OnGet()
        {
            BlogPosts = await _IBlogPostRepository.GetAllAsync();
        }
    }
}
