using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Bloggie.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Admin.Blogs
{
    public class AddModel : PageModel
    {
        [BindProperty]
        public AddBlogPost AddBlogPostRequest { get; set; }

        private readonly BloggieDbContext _BloggieDbContext;
        public AddModel(BloggieDbContext BloggieDbContext)
        {
            _BloggieDbContext = BloggieDbContext;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost() 
        {
            var blogPost = new BlogPost()
            {
                Heading = AddBlogPostRequest.Heading,
                Content = AddBlogPostRequest.Content,
                PageTitle = AddBlogPostRequest.PageTitle,
                ShortDescription = AddBlogPostRequest.ShortDescription,
                FeatureImageUrl = AddBlogPostRequest.FeatureImageUrl,
                UrlHandle = AddBlogPostRequest.UrlHandle,
                PublishedDate = AddBlogPostRequest.PublishedDate,
                Author = AddBlogPostRequest.Author,
                Visible = AddBlogPostRequest.Visible,
            };

            _BloggieDbContext.BlogPosts.Add(blogPost);
            _BloggieDbContext.SaveChanges();

            return RedirectToPage("/Admin/Blogs/List");
        }
    }
}
