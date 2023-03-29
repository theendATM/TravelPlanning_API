using Microsoft.AspNetCore.Mvc;
using tpa_backend.DTOModels;
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
        [Route("mereLandmarks")]
        public IActionResult GetMereLandmarks([FromQuery] MereLandmarkViewModel model)
        {
            try
            {
                return Ok(_landmarkService.GetMereLandmarks(model));
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("suitableLandmarks")]
        public IActionResult GetSuitableLandmarks([FromQuery] SuitableLandmarksViewModel model)
        {
            try
            {
                return Ok(_landmarkService.GetSuitableLandmarks(model));
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return StatusCode(500);
            }
        }
    }
}
