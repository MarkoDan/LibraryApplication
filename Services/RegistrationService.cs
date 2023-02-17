using LibraryApplication.Data;
using LibraryApplication.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApplication.Services
{
    public class RegistrationService
    {
        private IDbContextFactory<LibraryDbContext> _dbContextFactory;

        public RegistrationService(IDbContextFactory<LibraryDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public void RegisterUser(User user) 
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }
    }
}
