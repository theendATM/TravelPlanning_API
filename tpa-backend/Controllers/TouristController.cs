using Microsoft.AspNetCore.Identity;
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

        [HttpGet]
        [Route("/tourist/{id}")]
        public IActionResult GetTouristInfo(Guid touristId)
        {
            try
            {
                return Ok(_touristService.GetTourist(touristId));
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("/tourists")]
        public IActionResult GetTourists(Guid userId)
        {
            try
            {
                return Ok(_touristService.GetAllTourists(userId));
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPatch]
        [Route("tourist/{id}/edit")]
        public IActionResult EditUser(Guid touristId,TouristCreateEditDTO dto)
        {
            try
            {
                _touristService.EditTourist(dto, touristId);
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("tourist/add")]
        public IActionResult CreateTourist(TouristCreateEditDTO dto, Guid userId)
        {
            try
            {
                _touristService.CreateTourist(dto, userId);
                return Ok();
            }

            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        [ActionName("DeleteTourist")]
        public IActionResult DeleteTourist(Guid touristId)
        {
            try
            {
                _touristService.RemoveTourist(touristId);
                return Ok() ;
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
