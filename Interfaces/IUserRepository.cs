using backend_resell_app.Models;

namespace backend_resell_app.Interfaces
{
    public interface IUserRepository
    {
        Task<User> Authenticate(string username, string password);
    }
}
