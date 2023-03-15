
using GoogleApi.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using tpa_backend.Data;
using tpa_backend.DTOModels;
using tpa_backend.Models;

namespace tpa_backend.Services
{
    public interface IUserService
    {
        /*Task<Guid> GetUserId(ClaimsPrincipal claimsPrincipal);*/
        public UserViewDTO GetUser(string email);

        public void EditUser(EditName dto);

        public void CreateUser(UserCreateEditDTO dto);

        public string HashPasswordFunction(string password);
    }

    public class UserService : IUserService
    {
        private AppDbContext _context;
        private IConfiguration _configuration;
        /*private UserManager<User> _userManager;*/

        public UserService(AppDbContext context,  IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

       /*public async Task<Guid> GetUserId(ClaimsPrincipal claimsPrincipal)
        {
            var user = await _userManager.GetUserAsync(claimsPrincipal);
            if (user == null)
                throw new IndexOutOfRangeException($"User is not found");
            return user.Id;
        } */

        public UserViewDTO GetUser(string email)
        {
            var user = _context.Users
                .Include(x=>x.Tourists)
                .Include(x=>x.Plans)
                .FirstOrDefault(x => x.Email == email);
            if (user == null)
                throw new IndexOutOfRangeException($"User with id {email} is not found");
            Console.WriteLine(user.Tourists);
            return new UserViewDTO()
            {
                Name = user.Name,
                Email = user.Email,
                Phone = user.Phone,
                Tourists = user.Tourists,
                Plans = user.Plans,
            };
        }


        
        public void CreateUser(UserCreateEditDTO dto)
        {
            var userExists=_context.Users.FirstOrDefault(x=>x.Email==dto.Email);
            if (userExists != null)
                throw new IndexOutOfRangeException($"User with email or phone number already exists");
            var user = new User
            {
                Email = dto.Email,
                Phone = dto.Phone,
                Name = dto.Name,
                Id = Guid.NewGuid(),
                Password = HashPasswordFunction(dto.Password),
                
            };
            _context.Users.Add(user);
            _context.SaveChanges();

        }




        public void EditUser(EditName dto)
        {
            var user = _context.Users
                .FirstOrDefault(x => x.Email == dto.Email);

            if (user == null)
                throw new KeyNotFoundException($"User is not found");
            user.Phone = dto.Phone;
            user.Name = dto.Name;

            _context.SaveChanges();
        }

        public string HashPasswordFunction(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashed = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                var hash = BitConverter.ToString(hashed).Replace("-", "").ToLower();
                return hash;
            }
        }
    }
}
