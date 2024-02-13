using backend_resell_app.Interfaces;
using backend_resell_app.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_resell_app.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task<User> Authenticate(string username, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Username == username && x.Password == password);
        }
    }
}
