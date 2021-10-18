using Entities;
using IData.Repositories;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AccountRepository(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<bool> Login(string email, string password)
        {
            var result = await signInManager.PasswordSignInAsync(email, password, isPersistent: false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                await userManager.FindByEmailAsync(email);
                return true;
            }

            return false;
        }

        public async Task<bool> RegisterUser(string email, string password)
        {
            var user = new User { 
                UserName = email, 
                Email = email, 
                EmailConfirmed = true };

            var registered = await userManager.CreateAsync(user, password);

            if (registered.Succeeded)
                return true;
            else
                return false;
        }
    }
}
