using LibraryApplication.Data;
using LibraryApplication.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApplication.Services
{
    public class BookService
    {
        private IDbContextFactory<LibraryDbContext> _dbContextFactory;

        public BookService(IDbContextFactory<LibraryDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public void AddBook(Book book)
        {
            using(var context = _dbContextFactory.CreateDbContext())
            {
                context.Books.Add(book);
                context.SaveChanges();
            }
        }

        public Book GetBookByTitle(string title)
        {
            using(var context = _dbContextFactory.CreateDbContext())
            {
                var book = context.Books.SingleOrDefault(x => x.Title == title);
                return book;
            }
        }

        public void RemoveBook(string title)
        {
            var book = GetBookByTitle(title);
            if(book != null)
            {
                throw new Exception("Book does not exists. Cannot Delete!");
            }
            using(var context = _dbContextFactory.CreateDbContext())
            {
                context.Remove(book);
                context.SaveChanges();
            }
        }
    }
}
