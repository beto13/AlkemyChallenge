using IData.Repositories;
using MoviesApi.IServices;
using MoviesApi.Models.Account;
using System.Threading.Tasks;

namespace Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public async Task<bool> Login(UserInfo login)
        {
           return await accountRepository.Login(login.Email, login.Password);
        }

        public async Task<bool> RegisterUser(UserInfo login)
        {
            return await accountRepository.RegisterUser(login.Email, login.Password);
        }
    }
}
