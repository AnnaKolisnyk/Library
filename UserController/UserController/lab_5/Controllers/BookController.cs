using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using lab_5.Models.Entities;
using lab_5.Models.Request;
using lab_5.DBContext;
using System.Linq;
using System.Net;
using System.Collections.Generic;

namespace lab_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepo;

        public BookController(IBookRepository bookRepo)
        {
            _bookRepo = bookRepo;
        }

        [HttpGet]
        [Route("get_books")]
        public async Task<IActionResult> GetBooks()
        {
            return _bookRepo.GetBooks().Any() is true ? Ok(_bookRepo.GetBooks()) : NoContent();
        }

        [HttpGet]
        [Route("get_book/{id}")]
        public async Task<IActionResult> GetBookByID(int id)
        {
            Book book = _bookRepo.GetBookByID(id);
            return book is not null ? Ok(book) : NotFound();
        }

        [HttpPost]
        [Route("add_book")]
        public async Task<IActionResult> AddBook(ReqBook insertedBook)
        {
            _bookRepo.AddBook(insertedBook);
            return Ok(new
            {
                Message = "Succesfully added new book!",
                Status = (int)HttpStatusCode.Created,
                Book = insertedBook
            });
        }

        [Route("update_book/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateGame(ReqBook editedBook, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            Book book = _bookRepo.GetBookByID(id);
            if (book is null)
                return NotFound();

            if(editedBook.CopyAmount < 0)
            {
                return BadRequest();
            }
            _bookRepo.UpdateBook(book, editedBook);
            return Ok(new
            {
                Message = "Succesfully updated information!",
                Status = (int)HttpStatusCode.OK
            });
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteBook(int id)
        {
            Book book = _bookRepo.GetBookByID(id);
            if (book is null)
                return NotFound();
            _bookRepo.DeleteBook(book);
            return Ok(new
            {
                Message = "Succesfully deleted!",
                Status = (int)HttpStatusCode.OK,
            });
        }
    }
}
