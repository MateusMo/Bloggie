using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Bloggie.Web.Models.ViewModels;
using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Admin.Blogs
{
    public class AddModel : PageModel
    {
        private readonly IBlogPostRepository _IBlogPostRepository;

        [BindProperty]
        public AddBlogPost AddBlogPostRequest { get; set; }

        public AddModel(IBlogPostRepository IBlogPostRepository)
        {
            _IBlogPostRepository = IBlogPostRepository;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
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

            await _IBlogPostRepository.AddAsync(blogPost);

            return RedirectToPage("/Admin/Blogs/List");
        }
    }
}
