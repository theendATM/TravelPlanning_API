using Microsoft.AspNetCore.Mvc;
using tpa_backend.Services;

namespace tpa_backend.Controllers
{
    [ApiController]
    public class LandmarkController : Controller
    {

        ILandmarkService _landmarkService;

        public LandmarkController(ILandmarkService landmarkService)
        {
            _landmarkService=landmarkService;
        }

            [HttpGet]
            [Route("/landmarks")]
            public IActionResult Landmarks()
            {
                try
                {
                    _landmarkService.GetLandmarks();
                    return Ok();
                }
                catch
                {
                    return StatusCode(500);
                }
            }
        }
}
