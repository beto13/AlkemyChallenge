using MoviesApi.Models.Account;
using System.Threading.Tasks;

namespace MoviesApi.IServices
{
    public interface IAccountService
    {
        Task<bool> RegisterUser(UserInfo login);
        Task<bool> Login(UserInfo login);
    }
}
