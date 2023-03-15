using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tpa_backend.Data;
using tpa_backend.DTOModels;
using tpa_backend.Models;
using tpa_backend.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Authorization;

namespace tpa_backend.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        AppDbContext _context;
        IUserService _userService;

        public UserController(AppDbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        [HttpGet]
        [Route("profile")]
        public IActionResult GetUser([FromQuery(Name="email")] string email)
        {
            try
            {
                // get id from cookies 
                
                return Ok(_userService.GetUser(email));
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPatch]
        [Route("profile/edit")]
        public IActionResult EditUser([FromQuery] EditName dto)
        {
            try
            {
                _userService.EditUser(dto);
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] UserCreateEditDTO dto)
        {
            try
            {
                _userService.CreateUser(dto);
                await LoginAsync(new AuthRequest
                {
                    Email = dto.Email,
                    Password = dto.Password
                });

                return Ok();
            }

            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("login")]
        //[Authorize]
        public async Task<IActionResult> LoginAsync([FromBody]AuthRequest request)
        {
            try
            {
                /*var user = _context.Users.FirstOrDefault(x => x.Email == request.Email && x.Password == _userService.HashPasswordFunction(request.Password));
                if (user == null)
                {
                    throw new IndexOutOfRangeException($"User with email or password is not found");
                }
                await Authenticate(request);*/

                var user = _context.Users.FirstOrDefault(x => x.Email == request.Email);

                if (user != null)
                {
                    var cookieOptions = new CookieOptions
                    {
                        Expires = DateTime.UtcNow.AddDays(30),
                        HttpOnly = true,
                        SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict,
                        Secure = true
                    };
                    Response.Cookies.Append("username", user.Name, cookieOptions);
                    Response.Cookies.Append("Email", user.Email, cookieOptions);
                    Response.Cookies.Append("Id", user.Id.ToString(), cookieOptions);

                    return Ok();
                }
                else
                    return Unauthorized();

            }

            catch
            {
                return StatusCode(500);
            }


        }

        /*[Route("api/controller")]
        public async Task Authenticate(AuthRequest authRequest)
        {
            var user = _context.Users.FirstOrDefault(x=>x.Email==authRequest.Email);    
            //сохранить куки
        }*/

        [Route("api/controller")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                //удалить куки
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }

        }
    }
}
