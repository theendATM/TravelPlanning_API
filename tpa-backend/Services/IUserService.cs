
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using tpa_backend.Data;
using tpa_backend.DTOModels;
using tpa_backend.Models;

namespace tpa_backend.Services
{
    public interface IUserService
    {
        /*Task<Guid> GetUserId(ClaimsPrincipal claimsPrincipal);*/
        public UserViewDTO GetUser(Guid userId);

        public void EditUser(Guid userId, UserCreateEditDTO dto);

        public void CreateUser(UserCreateEditDTO dto);
    }

    public class UserService : IUserService
    {
        private AppDbContext _context;
        /*private UserManager<User> _userManager;*/

        public UserService(AppDbContext context)
        {
            _context = context;
        }

       /*public async Task<Guid> GetUserId(ClaimsPrincipal claimsPrincipal)
        {
            var user = await _userManager.GetUserAsync(claimsPrincipal);
            if (user == null)
                throw new IndexOutOfRangeException($"User is not found");
            return user.Id;
        } */

        public UserViewDTO GetUser(Guid userId)
        {
            var user = _context.Users
                .Include(x=>x.Tourists)
                .FirstOrDefault(x => x.Id == userId);
            if (user == null)
                throw new IndexOutOfRangeException($"User with id {userId} is not found");
            return new UserViewDTO()
            {
                Name = user.Name,
                Email = user.Email,
                Phone = user.Phone,
                Tourists = null,
                Plans =null,
            };
        }


        
        public void CreateUser(UserCreateEditDTO dto)
        {
            var user = new User
            {
                Email = dto.Email,
                Phone= dto.Phone,
                Name = dto.Name,
                Id= Guid.NewGuid(),
            };
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void EditUser(Guid userId, UserCreateEditDTO dto)
        {
            Console.WriteLine(userId);
            var user = _context.Users
                .Include(x => x.Tourists)
                .FirstOrDefault(x => x.Id == userId);

            if (user == null)
                throw new KeyNotFoundException($"User with id {userId} is not found");
            user.Email = dto.Email;
            user.Phone = dto.Phone;
            user.Name = dto.Name;

            _context.SaveChanges();
        }
    }
}
