using backend_resell_app.Models;

namespace backend_resell_app.Interfaces
{
    public interface IUserRepository
    {
        Task<User> Authenticate(string username, string password);

        Task<User> Register(string username, string password, string email, string phoneNumber);

        int returnIdByUsername(string username);
    }
}
