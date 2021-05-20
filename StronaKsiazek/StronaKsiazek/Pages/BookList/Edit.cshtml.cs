using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StronaKsiazek.Model;

namespace StronaKsiazek
{
    public class EditModel : PageModel
    {
        private ApplicationDBContext _db;
        public EditModel(ApplicationDBContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Book Book { get; set; }
        public async Task OnGet(int id)
        {
            Book = await _db.Book.FindAsync(id);
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                Book bookFromDb = await _db.Book.FindAsync(Book.Id);
                bookFromDb.Name = Book.Name;
                bookFromDb.Author = Book.Author;
                bookFromDb.ISBN = Book.ISBN;
                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            else
                return RedirectToPage();
        }
    }
}