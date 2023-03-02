﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tpa_backend.Data;
using tpa_backend.DTOModels;
using tpa_backend.Models;
using tpa_backend.Services;

namespace tpa_backend.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        AppDbContext _context;
        IUserService _userService;

        public UserController(AppDbContext context, IUserService userService )
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
        public IActionResult CreateUser([FromBody]UserCreateEditDTO dto)
        {
            try
            {
                _userService.CreateUser(dto);
                // save cookies
                return Ok();
            }
            
            catch 
            { 
                return StatusCode(500); 
            }
        }

    }
}
