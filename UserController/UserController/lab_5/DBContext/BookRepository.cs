using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab_5.Models.Request;
using lab_5.Models.Entities;
using AutoMapper;

namespace lab_5.DBContext
{
    public class BookRepository : IBookRepository
    {
        private readonly IMapper _mapper;
        public BookRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<Book> GetBooks()
        {
            using (MyDBContext myDBContext = new MyDBContext())
            {
                return myDBContext.BookTable.ToList();
            }
        }

        public Book GetBookByID(int id)
        {
            using (MyDBContext myDBContext = new MyDBContext())
            {
                return myDBContext.BookTable.FirstOrDefault(p => p.ID == id);
            }
        }

        public async void AddBook(ReqBook reqBook)
        {
            using(MyDBContext myDBContext = new MyDBContext())
            {
                Book playerDb = _mapper.Map<Book>(reqBook);
                myDBContext.BookTable.Add(playerDb);
                await myDBContext.SaveChangesAsync();
            }
        }

        public async void UpdateBook(Book playerDb, ReqBook reqBook)
        {
            using (MyDBContext myDBContext = new MyDBContext())
            {
                _mapper.Map(reqBook, playerDb);
                myDBContext.BookTable.Update(playerDb);
                await myDBContext.SaveChangesAsync();
            }
        }

        public async void DeleteBook(Book reqBook)
        {
            using (MyDBContext myDBContext = new MyDBContext())
            {
                myDBContext.BookTable.Remove(reqBook);
                await myDBContext.SaveChangesAsync();
            }
        }
    }
}
