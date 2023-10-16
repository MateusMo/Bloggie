using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Bloggie.Web.Models.ViewModels;
using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

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
            try
            {
                await _IBlogPostRepository.UpdateAsync(BlogPost);
                ViewData["Notification"] = new Notification
                {
                    Message = "Record updated successfully",
                    Type = Enums.NotificationType.Success
                };
            }
            catch (Exception ex)
            {
                ViewData["Notification"] = new Notification
                {
                    Message = "Something went wrong!",
                    Type = Enums.NotificationType.Error
                };
            }
            

            return RedirectToPage("/Admin/Blogs/List");
        }
        
        public async Task<IActionResult> OnPostDelete()
        {
            var deleted = await _IBlogPostRepository.DeleteAsync(BlogPost.Id);

            if (deleted)
            {
                var notification = new Notification
                {
                    Message = "Blog was deleted successfully",
                    Type = Enums.NotificationType.Success
                };

                TempData["Notification"] = JsonSerializer.Serialize(notification);

                return RedirectToPage("/Admin/Blogs/List");
            }

            return Page();

        }
    }
}
