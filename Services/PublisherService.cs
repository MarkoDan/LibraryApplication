using LibraryApplication.Data;
using LibraryApplication.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApplication.Services
{
    public class PublisherService
    {
        private IDbContextFactory<LibraryDbContext> _dbContextFactory;

        public PublisherService(IDbContextFactory<LibraryDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public void AddPublisher(Publisher publisher)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                context.Publishers.Add(publisher);
                context.SaveChanges();
            }
        }

        public Publisher GetPublisherByName(string name)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var publisher = context.Publishers.SingleOrDefault(x => x.Name == name);
                return publisher;
            }
        }

        public void RemovePublisher(string name)
        {
            var publisher = GetPublisherByName(name);
            if (publisher != null)
            {
                throw new Exception("Publisher does not exists. Cannot Delete!");
            }
            using (var context = _dbContextFactory.CreateDbContext())
            {
                context.Remove(publisher);
                context.SaveChanges();
            }
        }
    }
}
