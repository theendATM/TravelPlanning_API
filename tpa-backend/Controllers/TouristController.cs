﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using tpa_backend.DTOModels;
using tpa_backend.Services;

namespace tpa_backend.Controllers
{
    [ApiController]
    public class TouristController : Controller
    {
        ITouristService _touristService;
        IUserService _userService;

        public TouristController(ITouristService touristService, IUserService userService)
        {
            _touristService=touristService;
            _userService=userService;
        }



        [HttpPatch]
        [Route("tourist/edit")]
        public IActionResult EditUser(TouristEditDTO dto)
        {
            try
            {
                _touristService.EditTourist(dto);
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("tourist/add")]
        public IActionResult CreateTourist(TouristCreateEditDTO dto)
        {
            try
            {
                _touristService.CreateTourist(dto);
                return Ok();
            }

            catch
            {
                return StatusCode(500);
            }
        }


        [HttpPost]
        [Route("tourist/delete")]
        public IActionResult DeleteTourist([FromBody] TouristDeleteDTO dto)
        {
            try
            {
                _touristService.RemoveTourist(dto.Id);
                return Ok() ;
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("tourist/interests")]
        public IActionResult GetTouristInterests([FromQuery]Guid id)
        {
            try
            {
                
                return Ok(_touristService.GetTouristInterests(id));
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
