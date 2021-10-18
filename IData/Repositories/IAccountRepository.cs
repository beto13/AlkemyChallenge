using System.Threading.Tasks;

namespace IData.Repositories
{
    public interface IAccountRepository
    {
        Task<bool> RegisterUser(string email, string password);
        Task<bool> Login(string email, string password);
    }
}

