using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Admin.Blogs
{
    public class AddModel : PageModel
    {
        [BindProperty]
        public string Heading { get; set; }
        [BindProperty]
        public string PageTitle { get; set; }
        [BindProperty]
        public string Content { get; set; }
        [BindProperty]
        public string ShortDescription { get; set; }
        [BindProperty]
        public string ImageUrl { get; set; }
        [BindProperty]
        public string UrlHandle { get; set; }
        [BindProperty]
        public DateTime PublishedDate { get; set; }
        [BindProperty]
        public string Author { get; set; }
        [BindProperty]
        public bool IsVisible { get; set; }

        public void OnGet()
        {
        }

        public void OnPost() 
        {

        }
    }
}
