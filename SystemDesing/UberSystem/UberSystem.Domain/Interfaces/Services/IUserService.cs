using UberSystem.Domain.Entities;

namespace UberSystem.Domain.Interfaces.Services
{
    public interface IUserService
	{
        Task<User> FindByEmail(string  email);
        Task Update(User user);
        Task Add(User user);
        Task<bool> Login(User user);
        Task CheckPasswordAsync(User user);

        Task<IEnumerable<User>> GetCustomers();

        Task<User?> Login(string email, string password);
    }
}

