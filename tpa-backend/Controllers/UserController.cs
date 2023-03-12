using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tpa_backend.Data;
using tpa_backend.DTOModels;
using tpa_backend.Models;
using tpa_backend.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace tpa_backend.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        AppDbContext _context;
        IUserService _userService;

        public UserController(AppDbContext context, IUserService userService)
        {
            _context=context;
            _userService=userService;
        }

        [HttpGet]
        [Route("profile/{id}")]
        public IActionResult GetUser(Guid id)
        {
            try{
                // get id from cookies 
                return Ok(_userService.GetUser(id));
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPatch]
        [Route("profile/edit/{userId}")]
        public IActionResult EditUser(Guid userId, [FromBody]UserCreateEditDTO dto)
        {
            try
            {
                _userService.EditUser(userId, dto);
                return Ok();
            }
            catch 
            { 
                return StatusCode(500); 
            }
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterAsync([FromBody]UserCreateEditDTO dto)
        {
            try
            {
                _userService.CreateUser(dto);
                await Authenticate(new AuthRequest
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
        public async Task<IActionResult> LoginAsync(AuthRequest request)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(x => x.Email == request.Email && x.Password == _userService.HashPasswordFunction(request.Password));
                if (user == null)
                {
                    throw new IndexOutOfRangeException($"User with email or password is not found");
                }
                await Authenticate(request);
                // save cookies

                return Ok();
            }

            catch
            {
                return StatusCode(500);
            }
        }

        [Route("api/controller")]
        public async Task Authenticate(AuthRequest authRequest)
        {


            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, authRequest.Email)
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        [Route("api/controller")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                   await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }

        }

    }
}
