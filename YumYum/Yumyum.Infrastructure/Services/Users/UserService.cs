using AutoMapper;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Yumyum.Core.Exceptions;
using Yumyum.Core.ViewModels;
using Yumyum.Data;

namespace Yumyum.Infrastructure.Services.Users
{
    public class UserService : IUserService
    {
        private readonly YumyumDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(YumyumDbContext context, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _context = context; 
            _mapper = mapper;
            _userManager = userManager;
            
        }
        public async Task<ApplicationUserViewModel> Get(string id)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                throw new NotFoundException();

            }
            return _mapper.Map<ApplicationUserViewModel>(user);
        }


        public async Task<ApplicationUserViewModel> GetUserByUsername(string username)
        {
            var user = _context.Users.SingleOrDefault(x => x.UserName == username);
            if (user == null)
            {
                throw new NotFoundException();
            }
            return _mapper.Map<ApplicationUserViewModel>(user);
        }

        public async Task<string> DeleteUser (string id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                throw new NotFoundException();
            }
           
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return ("User Deleted");  
        }
            



}
}
