using LibraryApplication.Data;
using LibraryApplication.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApplication.Services
{
    public class AuthorService
    {
        private IDbContextFactory<LibraryDbContext> _dbContextFactory;

        public AuthorService(IDbContextFactory<LibraryDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public void AddAuthor(Author author)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                context.Authors.Add(author);
                context.SaveChanges();
            }
        }

        public Author GetAuthorByName(string name)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var author = context.Authors.SingleOrDefault(x => x.Name == name);
                return author;
            }
        }

        public void RemoveAuthor(string name)
        {
            var author = GetAuthorByName(name);
            if (author != null)
            {
                throw new Exception("Author does not exists. Cannot Delete!");
            }
            using (var context = _dbContextFactory.CreateDbContext())
            {
                context.Remove(author);
                context.SaveChanges();
            }
        }
    }
}
