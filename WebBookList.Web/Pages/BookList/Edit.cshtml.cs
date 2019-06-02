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
    public class EditModel : PageModel
    {
        private readonly WebBookListDbContext webBookListDbContext;

        public EditModel(WebBookListDbContext webBookListDbContext)
        {
            this.webBookListDbContext = webBookListDbContext;
        }


        [TempData]
        public string Message { get; set; }

        [BindProperty]
        public Book Book { get; set; }
        public async Task OnGet(int id)
        {
            Book = await webBookListDbContext.Books.FindAsync(id);
            //Book = webBookListDbContext.Books.Where(b => b.Id == id).FirstOrDefault();
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var BookFromDb = await webBookListDbContext.Books.FindAsync(Book.Id);
                BookFromDb.Name = Book.Name;
                BookFromDb.ISBN = Book.ISBN;
                BookFromDb.AuthorName = Book.AuthorName;

                await webBookListDbContext.SaveChangesAsync();
                Message = "Book edited successfully";
                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}