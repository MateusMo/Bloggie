using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.Repositories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly BloggieDbContext _BloggieDbContext;
        public BlogPostRepository(BloggieDbContext BloggieDbContext)
        {
            _BloggieDbContext = BloggieDbContext;
        }
        public async Task<BlogPost> AddAsync(BlogPost blogPost)
        {
            await _BloggieDbContext.BlogPosts.AddAsync(blogPost);
            await _BloggieDbContext.SaveChangesAsync();
            return blogPost;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existingBlogPost = await _BloggieDbContext.BlogPosts.FirstOrDefaultAsync(x => x.Id == id);
            
            if (existingBlogPost != null)
            {
                _BloggieDbContext.Remove(existingBlogPost);
                await _BloggieDbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<List<BlogPost>> GetAllAsync()
        {
            return await _BloggieDbContext.BlogPosts.ToListAsync();
        }

        public async Task<BlogPost> GetAsync(Guid id)
        {
            return await _BloggieDbContext.BlogPosts.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<BlogPost> UpdateAsync(BlogPost blogPost)
        {
            var existingBlogPost = await _BloggieDbContext.BlogPosts.FirstOrDefaultAsync(x => x.Id == blogPost.Id);
            
            if (existingBlogPost != null)
            {
                existingBlogPost.Heading = blogPost.Heading;
                existingBlogPost.ShortDescription = blogPost.ShortDescription;
                existingBlogPost.Author = blogPost.Author;
                existingBlogPost.Content = blogPost.Content;
                existingBlogPost.FeatureImageUrl = blogPost.FeatureImageUrl;
                existingBlogPost.PageTitle = blogPost.PageTitle;
                existingBlogPost.PublishedDate = blogPost.PublishedDate;
                existingBlogPost.UrlHandle = blogPost.UrlHandle;
                existingBlogPost.Visible = blogPost.Visible;

                _BloggieDbContext.Update(existingBlogPost);
            }
            
            await _BloggieDbContext.SaveChangesAsync();
            return existingBlogPost;
        }
    }
}
