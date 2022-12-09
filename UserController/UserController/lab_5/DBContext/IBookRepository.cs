using lab_5.Models.Request;
using lab_5.Models.Entities;
using System.Collections.Generic;

namespace lab_5.DBContext
{
    public interface IBookRepository
    {
        public List<Book> GetBooks();
        public Book GetBookByID(int id);
        public void AddBook(ReqBook reqBook);
        public void UpdateBook(Book book, ReqBook regBook);
        public void DeleteBook(Book book);
    }
}
