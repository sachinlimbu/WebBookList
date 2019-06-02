using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebBookList.Core;
using WebBookList.Data;

namespace WebBookList.Web.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly WebBookListDbContext webBookListDbContext;

        public IndexModel(WebBookListDbContext webBookListDbContext)
        {
            this.webBookListDbContext = webBookListDbContext;
        }
        public IEnumerable<Book> books { get; set; }

        [TempData]
        public string Message { get; set; }


        public async Task OnGet()
        {
            books = await webBookListDbContext.Books.ToListAsync();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            var book = await webBookListDbContext.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            webBookListDbContext.Books.Remove(book);
            await webBookListDbContext.SaveChangesAsync();
            Message = "Book Deleted Successfully";
            return RedirectToPage("Index");
        }


    }
}