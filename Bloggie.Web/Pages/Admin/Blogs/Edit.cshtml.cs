using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Admin.Blogs
{
    public class EditModel : PageModel
    {
        private readonly BloggieDbContext _BloggieDbContext;
        [BindProperty]
        public BlogPost BlogPost { get; set; }
        public EditModel(BloggieDbContext BloggieDbContext)
        {
            _BloggieDbContext = BloggieDbContext;
        }
        public void OnGet(Guid id)
        {
            BlogPost = _BloggieDbContext.BlogPosts.FirstOrDefault(x => x.Id == id);
            
        }

        public IActionResult OnPost()
        {
            var existingBlogPost = _BloggieDbContext.BlogPosts.FirstOrDefault(x => x.Id == BlogPost.Id);
            if (existingBlogPost != null)
            {
                existingBlogPost.Heading = BlogPost.Heading;
                existingBlogPost.ShortDescription = BlogPost.ShortDescription;
                existingBlogPost.Author = BlogPost.Author;
                existingBlogPost.Content = BlogPost.Content;
                existingBlogPost.FeatureImageUrl = BlogPost.FeatureImageUrl;
                existingBlogPost.PageTitle = BlogPost.PageTitle;
                existingBlogPost.PublishedDate = BlogPost.PublishedDate;
                existingBlogPost.UrlHandle = BlogPost.UrlHandle;
                existingBlogPost.Visible = BlogPost.Visible;

                _BloggieDbContext.Update(existingBlogPost);
                _BloggieDbContext.SaveChanges();
            }

            return RedirectToPage("/Admin/Blogs/List");
        }
    }
}
