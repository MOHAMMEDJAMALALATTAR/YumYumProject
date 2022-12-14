using Yumyum.Core.ViewModels;

namespace Yumyum.Infrastructure.Services.Users
{
    public  interface IUserService
    {
        Task<ApplicationUserViewModel> Get(string id);
        Task<ApplicationUserViewModel> GetUserByUsername(string username);
        Task<string> DeleteUser(string id);
    }
}
