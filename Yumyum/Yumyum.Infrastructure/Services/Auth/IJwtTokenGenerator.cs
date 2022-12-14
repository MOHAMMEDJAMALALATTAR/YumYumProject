using Data.Models;
using Microsoft.AspNetCore.Identity;

namespace Yumyum.Infrastructure.Services.Auth
{
    public interface IJwtTokenGenerator
    {
        string Generate(ApplicationUser user);
    }
}
