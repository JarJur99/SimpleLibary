using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StronaKsiazek.Model;

namespace StronaKsiazek.Controllers
{
    [Route("api/Book")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly ApplicationDBContext _db;
        public BookController(ApplicationDBContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Book.ToListAsync() });
        }
        //[HttpDelete]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var bookFromDb = await _db.Book.FirstOrDefaultAsync(book => book.Id == id);

        //}
    }
}