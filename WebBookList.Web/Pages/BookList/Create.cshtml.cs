using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebBookList.Core;
using WebBookList.Data;

namespace WebBookList.Web.Pages.BookList
{
    public class CreateModel : PageModel
    {
        private readonly WebBookListDbContext webBookListDbContext;

        public CreateModel(WebBookListDbContext webBookListDbContext)
        {
            this.webBookListDbContext = webBookListDbContext;
        }
        [BindProperty]
        public Book Book { get; set; }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            webBookListDbContext.Books.Add(Book);
            await webBookListDbContext.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}