using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.Pages.Admin.Blogs
{
    public class EditModel : PageModel
    {
        private readonly IBlogPostRepository _IBlogPostRepository;
        [BindProperty]
        public BlogPost BlogPost { get; set; }
        public EditModel(IBlogPostRepository IBlogPostRepository)
        {
            _IBlogPostRepository = IBlogPostRepository;
        }
        public async Task OnGet(Guid id)
        {
            BlogPost = await _IBlogPostRepository.GetAsync(id);
        }

        public async Task<IActionResult> OnPostEdit()
        {
            await _IBlogPostRepository.UpdateAsync(BlogPost);

            return RedirectToPage("/Admin/Blogs/List");
        }
        
        public async Task<IActionResult> OnPostDelete()
        {
            var deleted = await _IBlogPostRepository.DeleteAsync(BlogPost.Id);

            if (deleted)
            {
                return RedirectToPage("/Admin/Blogs/List");
            }

            return Page();

        }


    }
}
