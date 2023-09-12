using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

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
        public async Task OnGet(Guid id)
        {
            BlogPost = await _BloggieDbContext.BlogPosts.FirstOrDefaultAsync(x => x.Id == id);
            
        }

        public async Task<IActionResult> OnPostEdit()
        {
            var existingBlogPost = await _BloggieDbContext.BlogPosts.FirstOrDefaultAsync(x => x.Id == BlogPost.Id);
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
                await _BloggieDbContext.SaveChangesAsync();
            }

            return RedirectToPage("/Admin/Blogs/List");
        }
        
        public async Task<IActionResult> OnPostDelete()
        {
            var existingBlogPost = await _BloggieDbContext.BlogPosts.FirstOrDefaultAsync(x => x.Id == BlogPost.Id);
            if(existingBlogPost != null)
            {
                _BloggieDbContext.Remove(existingBlogPost);
                await _BloggieDbContext.SaveChangesAsync();
            }
         
            return RedirectToPage("/Admin/Blogs/List");
        }


    }
}
