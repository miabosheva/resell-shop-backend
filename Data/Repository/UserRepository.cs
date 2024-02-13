using backend_resell_app.Interfaces;
using backend_resell_app.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_resell_app.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task<User> Authenticate(string username, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Username == username && x.Password == password);
        }

        public async Task<User> Register(string username, string password, string email, string phoneNumber)
        {
            var newUser = new User
            {
                Username = username,
                Password = password,
                Email = email,
                PhoneNumber = phoneNumber
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return newUser;
        }
    }
}
